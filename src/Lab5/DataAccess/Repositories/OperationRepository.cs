using System.Data.Common;
using Core.Models;
using Core.Models.Details;
using Core.Models.OperationResult;
using Core.Repositories;
using Npgsql;

namespace DataAccess.Repositories;

public class OperationRepository : IOperationRepository
{
    private NpgsqlDataSource _db;

    public OperationRepository(NpgsqlDataSource db)
    {
        _db = db;
    }

    public async Task<OperationResult> AddOperation(Operation operation)
    {
        Console.WriteLine("Tring add into ops");
        if (operation == null) throw new ArgumentNullException(nameof(operation));

        await using var command = new NpgsqlCommand(
            @"
              INSERT INTO operations(time, account_id, operation_type, amount)
              VALUES (:time, :account_id, :operation_type, :amount)",
            await _db.OpenConnectionAsync());
        command.Parameters.AddWithValue(":time", operation.Time);
        command.Parameters.AddWithValue(":account_id", operation.AccountId);
        command.Parameters.AddWithValue(":operation_type", operation.OperationType.ToString());
        command.Parameters.AddWithValue(":amount", operation.Amount);

        try
        {
            await command.ExecuteNonQueryAsync();

            return new OperationResult(OperationResultStatus.Success);
        }
        catch (DbException e)
        {
            return new OperationResult(OperationResultStatus.Error, e.Message);
        }
    }

    public async Task<IEnumerable<Operation>> FindOperationsHistoryByAccountId(int id)
    {
        string sql = $"""
                          SELECT time, account_id, operation_type, amount
                          FROM operations
                          WHERE account_id = {id}
                      """;

        await using NpgsqlCommand command = _db.CreateCommand(sql);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        var operations = new List<Operation>();
        while (await reader.ReadAsync())
        {
            operations.Add(new Operation(
                reader.GetDateTime(0),
                reader.GetInt32(1),
                OperationTypeConverter.FromString(reader.GetString(2)),
                reader.GetInt32(3)));
        }

        return operations;
    }
}