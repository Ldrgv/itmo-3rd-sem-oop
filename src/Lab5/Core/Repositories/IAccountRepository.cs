using Core.Models;
using Core.Models.OperationResult;

namespace Core.Repositories;

public interface IAccountRepository
{
    public Task<Account?> FindAccountById(int id);
    public Task<OperationResult> AddAccount(int id, string pin);
    public Task<OperationResult> UpdateAccountBalance(int id, int balance);
}