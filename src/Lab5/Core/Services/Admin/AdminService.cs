using Core.Models.OperationResult;
using Core.Repositories;

namespace Core.Services.Admin;

public class AdminService : IAdminService
{
    private readonly IAccountRepository _repository;

    public AdminService(IAccountRepository accountRepository)
    {
        _repository = accountRepository;
    }

    public async Task<OperationResult> CreateAccount(int id, string pin)
    {
        return await _repository.AddAccount(id, pin);
    }
}