using System;
using System.IO;
using System.Linq;
using System.Reflection;
using FactoryMethod.Autos;
using FactoryMethod.Factories;
using Microsoft.Extensions.Configuration;
using Utility;

namespace FactoryMethod
{
    class Program
    {
        public static IConfigurationRoot Configuration =>
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main()
        {
            IAutoFactory autoFactory = LoadFactory();

            IAuto car = autoFactory.CreateAutomobile();

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
    }
}