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
        public void register_and_resolve()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>();
            IRepository1 testobject = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject.getName());
            Assert.IsInstanceOf<Repository1>(testobject);    
        }
        [Test]
        public void register_and_resolve_withconstructorParm()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>();
            testcontainer.Register<IConstructorHasParm, ConstructorHasParm>();
            IConstructorHasParm testobject = testcontainer.Resolve<IConstructorHasParm>();
            System.Console.WriteLine(testobject.getMessage());
            Assert.IsInstanceOf<ConstructorHasParm>(testobject);
        }
        [Test]
        public void throw_if_not_registered()
        {
            ContainerRegistrationException ex=Assert.Throws<ContainerRegistrationException>(
                      new TestDelegate(NotRegisteredMethod)
                      );
            System.Console.WriteLine(ex.Message);
        }
        void NotRegisteredMethod()
        {
            CustomContainer testcontainer = new CustomContainer();
            IRepository1 testobject = testcontainer.Resolve<IRepository1>();

        }
        [Test]
        public void throw_if_registered_twice()
        {
            ContainerRegistrationException ex = Assert.Throws<ContainerRegistrationException>(
                     RegisteredTwiceMethod
                      );
            System.Console.WriteLine(ex.Message);
        }
        void RegisteredTwiceMethod()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>();
            testcontainer.Register<IRepository1, Repository1>();
        }
        [Test]
        public void defalut_is_transient()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>();
            IRepository1 testobject1 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject1.getName());
            IRepository1 testobject2 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject2.getName());
            Assert.AreNotSame(testobject1, testobject2);
        }
        [Test]
        public void register_transient()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>(LifestyleType.Transient);
            IRepository1 testobject1 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject1.getName());
            IRepository1 testobject2 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject2.getName());
            Assert.AreNotSame(testobject1, testobject2);
        }
        [Test]
        public void registerSingleton()
        {
            CustomContainer testcontainer = new CustomContainer();
            testcontainer.Register<IRepository1, Repository1>(LifestyleType.Singleton);
            IRepository1 testobject1 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject1.getName());
            IRepository1 testobject2 = testcontainer.Resolve<IRepository1>();
            System.Console.WriteLine(testobject2.getName());
            Assert.AreSame(testobject1, testobject2);
        }
    }
}
