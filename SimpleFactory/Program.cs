using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleFactory.Autos;

namespace SimpleFactory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();

            string carName = "";
            if (args.Count() != 0)
                carName = args[0];

            if (getAvailableAutos().Where(auto => auto == carName).Any())
            {
                AutoFactory factory = new AutoFactory();

                IAuto car = factory.CreateInstance(carName);

                car.TurnOn();
                car.TurnOff();
            }
            else
            {
                Console.WriteLine("Choose one of the following autos:\n");

                foreach (string auto in getAvailableAutos())
                {
                    Console.WriteLine(auto);
                }
            }

            Console.WriteLine();
        }

        private static IEnumerable<string> getAvailableAutos()
        {
            return
                new string[] { "BMW335Xi", "MiniCooper", "Yugo" };
        }
    }
}
