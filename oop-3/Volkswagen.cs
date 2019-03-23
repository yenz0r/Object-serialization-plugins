using System;

public class Volkswagen : FamilyCar
{
    public Volkswagen(int age, int speed, int numOfPassengers, int maxNumOfPassengers, int coast)
        : base(age, speed, numOfPassengers, maxNumOfPassengers)
    {
        Coast = coast;
    }

    public Volkswagen()
    {
        
    }
    
    public int coast;

    public int Coast {
        get
        {
            return coast;
        }
        set
        {
            coast = (value > 1000000) ? 0 : value; 
        }
    }

    public override bool IsCarFull()
    {
        Console.WriteLine($"To be full you need : {MaxNumOfPassengers - NumOfPassengers}");
        return base.IsCarFull();
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"coast : {Coast}");
        base.PrintInfo();
    }
}

