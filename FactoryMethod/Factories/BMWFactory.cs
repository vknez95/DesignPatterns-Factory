using FactoryMethod.Autos;

namespace FactoryMethod.Factories
{
    class BMWFactory : IAutoFactory
    {
        public IAuto CreateAutomobile()
        {
            return new BMW("BMW M5 Cabriolet");
        }
    }
}