using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;

public abstract class ArmorBase
{
    protected ArmorBase(double hitPoints)
    {
        Guard.ArgumentIsPositive(hitPoints, "Armor hit points");

        HitPoints = hitPoints;
    }

    public double HitPoints { get; protected set; }

    public abstract double TakeDamage(double damage);
}