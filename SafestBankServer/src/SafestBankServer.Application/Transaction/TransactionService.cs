using AutoMapper;
using SafestBankServer.Application.DTO.Transaction;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Exceptions.Transaction;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;

namespace SafestBankServer.Application.Transaction;
internal sealed class TransactionService : ITransactionService
{
    private readonly IClientRepository _clientRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;
    public TransactionService(IClientRepository clientRepository, ITransactionRepository transactionRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _transactionRepository = transactionRepository;
        _mapper = mapper;
    }
    public async Task<ClientTransactionDto> MakeTransaction(string senderNumber, string recipantAccountNumber, decimal amount, string title)
    {
        if(recipantAccountNumber.Length != 26)
        {
            throw new InvalidTransaction("Invalid recipant of the transaction.");
        }

        if(GetDecimalPlaces(amount) > 2)
        {
            throw new InvalidTransaction("You can't make a transaction with more than 2 decimal places.");
        }

        var sender = await _clientRepository.GetClientByNumberAsync(senderNumber)
            ?? throw new UnauthorizedAccessException("Your session has expired - please log in.");

        if(sender.Balance < amount)
        {
            throw new NotEnoughMoney("You don't have enough money to make this transaction.");
        }

        var recipant = await _clientRepository.GetClientByAccountNumberAsync(recipantAccountNumber)
            ?? throw new InvalidTransaction("Invalid recipant of the transaction.");

        if(sender.AccountNumber == recipant.AccountNumber)
        {
            throw new InvalidTransaction("You can't make a transaction to yourself.");
        }

        var transaction = new ClientTransaction(
            sender.Id, 
            sender.Name, 
            sender.Surname, 
            sender.AccountNumber, 
            recipant.Id, 
            recipant.Name, 
            recipant.Surname, 
            recipantAccountNumber, 
            amount, 
            DateTime.UtcNow, 
            title
            );

        await _transactionRepository.AddTransactionAsync(transaction);

        sender.Balance -= amount;
        await _clientRepository.UpdateClientAsync(sender);

        recipant.Balance += amount;
        await _clientRepository.UpdateClientAsync(recipant);

        var transactionDto = _mapper.Map<ClientTransactionDto>(transaction);

        return transactionDto;
    }

    private static int GetDecimalPlaces(decimal value)
    {
        string valueAsString = value.ToString();

        int decimalPointIndex = valueAsString.IndexOf('.');

        if(decimalPointIndex == -1)
        {
            return 0;
        }

        int decimalPlaces = valueAsString.Length - decimalPointIndex - 1;

        return decimalPlaces;
    }
}
