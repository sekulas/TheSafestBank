using AutoMapper;
using SafestBankServer.Application.Exceptions.Auth;
using SafestBankServer.Application.Exceptions.Transaction;
using SafestBankServer.Application.Features.Transaction.Transaction;
using SafestBankServer.Core.Client;
using SafestBankServer.Core.Transaction;

namespace SafestBankServer.Application.Features.Transaction;
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
    public async Task<ClientTransactionDto> MakeTransaction(Guid senderId, string recipantAccountNumber, decimal amount, string title)
    {
        var sender = await _clientRepository.GetClientByIdAsync(senderId)
            ?? throw new UnauthorizedAccessException("Your session has expired - please log in.");

        if(sender.IsBlocked)
        {
            throw new UnauthorizedAccessException("Your account has been blocked. Please contact with the support or change the password using email.");
        }

        if (sender.Balance < amount)
        {
            throw new NotEnoughMoneyException("You don't have enough money to make this transaction.");
        }

        var recipant = await _clientRepository.GetClientByAccountNumberAsync(recipantAccountNumber)
            ?? throw new InvalidTransactionException("Invalid recipant of the transaction.");

        if (sender.AccountNumber == recipant.AccountNumber)
        {
            throw new InvalidTransactionException("You can't make a transaction to yourself.");
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
}
