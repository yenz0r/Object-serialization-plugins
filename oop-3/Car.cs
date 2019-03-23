using System;
using System.Reflection;

public class Car
{
    public delegate void DisplayResult(string msg);

    public Car()
    {
        this.Name = "car";
    }

    public Car(int age, int speed)
    {
        Age = age;
        this.Speed = speed;
        this.Name = "car";
    }

    public string Name { get; set; }

    public int Age { get; set; }
    public int speed;

    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = (value > 300) ? 0 : value;
        }
    }

    public virtual void PrintInfo()
    {
        Console.WriteLine($"Speed : {Speed}, Age : {Age}");
    }

    public static void update(int index, int newValue, Car changingClass)
    {
        DisplayInfo displayInfo = new DisplayInfo();
        DisplayResult displayResult;
        displayResult = displayInfo.displayMsg;

        int tmpIndex = 0;

        foreach (PropertyInfo prop in Serializer.getPropsArr<Car>(changingClass))
        {
            if (tmpIndex == index)
            {
                prop.SetValue(changingClass, newValue);
                displayInfo.displayMsg($"Property : '{prop.Name}' is {newValue}");
                break;
            }
            else
            {
                tmpIndex++;
            }
        }
    }
}
