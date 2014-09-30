using System.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UtilityComponent.Unity
{
    /// <summary>
    /// This class handles the configuration of the Dependeny injection functionality using Unity application block from EntLib
    /// </summary>
    public sealed class Container
    {
        private static readonly IUnityContainer container = new UnityContainer();

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        public static IUnityContainer UnityContainer
        {
            get
            {
                return container;
            }
        }
    }
}
