using System;

public class TruckCar : Car
{
    public TruckCar(int age, int speed, int maxWeight, int weight) : base(age, speed)
    {
        MaxWeight = maxWeight;
        Weight = weight;
    }

    public TruckCar() {
    }

    public int MaxWeight { get; set; }
    public int weight;

    public int Weight
    {
        get
        {
            return weight;
        }
        set
        {
            weight = (value > MaxWeight) ? (value - MaxWeight) : value;
        }
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Max weight: {MaxWeight}; Current weight: {Weight}");
    }

    public void WeightUp(int inputWeight)
    {
        Weight += inputWeight;
        Console.WriteLine($"New Weight is : {Weight}");
    }

    public void WeightUpToMax(int inputWeight)
    {
        while (Weight < MaxWeight)
        {
            WeightUp(inputWeight);
        }
    }
}
