using Core.Models.OperationResult;
using Core.Repositories;
using Core.Services.Admin;
using Microsoft.Extensions.Configuration;

namespace Core.Services.Login;

public class AdminLoginService
{
    private IConfiguration _configuration;
    private IAccountRepository _accountRepository;

    public AdminLoginService(IConfiguration configuration, IAccountRepository accountRepository)
    {
        _configuration = configuration;
        _accountRepository = accountRepository;
    }

    public Task<OperationResult> Login(string password)
    {
        if (password != _configuration["AdminPassword"])
        {
            return Task.FromResult(new OperationResult(OperationResultStatus.Error, "Invalid password for admin"));
        }

        return Task.FromResult<OperationResult>(new OperationResultSuccess<AdminService>(
            new AdminService(_accountRepository)));
    }
}