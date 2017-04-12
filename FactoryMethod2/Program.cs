using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FactoryMethod2.Factory;
using Microsoft.Extensions.Configuration;
using Utility;

namespace FactoryMethod2
{
    class Program
    {
        public static IConfigurationRoot Configuration =>
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
            
        static void Main(string[] args)
        {
            IAutoFactory factory = LoadFactory();

            PrintHeader("SPORTS CAR");
            var car = factory.CreateSportsCar();
            car.TurnOn();
            car.TurnOff();

            PrintHeader("LUXURY CAR");
            car = factory.CreateLuxuryCar();
            car.TurnOn();
            car.TurnOff();

            PrintHeader("ECONOMY CAR");
            car = factory.CreateEconomyCar();
            car.TurnOn();
            car.TurnOff();
        }

        static IAutoFactory LoadFactory()
        {
            string factoryName = Configuration["AutoFactory"];

            Type factoryType =
                Assembly
                .GetEntryAssembly()
                .GetTypes()
                .Where(type => type.Name == factoryName)
                .LazyDefaultIfEmpty(() => typeof(BMWFactory))
                .Single();

            return
                Activator
                .CreateInstance(factoryType) as IAutoFactory;
        }

        static void PrintHeader(string title)
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++ {0} ++++++++++++++++++", title);
        }
    }
}
