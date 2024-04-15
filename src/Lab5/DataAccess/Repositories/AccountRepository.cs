using System.Data.Common;
using Core.Models;
using Core.Models.OperationResult;
using Core.Repositories;
using Npgsql;

namespace DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private NpgsqlDataSource _db;

    public AccountRepository(NpgsqlDataSource db)
    {
        _db = db;
    }

    public async Task<Account?> FindAccountById(int id)
    {
        string sql = $"""
            SELECT id, pin, balance
            FROM accounts
            WHERE id = {id}
        """;

        await using NpgsqlCommand command = _db.CreateCommand(sql);
        await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync() == false)
        {
            return null;
        }

        return new Account(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetInt32(2));
    }

    public async Task<OperationResult> AddAccount(int id, string pin)
    {
        string sql = $"""
                     INSERT INTO accounts(id, pin)
                     VALUES ({id}, '{pin}')
                     """;

        await using NpgsqlCommand command = _db.CreateCommand(sql);

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

    public async Task<OperationResult> UpdateAccountBalance(int id, int balance)
    {
        string sql = $"""
                     UPDATE accounts
                     SET balance = {balance}
                     WHERE id = {id}
                     """;

        await using NpgsqlCommand command = _db.CreateCommand(sql);

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
}