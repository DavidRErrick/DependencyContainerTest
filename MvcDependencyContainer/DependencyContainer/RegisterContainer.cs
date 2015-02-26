using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyContainer;

namespace MvcDependencyContainer.DependencyContainer
{
    public static class RegisterContainer
    {
        static IContainer myContainer;
        public static void registerContainer(IContainer container)
        {
            myContainer = container;
        }
        public static IRepository Resolve<IRepository>()
        {
            return myContainer.Resolve<IRepository>();
        }
    }
}