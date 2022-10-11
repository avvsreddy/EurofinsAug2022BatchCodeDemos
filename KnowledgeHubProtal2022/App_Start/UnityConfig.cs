using KnowledgeHubProtal2022.Models.Data;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace KnowledgeHubProtal2022
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            container.RegisterType<ICatagoriesRepository, CatagoriesRepository>();
            container.RegisterType<IArticlesRepository, DummyArticlesRepo>();
        }
    }
}