using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyContainer;
using MvcDependencyContainer.Models;

namespace MvcDependencyContainer.DependencyContainer
{
    public class RegisterControllers
    {
        public static void register(IContainer container)
        {
            // not necessary to register controller with default constructor - code will work with or without following line:
            //container.Register<MvcDependencyContainer.Controllers.AccountController, MvcDependencyContainer.Controllers.AccountController>();
            container.Register<MvcDependencyContainer.Controllers.HomeController, MvcDependencyContainer.Controllers.HomeController>();
            container.Register<IAboutHelper, AboutHelper>(LifestyleType.Singleton);
        }
    }
}