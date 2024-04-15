using Core.Models;
using Core.Models.Details;
using Core.Models.OperationResult;
using Core.Repositories;

namespace Core.Services.Account;

public class AccountService : IAccountService
{
    private readonly Models.Account _account;
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationRepository _operationRepository;

    public AccountService(Models.Account account, IAccountRepository accountRepository, IOperationRepository operationRepository)
    {
        _account = account ?? throw new ArgumentNullException(nameof(account));
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _operationRepository = operationRepository ?? throw new ArgumentNullException(nameof(operationRepository));
    }

    public Task<OperationResult> GetAccountBalance()
    {
        return Task.FromResult<OperationResult>(new OperationResultSuccess<int>(_account.Balance));
    }

    public async Task<OperationResult> Withdraw(int amount)
    {
        if (amount < 0)
        {
            return new OperationResult(OperationResultStatus.Error, "Amount should be non negative");
        }

        OperationResult depositResult = _account.Deposit(-amount);
        if (depositResult.Status != OperationResultStatus.Success)
        {
            return depositResult;
        }

        OperationResult updateResult = await _accountRepository.UpdateAccountBalance(_account.Id, _account.Balance);
        if (updateResult.Status != OperationResultStatus.Success)
        {
            return updateResult;
        }

        return await _operationRepository.AddOperation(
            new Operation(DateTime.Now, _account.Id, OperationType.Withdraw, amount));
    }

    public async Task<OperationResult> TopUp(int amount)
    {
        if (amount < 0)
        {
            return new OperationResult(OperationResultStatus.Error, "Amount should be non negative");
        }

        OperationResult depositResult = _account.Deposit(amount);
        if (depositResult.Status != OperationResultStatus.Success)
        {
            return depositResult;
        }

        OperationResult updateResult = await _accountRepository.UpdateAccountBalance(_account.Id, _account.Balance);
        if (updateResult.Status != OperationResultStatus.Success)
        {
            return updateResult;
        }

        Console.WriteLine("Trying add operation");
        return await _operationRepository.AddOperation(
            new Operation(DateTime.Now, _account.Id, OperationType.TopUp, amount));
    }

    public async Task<OperationResult> GetAccountOperationHistory()
    {
        IEnumerable<Operation> operations = await _operationRepository.FindOperationsHistoryByAccountId(_account.Id);
        if (!operations.Any())
        {
            return new OperationResult(OperationResultStatus.Error, "Can't find some operations for this account");
        }

        return new OperationResultSuccess<IEnumerable<Operation>>(operations);
    }
}