using System.Web.Mvc;
using Laboratorio10.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestLab10.Tests.Controllers {
    [TestClass]
    public class PlanetasControllerTest {
        [TestMethod]
        public void TestCrearPlanetaViewResultNotNull() {
            // Arrange
            PlanetasController planetasController = new PlanetasController();

            //Act
            ActionResult vista = planetasController.crearPlaneta();

            //Assert 
            Assert.IsNotNull(vista);
        }
    }
}
