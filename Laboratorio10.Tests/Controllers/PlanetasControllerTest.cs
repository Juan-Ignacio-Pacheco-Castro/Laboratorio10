using System.Web.Mvc;
using Laboratorio10.Controllers;
using Laboratorio10.Models;
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

        [TestMethod]
        public void EditarPlanetaConIdNoExistenteRedirctToLP() {
            //Arrange
            int idInvalido = -1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            RedirectToRouteResult vista = planetasController.editarPlaneta(idInvalido) as RedirectToRouteResult;

            //Assert
            Assert.AreEqual("listadoDePlanetas", vista.RouteValues["action"]);
        }

        [TestMethod]
        public void EditarPlanetaElModeloEnviadoEsCorrecto() {
            //Arrange
            int id = 1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            ViewResult vista = planetasController.editarPlaneta(id) as ViewResult;
            PlanetaModel planeta = vista.Model as PlanetaModel;

            //Assert
            Assert.IsNotNull(planeta);
            Assert.AreEqual(0, planeta.numeroAnillos);
            Assert.AreEqual("Tierra", planeta.nombre);
        }

        [TestMethod]
        public void ListadoDePlanetasCantidadDePlanetasEsCorrecta() {
            //Arrange
            int numeroPlanetas = 19;
            PlanetasController planetasController = new PlanetasController();

            //Act 
            ViewResult vista = planetasController.listadoDePlanetas() as ViewResult;

            //Assert
            Assert.AreEqual(numeroPlanetas, vista.ViewBag.planetas.Count);
        }

        [TestMethod]
        public void AccessoCorrectoAlArchivo() {
            //Arrange 
            int id = 1;
            PlanetasController planetasController = new PlanetasController();

            //Act
            FileResult fileResult = planetasController.accederArchivo(id);

            //Assert
            Assert.IsNotNull(fileResult);
            Assert.AreEqual("image/jpeg", fileResult.ContentType);
        }
    }
}
