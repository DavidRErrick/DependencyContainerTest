using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DependencyContainer;

namespace DependencyContainerTest
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void registertest()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>();
            IRepository1 testobject = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject.getName());

        }
 
    }
}
