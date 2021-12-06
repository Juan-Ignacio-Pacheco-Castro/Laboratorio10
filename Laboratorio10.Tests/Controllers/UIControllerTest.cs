using System;
using System.Threading;
using System.Web.Mvc;
using Laboratorio10.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITestLab10.Tests.Controllers {
    [TestClass]
    public class UIControllerTest {
        [TestMethod]
        public void TestListPlanetsViewFirstMustBeEarth() {
            //Arrange
            HomeController homeController = new HomeController();

            //Act
            ViewResult vista = homeController.Contact() as ViewResult;
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://localhost:44364/Planetas/listadoDePlanetas");

            Thread.Sleep(2000);
            webDriver.Quit();

            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("Contact", vista.ViewName);
            Assert.AreEqual("Your contact page.", vista.ViewBag.Message);
            Assert.AreEqual(1, vista.ViewBag.ValorParaTest);
        }

        /*[TestMethod]
        public void TestSearchStreetFighterVThenVerifyStreetFighterVIsDisplayed() {
            int waitingTime = 2000;
            By googleSearchBar = By.Name("q");
            By googleSearchButton = By.Name("btnK");
            By googleLuckyButton = By.Name("btnI");
            By googleResultText = By.XPath(".//h2//span[text()='Street Fighter V']");
            By googleLogo = By.TagName("img");

            IWebDriver webDriver = new ChromeDriver();

            webDriver.Navigate().GoToUrl("https://www.google.co.uk");

            webDriver.FindElement(googleSearchBar).SendKeys("Street Fighter V");

            webDriver.Manage().Window.Maximize();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleLogo).Click();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchBar).Submit();

            Thread.Sleep(waitingTime);

            var actualResultText = webDriver.FindElement(googleResultText);

            Assert.IsTrue(actualResultText.Text.Equals("Street Fighter V"));

            webDriver.Quit();
        }*/
    }
}
