using Core.Models.OperationResult;

namespace Core.Services.Admin.Details;

public static class PinChecker
{
    public static OperationResult Check(int pin)
    {
        if (pin >= 1e6 && pin < 1e7)
        {
            return new OperationResult(OperationResultStatus.Success);
        }

        return new OperationResult(OperationResultStatus.Error, "PIN should be integer between 1e6 and 1e7");
    }
}