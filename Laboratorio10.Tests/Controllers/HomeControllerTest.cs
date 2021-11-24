using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratorio10.Controllers;
using System.Web.Mvc;

namespace UnitTestLab10.Tests.Controllers {
    [TestClass]
    public class HomeControllerTest {
        [TestMethod]
        public void ContactSendValuesTest() {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            ViewResult vista = homeController.Contact() as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("Contact", vista.ViewName);
            Assert.AreEqual("Your contact page.", vista.ViewBag.Message);
            Assert.AreEqual(1, vista.ViewBag.ValorParaTest);
        }

        [TestMethod]
        public void TestIndexViewResultNotNull() {
            //Arragne
            HomeController homeController = new HomeController();

            //Act
            ViewResult vista = homeController.Index() as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("Index", vista.ViewName);
        }
        [TestMethod]
        public void TestAboutViewResultNotNull() {
            //Arragne
            HomeController homeController = new HomeController();

            //Act
            ViewResult vista = homeController.About() as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("About", vista.ViewName);
            Assert.AreEqual("Your application description page.", vista.ViewBag.Message);
        }
    }
}
