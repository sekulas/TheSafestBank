﻿using Microsoft.AspNetCore.Mvc;
using SafestBankServer.Application.Auth;
using SafestBankServer.Application.DTO;
using SafestBankServer.Application.DTO.Auth;
using SafestBankServer.Application.DTO.Client;

namespace SafestBankServer.Web.Auth;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authRepository)
    {
        _authService = authRepository;
    }

    [HttpPost("password")]
    public async Task<ActionResult<int[]>> GetPasswordMaskAsync([FromBody] ClientNumberDto clientNumberDto)
    {
        var passwordMask = await _authService.GetPasswordMaskAsync(clientNumberDto);
        return Ok(passwordMask);
    }

    [HttpPost("login")]
    public async Task<ActionResult<BankClientDto>> LoginAsync([FromBody] ClientLoginDto clientLoginDto)
    {
        var result = await _authService.LoginAsync(clientLoginDto);
        return Ok(result);
    }
}