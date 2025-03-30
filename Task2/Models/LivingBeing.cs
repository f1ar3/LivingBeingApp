
namespace Task2.Models
{
    public abstract class LivingBeing
    {
        public int Speed { get; protected set; }

        public int MaxSpeed { get; protected set; }
        
        public abstract void Move();
        
        public abstract void Stop();
    }
    
}