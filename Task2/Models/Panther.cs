using System;

namespace Task2.Models;

public class Panther : LivingBeing
{
    public Panther()
    {
        MaxSpeed = 100; 
    }
        
    public override void Move()
    {
        if (Speed < MaxSpeed)
            Speed += 10;
    }
        
    public override void Stop()
    {
        if (Speed > 0)
            Speed -= 10;
    }
        
    public void MakeSound()
    {
        Console.WriteLine("Panther roars!");
    }
        
    public void ClimbTree()
    {
        Console.WriteLine("Panther climbed the tree!");
    }
}