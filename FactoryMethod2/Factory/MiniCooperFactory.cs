using System;
using FactoryMethod2.Autos;
using FactoryMethod2.Autos.Mini;

namespace FactoryMethod2.Factory
{
    public class MiniCooperFactory : IAutoFactory
    {
        public IAutomobile CreateSportsCar()
        {
            var mini = new MiniCooper();

            mini.AddSportPackage();

            return mini;
        }

        public IAutomobile CreateLuxuryCar()
        {
            var mini = new MiniCooper();
            
            mini.AddLuxuryPackage();
            
            return mini;
        }

        public IAutomobile CreateEconomyCar()
        {
            return new MiniCooper();       
        }
    }
}
