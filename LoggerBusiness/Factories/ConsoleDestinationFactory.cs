using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace LoggerBusiness.Factories
{
    public static class ConsoleDestinationFactory
    {
        static IUnityContainer container;

        static ConsoleDestinationFactory()
        {
            InitContainers();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        private static void InitContainers()
        {
            container = new UnityContainer();

            // Use SingletonLifeTimeManager in case you want to implement a singleton
            container.RegisterType<IDestinationStrategy, ConsoleDestination>(new SingletonLifetimeManager());

        }


    }
}
