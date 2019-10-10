using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Controllers;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var controller = new HomeController();

            Assert.IsNotNull(controller);
        }
    }
}
