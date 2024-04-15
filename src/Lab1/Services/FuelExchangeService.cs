using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class FuelExchangeService
{
    public FuelExchangeService(int plasmaPrice = 5, int gravitonPrice = 7)
    {
        PlasmaPrice = plasmaPrice;
        GravitonPrice = gravitonPrice;
    }

    public int PlasmaPrice { get; }
    public int GravitonPrice { get; }

    public double GetPrice(Fuel fuel)
    {
        if (fuel == null) throw new ArgumentNullException(nameof(fuel));

        switch (fuel.Type)
        {
            case FuelType.ActivePlasma:
                return fuel.Amount * PlasmaPrice;
            case FuelType.GravitonMatter:
                return fuel.Amount * GravitonPrice;
        }

        return 0;
    }
}