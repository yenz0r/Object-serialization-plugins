using System;
using System.Collections.Generic;

public class Belarus520 : TruckCar
{
    public Belarus520(int age, int speed, int maxWeight, int weight, int power = 220) : base(age, speed, maxWeight, weight)
    {
        Power = power;
    }

    public Belarus520()
    {

    }
    
    public int Power;

    public int power {
        get
        {
            return Power;
        }
        set
        {
            Power = (value > 250) ? 0 : value;
        }
    }

    private int GetPower()
    {
        return Power;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Power of belarus520 {Power}");
        base.PrintInfo();
    }
}
