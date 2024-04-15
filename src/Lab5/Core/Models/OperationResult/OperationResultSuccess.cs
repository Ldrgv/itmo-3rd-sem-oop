namespace Core.Models.OperationResult;

public class OperationResultSuccess<T> : OperationResult
{
    public OperationResultSuccess(T result)
        : base(OperationResultStatus.Success, string.Empty)
    {
        Result = result;
    }

    public T Result { get; }
}