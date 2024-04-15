using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Validators.ComputerValidator;

public interface IComputerValidator
{
    public CompatibilityResult Validate(Computer computer);
}