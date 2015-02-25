using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyContainer;

namespace MvcDependencyContainer.DependencyContainer
{
    public class RegisterControllers
    {
        public static void register(IContainer container)
        {
            container.Register<MvcDependencyContainer.Controllers.HomeController, MvcDependencyContainer.Controllers.HomeController>(LifestyleType.Singleton);
        }
    }
}