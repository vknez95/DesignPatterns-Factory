using FactoryMethod.Autos;

namespace FactoryMethod.Factories
{
    class MiniCooperFactory : IAutoFactory
    {
        public IAuto CreateAutomobile()
        {
            var mini = new MiniCooper();
                mini.SetName("Mini Cooper S");
            
            return mini;
        }
    }
}