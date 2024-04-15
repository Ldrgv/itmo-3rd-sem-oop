using Core.Models.OperationResult;

namespace Core.Services.Admin;

public interface IAdminService
{
     public Task<OperationResult> CreateAccount(int id, string pin);
}