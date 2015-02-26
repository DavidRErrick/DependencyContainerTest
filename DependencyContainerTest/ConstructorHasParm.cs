using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyContainerTest
{
    class ConstructorHasParm : IConstructorHasParm
    {
        readonly IRepository1 injected;

        public ConstructorHasParm(IRepository1 consturctorParm)
        {
            injected = consturctorParm;
        }
        public string getMessage()
        {
            return ("From construcorHasParm + plus injected name: " + injected.getName());
        }
    }
}
