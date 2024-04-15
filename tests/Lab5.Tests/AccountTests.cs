using System.Threading.Tasks;
using Core.Models.OperationResult;
using Core.Services.Account;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Defaults;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountTests
{
    private Consts _consts;
    private AccountService _accountService;

    public AccountTests()
    {
        _consts = new Consts();
        _accountService = new AccountService(
            _consts.Account, new AccountRepositoryMock(), new OperationRepositoryMock());
    }

    [Fact]
    public async Task TopUpBalanceTest()
    {
        const int add = 10;

        OperationResult balanceOperationBefore = await _accountService.GetAccountBalance();
        OperationResultSuccess<int> balanceBefore = Assert.IsType<OperationResultSuccess<int>>(balanceOperationBefore);

        Assert.Equal(OperationResultStatus.Success, (await _accountService.TopUp(add)).Status);

        OperationResult balanceOperationAfter = await _accountService.GetAccountBalance();
        OperationResultSuccess<int> balanceAfter = Assert.IsType<OperationResultSuccess<int>>(balanceOperationAfter);

        Assert.Equal(balanceBefore.Result + add, balanceAfter.Result);
    }

    [Fact]
    public async Task WithdrawBalanceSuccessTest()
    {
        const int add = 10;

        OperationResult balanceOperationBefore = await _accountService.GetAccountBalance();
        OperationResultSuccess<int> balanceBefore = Assert.IsType<OperationResultSuccess<int>>(balanceOperationBefore);

        Assert.Equal(OperationResultStatus.Success, (await _accountService.TopUp(add)).Status);
        Assert.Equal(OperationResultStatus.Success, (await _accountService.Withdraw(add)).Status);

        OperationResult balanceOperationAfter = await _accountService.GetAccountBalance();
        OperationResultSuccess<int> balanceAfter = Assert.IsType<OperationResultSuccess<int>>(balanceOperationAfter);

        Assert.Equal(balanceBefore.Result, balanceAfter.Result);
    }

    [Fact]
    public async Task WithdrawBalanceErrorTest()
    {
        OperationResult balanceOperationBefore = await _accountService.GetAccountBalance();
        OperationResultSuccess<int> balanceBefore = Assert.IsType<OperationResultSuccess<int>>(balanceOperationBefore);

        Assert.Equal(
            OperationResultStatus.Error,
            (await _accountService.Withdraw(balanceBefore.Result + 1)).Status);
    }
}