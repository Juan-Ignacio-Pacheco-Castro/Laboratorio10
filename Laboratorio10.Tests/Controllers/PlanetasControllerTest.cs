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

        [TestMethod]
        public void TestCrearPlanetaViewResult() {
            //Arrange
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.crearPlaneta() as ViewResult;

            //Assert
            Assert.AreEqual("crearPlaneta", vista.ViewName);
        }

        [TestMethod]
        public void EditarPlanetaIdValidoVistaNoNula() {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void EditarPlanetaValidoModeloRetornadoNoEsNulo() {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;

            //Assert
            Assert.IsNotNull(vista.Model);
        }
    }
}
