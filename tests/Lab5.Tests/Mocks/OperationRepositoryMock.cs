using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;
using Core.Models.OperationResult;
using Core.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;

public class OperationRepositoryMock : IOperationRepository
{
    private List<Operation> _operations;

    public OperationRepositoryMock()
    {
        _operations = new List<Operation>();
    }

    public Task<OperationResult> AddOperation(Operation operation)
    {
        _operations.Add(operation);

        return Task.FromResult(new OperationResult(OperationResultStatus.Success));
    }

    public Task<IEnumerable<Operation>> FindOperationsHistoryByAccountId(int id)
    {
        return Task.FromResult<IEnumerable<Operation>>(
            _operations.FindAll(operation => operation.AccountId == id));
    }
}