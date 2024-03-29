﻿using SafestBankServer.Application.Exceptions.PasswordReset;
using SafestBankServer.Application.Features.PasswordReset.DTO;
using SafestBankServer.Core.Auth.Passwords;
using SafestBankServer.Core.Client;
using System.Security.Cryptography;
using System.Web;

namespace SafestBankServer.Application.Features.PasswordReset;
internal class PasswordResetService : IPasswordResetService
{
    private readonly IClientRepository _clientRepository;
    private readonly IPasswordManager _passwordManager;
    public PasswordResetService(IClientRepository clientRepository, IPasswordManager passwordManager)
    {
        _clientRepository = clientRepository;
        _passwordManager = passwordManager;
    }
    public async Task ResetPassword(ResetPasswordDto passwordResetDto)
    {
        if(CalculateEntropy(passwordResetDto.Password) < 4)
        {
            throw new ResetPasswordException("Password entropy is too low. Please choose a different password.");
        }

        var tokenBytes = Convert.FromBase64String(passwordResetDto.Token);
        var tokenBytesHashed = SHA512.HashData(tokenBytes);

        var client = await _clientRepository.GetClientByHashedToken(tokenBytesHashed)
            ?? throw new ResetPasswordException("Bad request.");

        client.PasswordResetTokenHash = null;

        if(client.LastPasswordResetRequestTime > DateTime.UtcNow.AddMinutes(5))
        {
            throw new ResetPasswordException("Token expired.");
        }

        client.PasswordResetAttempts = 0;
        client.IsBlocked = false;
        client.LoginAttempts = 0;

        var partialPasswordList = _passwordManager.GenerateHashedPartialPasswords(passwordResetDto.Password);
        await _clientRepository.UpdateClientPasswords(client, partialPasswordList);

    }
    public async Task SendPasswordResetMailAsync(SendPasswordResetMailDto passwordResetDto)
    {
        var client = await _clientRepository.GetClientByClientNumberAsync(passwordResetDto.ClientNumber);

        if(client is null || client.Email != passwordResetDto.Email)
        {
            return;
        }

        if(client.PasswordResetAttempts > 3)
        {
            throw new PasswordResetAttemptsExceeded("You have exceeded the number of password reset attempts. Please contact with the support.");
        }

        if(client.LastPasswordResetRequestTime != null)
        {
            var passwordResetRequest = (DateTime)client.LastPasswordResetRequestTime;
            var timeDifference = DateTime.UtcNow - passwordResetRequest;

            if(timeDifference.TotalMinutes < 5)
            {
                throw new PasswordResetRequestTimeNotExpiredException("You have to wait 5 minutes before sending another request.");
            }
        }

        client.PasswordResetAttempts++;

        using var rng = RandomNumberGenerator.Create();
        byte[] tokenBytes = new byte[32];

        rng.GetBytes(tokenBytes);
        var tokenBytesHashed = SHA512.HashData(tokenBytes);

        while(await _clientRepository.IsTokenGeneratingColisions(tokenBytesHashed))
        {
            rng.GetBytes(tokenBytes);
            tokenBytesHashed = SHA512.HashData(tokenBytes);
        }

        client.LastPasswordResetRequestTime = DateTime.UtcNow;
        client.PasswordResetTokenHash = tokenBytesHashed;
        await _clientRepository.UpdateClientAsync(client);

        string base64UrlToken = Convert.ToBase64String(tokenBytes);
        string encodedToken = HttpUtility.UrlEncode(base64UrlToken);
        string resetUrl = $"https://localhost/password-reset?token={encodedToken}";

        Console.WriteLine($"SENDING \n RESET URL:{resetUrl} \nTO {client.Email}");

        return;
    }

    private double CalculateEntropy(string password)
    {
        double entropy = 0;
        var characterCounts = new Dictionary<int, int>();

        foreach(char character in password)
        {
            int charCode = character;

            if (characterCounts.ContainsKey(charCode))
            {
                characterCounts[charCode]++;
            }
            else
            {
                characterCounts[charCode] = 1;
            }
        }

        foreach(KeyValuePair<int, int> characterCount in characterCounts)
        {
            double probability = (double)characterCount.Value / password.Length;
            entropy -= probability * Math.Log2(probability);
        }

        return entropy;
    }
}