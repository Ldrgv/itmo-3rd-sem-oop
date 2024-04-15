using System;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ComputerValidatorResult;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CompatibilityResultBuilder
{
    private CompatibilityStatus _compatibilityStatus;
    private StringBuilder _messageBuilder;

    public CompatibilityResultBuilder()
    {
        _compatibilityStatus = CompatibilityStatus.Compatible;
        _messageBuilder = new StringBuilder();
    }

    public void WithResult(CompatibilityResult result)
    {
        if (result == null) throw new ArgumentNullException(nameof(result));

        if (result.Status > _compatibilityStatus)
        {
            _compatibilityStatus = result.Status;
        }

        if (!result.Message.Any()) return;

        if (_messageBuilder.Length is not 0)
        {
            _messageBuilder.Append('\n');
        }

        _messageBuilder.Append(result.Message);
    }

    public CompatibilityResult Build()
    {
        return new CompatibilityResult(_compatibilityStatus, _messageBuilder.ToString());
    }
}