using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyContainerTest
{
    public class Repository1 : IRepository1
    {
        public string getName()
        {
            return "Repositrory1";
        }
    }
}
