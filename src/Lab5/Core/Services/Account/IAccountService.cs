using Core.Models.OperationResult;

namespace Core.Services.Account;

public interface IAccountService
{
    public Task<OperationResult> GetAccountBalance();
    public Task<OperationResult> Withdraw(int amount);
    public Task<OperationResult> TopUp(int amount);
    public Task<OperationResult> GetAccountOperationHistory();
}