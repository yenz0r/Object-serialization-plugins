using System;

public class AudiR8 : SportCar
{
    public int power; 
    public int Power {
        get
        {
            return power;
        }
        set
        {
            power = (value > 300) ? 0 : value;
        }
    }

    public AudiR8(int age, int speed, int maxSpeed, int power)
        : base(age, speed, maxSpeed)
    {
        this.Power = power;
    }

    public AudiR8()
    {

    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Audi power: {Power}");
        base.PrintInfo();
    }

    public override void SpeedUp(int inputSpeed)
    {
        for (int i = Speed; i < MaxSpeed; i += inputSpeed)
        {
            base.SpeedUp(inputSpeed);
        }
    }

    public override void SpeedDown(int inputSpeed)
    {
        for (int i = Speed; i < MaxSpeed; i += inputSpeed)
        {
            base.SpeedDown(inputSpeed);
        }
    }
}
