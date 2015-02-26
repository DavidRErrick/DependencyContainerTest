using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace DependencyContainer
{
    public class CustomContainer : IContainer
    {
       
        class RepositryAndLifstyle
        {
            public RepositryAndLifstyle(Type repoistoryType, LifestyleType lifestyle)
            {
                this.repoistoryType = repoistoryType;
                this.lifestyle = lifestyle;
                this.singleton = null;
            }
            public Type            repoistoryType{ get;private set;}
            public LifestyleType   lifestyle{ get;private set;} 
            public object           singleton{ get; set;}   // place for singleton if lifestyle Singleton
        }

        private Dictionary<Type, RepositryAndLifstyle> containerMap = new Dictionary<Type, RepositryAndLifstyle>();

       
     

        public void Register<IRepository, Repository>(LifestyleType lifesytle=LifestyleType.Transient)
        {
            if (containerMap.ContainsKey(typeof(IRepository) ))
            {
                throw new ContainerRegistrationException(string.Format("Type {0} already registered.",typeof(IRepository).FullName));
            }
            containerMap.Add(typeof(IRepository),new RepositryAndLifstyle(typeof(Repository),lifesytle));
        }



        public IRepository Resolve<IRepository>()
        {
            return (IRepository)Resolve(typeof(IRepository));
        }

        public object Resolve(Type IRepositoryType)
        {
            // Find the registered type 
            if (!containerMap.ContainsKey(IRepositoryType))
                throw new ContainerRegistrationException(string.Format("Can't resolve {0}. Type is not registed.", IRepositoryType.FullName));

            RepositryAndLifstyle repositoryTypeAndLifstyle = containerMap[IRepositoryType];

            // check if Singleton type and the singleton was created
            if (repositoryTypeAndLifstyle.lifestyle == LifestyleType.Singleton && repositoryTypeAndLifstyle.singleton != null)
                return repositoryTypeAndLifstyle.singleton;


            // Try to construct the object
            // Step-1: find the constructor - using the first constructor if more than one
            ConstructorInfo ctorInfo = repositoryTypeAndLifstyle.repoistoryType.GetConstructors().First();

            // Step-2: find the parameters for the constructor and try to resolve those
            // all parameter must resolve for this to work

            List<ParameterInfo> paramsInfo = ctorInfo.GetParameters().ToList();
            List<object> resolvedParams = new List<object>();
            foreach (ParameterInfo param in paramsInfo)
            {
                Type t = param.ParameterType;
                object res = Resolve(t);
                resolvedParams.Add(res);
            }

            // Step-3: using reflection invoke constructor to create the object
            object retObject = ctorInfo.Invoke(resolvedParams.ToArray());

            // save created object if Singleton type
            if (repositoryTypeAndLifstyle.lifestyle == LifestyleType.Singleton)
                repositoryTypeAndLifstyle.singleton = retObject;

            return retObject;
        }

    }
}
