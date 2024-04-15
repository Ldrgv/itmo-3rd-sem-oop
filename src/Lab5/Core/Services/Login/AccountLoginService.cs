using Core.Models.OperationResult;
using Core.Repositories;
using Core.Services.Account;

namespace Core.Services.Login;

public class AccountLoginService
{
    private IAccountRepository _accountRepository;
    private IOperationRepository _operationRepository;

    public AccountLoginService(IAccountRepository accountAccountRepository, IOperationRepository operationRepository)
    {
        _accountRepository = accountAccountRepository;
        _operationRepository = operationRepository;
    }

    public async Task<OperationResult> Login(int id, string password)
    {
        Models.Account? account = await _accountRepository.FindAccountById(id);
        if (account == null)
        {
            return new OperationResult(OperationResultStatus.Error, "No account with such id");
        }

        if (!account.IsPinMatch(password))
        {
            return new OperationResult(OperationResultStatus.Error, "Incorrect pin for this account");
        }

        return new OperationResultSuccess<AccountService>(
            new AccountService(account, _accountRepository, _operationRepository));
    }
}