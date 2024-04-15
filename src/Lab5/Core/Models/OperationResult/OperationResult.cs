namespace Core.Models.OperationResult;

public class OperationResult
{
    public OperationResult(OperationResultStatus status, string message = "")
    {
        Status = status;
        Message = message;
    }

    public OperationResultStatus Status { get; }
    public string Message { get; }
}