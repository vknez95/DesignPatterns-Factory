using FactoryMethod.Autos;

namespace FactoryMethod.Factories
{
    public interface IAutoFactory
    {
        IAuto CreateAutomobile();
    }
}