using System;

public class FamilyCar : Car
{
    public FamilyCar(int age, int speed, int maxNumOfPassengers, int numOfPassangers)
        : base(age, speed)
    {
        NumOfPassengers = numOfPassangers;
        MaxNumOfPassengers = maxNumOfPassengers;
    }

    public FamilyCar()
    {

    }
    
    public int numOfPassengers;

    public int NumOfPassengers
    {
        get
        {
            return numOfPassengers;
        }
        set
        {
            numOfPassengers = (value > MaxNumOfPassengers) ? (value - MaxNumOfPassengers) : value;
        }
    }
    public int MaxNumOfPassengers;

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Num of passengers: {NumOfPassengers}; maxNum of passengers : {MaxNumOfPassengers}");
    }

    public virtual bool IsCarFull()
    {
        if (NumOfPassengers == MaxNumOfPassengers) { return true; }
        else { return false; }
    }
}
