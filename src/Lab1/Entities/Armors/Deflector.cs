using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Armors;

public class Deflector : ArmorBase
{
    public Deflector(double hitPoints)
        : base(hitPoints)
    {
    }

    public override double TakeDamage(double damage)
    {
        Guard.ArgumentIsPositive(damage, "Damage");

        if (damage > HitPoints)
        {
            damage -= HitPoints;
            HitPoints = 0;

            return damage;
        }

        HitPoints -= damage;

        return 0;
    }
}