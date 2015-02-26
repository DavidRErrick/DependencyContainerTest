using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyContainer
{
    public enum LifestyleType
    {
        Transient,
        Singleton

    }

    [Serializable]
    public class ContainerRegistrationException : Exception
    {
        public ContainerRegistrationException() { }
        public ContainerRegistrationException(string message) : base(message) { }
        public ContainerRegistrationException(string message, Exception inner) : base(message, inner) { }
        protected ContainerRegistrationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    public interface IContainer
    {
        void Register<IRepository, Repository>(LifestyleType lifesytle=LifestyleType.Transient);
        IRepository Resolve<IRepository>();
        object Resolve(Type IRepositoryType);
        object createInstanceFromType(Type typeToCreate);
    }
}
