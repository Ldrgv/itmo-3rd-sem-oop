using Core.Models.Details;

namespace Core.Models;

public record Operation(DateTime Time, int AccountId, OperationType OperationType, int Amount);