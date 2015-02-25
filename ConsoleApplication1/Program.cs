using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyContainer;
using DependencyContainerTest;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>();
            IRepository1 testobject = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject.getName());
        }
    }
}
