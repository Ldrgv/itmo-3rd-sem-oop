using Core.Models;
using Core.Models.OperationResult;

namespace Core.Repositories;

public interface IOperationRepository
{
    public Task<OperationResult> AddOperation(Operation operation);
    public Task<IEnumerable<Operation>> FindOperationsHistoryByAccountId(int id);
}