using System;

namespace Task2.Models;

public class Dog : LivingBeing
{
    public Dog()
    {
        MaxSpeed = 50; 
    }
        
    public override void Move()
    {
        if (Speed < MaxSpeed)
            Speed += 5;
    }
        
    public override void Stop()
    {
        if (Speed > 0)
            Speed -= 5;
    }
        
    public void MakeSound()
    {
        Console.WriteLine("Dog barks!");
    }
}