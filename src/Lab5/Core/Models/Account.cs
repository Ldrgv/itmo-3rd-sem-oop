using Core.Models.OperationResult;

namespace Core.Models;

public class Account
{
    private string _pin;

    public Account(int id, string pin, int balance = 0)
    {
        Id = id;
        _pin = pin;
        Balance = balance;
    }

    public int Id { get; }
    public int Balance { get; private set; }

    public bool IsPinMatch(string pin)
    {
        if (pin == null) throw new ArgumentNullException(nameof(pin));

        return pin.Equals(_pin, StringComparison.Ordinal);
    }

    public void UpdateBalance(int balance)
    {
        Balance = balance;
    }

    public OperationResult.OperationResult Deposit(int amount)
    {
        int newBalance = Balance + amount;

        if (newBalance < 0)
        {
            return new OperationResult.OperationResult(
                OperationResultStatus.Error,
                "Balance is negative after operation");
        }

        Balance = newBalance;

        return new OperationResult.OperationResult(OperationResultStatus.Success);
    }
}