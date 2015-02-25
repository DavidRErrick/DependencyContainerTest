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
            return container.Resolve(controllerType) as Controller;
        }
     }
}