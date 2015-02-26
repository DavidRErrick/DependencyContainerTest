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
            try
            {
                return container.Resolve(controllerType) as Controller;
            }
            catch (ContainerRegistrationException )
            {
                // if not registered used default behavior - ie for contrller with defalut constructor
                return base.GetControllerInstance(requestContext, controllerType);
            }
        }
     }
}