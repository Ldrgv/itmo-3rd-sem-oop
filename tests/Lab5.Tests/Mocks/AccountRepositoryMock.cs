using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.OperationResult;
using Core.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Defaults;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class AccountRepositoryMock : IAccountRepository
{
    private List<Account> _accounts;

    public AccountRepositoryMock()
    {
        _accounts = new List<Account> { new Consts().Account };
    }

    public Task<Account?> FindAccountById(int id)
    {
        return Task.FromResult(_accounts.Find(account => account.Id == id));
    }

    public Task<OperationResult> AddAccount(int id, string pin)
    {
        _accounts.Add(new Account(id, pin));

        return Task.FromResult(new OperationResult(OperationResultStatus.Success));
    }

    public Task<OperationResult> UpdateAccountBalance(int id, int balance)
    {
       Account? account = _accounts.Find(account => account.Id == id);
       if (account == null)
       {
           return Task.FromResult(new OperationResult(OperationResultStatus.Error, "No account with such id"));
       }

       _accounts.Remove(account);
       account.UpdateBalance(balance);
       _accounts.Add(account);

       return Task.FromResult(new OperationResult(OperationResultStatus.Success));
    }
}