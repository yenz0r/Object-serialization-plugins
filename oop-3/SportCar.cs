using System;

public class SportCar : Car
{
    public SportCar(int age, int speed, int maxSpeed)
        : base(age, speed)
    {
        MaxSpeed = maxSpeed;
    }

    public SportCar()
    {

    }

    public int MaxSpeed { get; set; }

    public virtual void SpeedUp(int inputSpeed)
    {
        Speed += inputSpeed;
        Console.WriteLine($"New speed is : {Speed}");
    }

    public void SpeedUpToMax(int inputSpeed)
    {
        while (Speed < MaxSpeed)
        {
            SpeedUp(inputSpeed);
        }
    }

    public virtual void SpeedDown(int inputSpeed)
    {
        Speed -= inputSpeed;
        Console.WriteLine($"New speed is : {Speed}");
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Max speed : {MaxSpeed}; Current speed : {Speed}");
    }
}

