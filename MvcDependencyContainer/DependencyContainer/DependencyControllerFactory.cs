using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DependencyContainer;

namespace MvcDependencyContainer.DependencyContainer
{
    public class DependencyControllerFactory : DefaultControllerFactory

    {
        readonly IContainer container;
        public DependencyControllerFactory(IContainer container)
        {
            this.container = container;
        }
    

        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
                // in this version controllers are not registered, but constructed in the container using 
                // registered controller parms if any
                // 
                // normal operations should not throw exceptions.
                return container.createInstanceFromType(controllerType) as Controller;
          
        }
     }
}