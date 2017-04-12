using System;
using System.Collections.Generic;
using System.Reflection;
using FactoryMethod2.Autos;
using FactoryMethod2.Autos.BMW;

namespace FactoryMethod2.Factory
{
    public class BMWFactory : IAutoFactory
    {
        public IAutomobile CreateSportsCar()
        {
            return new BMWM3();
        }

        public IAutomobile CreateLuxuryCar()
        {
            return new BMW740i(); 
        }

        public IAutomobile CreateEconomyCar()
        {
            return new BMW328i();
        }
    }
}
