using System;

namespace SimpleFactory.Autos
{
    public class Yugo : IAuto
    {
        public void TurnOn()
        {
            Console.WriteLine("Yugo is awake.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Yugo is asleep.");
        }
    }
}