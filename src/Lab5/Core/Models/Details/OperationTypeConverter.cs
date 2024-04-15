namespace Core.Models.Details;

public static class OperationTypeConverter
{
    public static OperationType FromString(string str)
    {
        if (str == null) throw new ArgumentNullException(nameof(str));

        switch (str)
        {
            case "TopUp":
                return OperationType.TopUp;
            case "Withdraw":
                return OperationType.Withdraw;
            default:
                return OperationType.Null;
        }
    }
}