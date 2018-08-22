using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.Resolution;

namespace LoggerBusiness.Factories
{
    public static class LoggerFactory
    {
        static IUnityContainer container;

        static LoggerFactory()
        {
            InitContainers();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        private static Dictionary<string, IDestinationStrategy>  GetDestinations()
        {
            return new Dictionary<string, IDestinationStrategy>()
                        {
                            { DestinationTypes.Console, ConsoleDestinationFactory.Resolve<IDestinationStrategy>()},
                            { DestinationTypes.File,FileDestinationFactory.Resolve<IDestinationStrategy>() },
                            { DestinationTypes.DataBase,  DataBaseDestinationFactory.Resolve<IDestinationStrategy>() }

                        };
        }
        private static void InitContainers()
        {
            container = new UnityContainer();

            // TODO: Implement dependencies load from a XML File. (Unity.conf)
            Dictionary<string, IDestinationStrategy> destinations = GetDestinations();
            container.RegisterInstance<string>("destinationType");
            container.RegisterInstance<Dictionary<string, IDestinationStrategy>>("destinationDictionary", destinations);
            container.RegisterType<Dictionary<string, IDestinationStrategy>>("_destinationDictionary", new InjectionConstructor(destinations));
            container.RegisterType<ILogger, Logger>(new SingletonLifetimeManager(),new InjectionConstructor(container.Resolve<Dictionary<string, IDestinationStrategy>>("_destinationDictionary")));
        }


    }
}
