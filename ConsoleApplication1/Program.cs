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
            testcontainer.Register<IRepository1, Repository1>(LifestyleType.Singleton);
            IRepository1 testobject1 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject1.getName());
            IRepository1 testobject2 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject2.getName());
           
        }
    }
}
