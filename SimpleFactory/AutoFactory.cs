using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SimpleFactory.Autos;
using Utility;

namespace SimpleFactory
{
    public class AutoFactory
    {
        Dictionary<string, Type> autos;

        public AutoFactory()
        {
            LoadTypesICanReturn();
        }

        public IAuto CreateInstance(string carName)
        {
            return
                Activator
                .CreateInstance(GetTypeToCreate(carName)) as IAuto;
        }

        Type GetTypeToCreate(string carName)
        {
            Type carType = null;

            if (autos.TryGetValue(carName, out carType))
                return carType;
            else
                return typeof(NullAuto);
        }

        void LoadTypesICanReturn()
        {
            autos = new Dictionary<string, Type>();

            Assembly
                .GetEntryAssembly()
                .GetTypes()
                .ForEach(type =>
                {
                    if (type
                        .GetInterfaces()
                        .Where(i => i.Name == typeof(IAuto).Name)
                        .Any())
                        autos.Add(type.Name, type);
                });
        }
    }
}