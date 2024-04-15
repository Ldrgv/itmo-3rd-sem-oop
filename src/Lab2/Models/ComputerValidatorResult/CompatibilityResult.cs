namespace Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;

public sealed record CompatibilityResult(CompatibilityStatus Status, string Message = "");
