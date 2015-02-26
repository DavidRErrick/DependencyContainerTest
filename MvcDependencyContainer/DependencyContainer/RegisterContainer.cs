using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DependencyContainer;

namespace MvcDependencyContainer.DependencyContainer
{

    public  class RegisterContainer
    {
        private static readonly IContainer instance = new CustomContainer();

        private RegisterContainer() { }

        public static IContainer Instance
        {
            get
            {
                return instance;
            }
        }
        public static IRepository Resolve<IRepository>()
        {
            return Instance.Resolve<IRepository>();
        }
    }

   
}