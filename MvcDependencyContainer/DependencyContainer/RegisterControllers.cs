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
           
            // it this version not necessary to register controllers - only the controller constructor argumnets.
           
            container.Register<IAboutHelper, AboutHelper>(LifestyleType.Singleton);
        }
    }
}