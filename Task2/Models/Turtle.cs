namespace Task2.Models;

public class Turtle : LivingBeing
{
    public Turtle()
    {
        MaxSpeed = 10; 
    }
        
    public override void Move()
    {
        if (Speed < MaxSpeed)
            Speed += 1;
    }
        
    public override void Stop()
    {
        if (Speed > 0)
            Speed -= 1;
    }
}