using System.Web.Http;
using APFTestingModel;
using Microsoft.Practices.Unity;
using System.Web.Mvc;

namespace APFTestingUI
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            
            container.RegisterType<IFacade, Facade>(new HierarchicalLifetimeManager());
            
            return container;
        }
    }
}