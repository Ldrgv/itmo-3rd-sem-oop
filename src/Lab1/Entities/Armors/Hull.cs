using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;

public class Hull : ArmorBase
{
    public Hull(double heavinessCoefficient, double hitPoints)
        : base(hitPoints)
    {
        Guard.ArgumentIsPositive(heavinessCoefficient, "Hull class");

        HeavinessCoefficient = heavinessCoefficient;
    }

    public double HeavinessCoefficient { get; }

    public override double TakeDamage(double damage)
    {
        Guard.ArgumentIsPositive(damage, "Damage");

        double realDamage = damage / HeavinessCoefficient;
        if (realDamage > HitPoints)
        {
            realDamage -= HitPoints;
            HitPoints = 0;

            return realDamage;
        }

        HitPoints -= realDamage;

        return 0;
    }
}