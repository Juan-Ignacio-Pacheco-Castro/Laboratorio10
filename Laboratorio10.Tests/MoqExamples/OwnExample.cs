using System.Web.Mvc;
using Laboratorio10.Controllers;
using Laboratorio10.Handlers;
using Laboratorio10.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebApplication2.Tests.MoqExamples
{
    [TestClass]
    public class OwnExample {
        [TestMethod]
        public void TestCrearPlanetaFromPlanetasController() {
            //Act
            var planetasHandlerMock = new Mock<PlanetasHandler>();
            PlanetaModel planeta = new PlanetaModel();
            planeta.nombre = "Test-Planeta-Ejemplo-Propio";
            planetasHandlerMock.Setup(planetasHandlerMethod => planetasHandlerMethod.crearPlaneta(planeta)).Returns(true);

            //Arrange
            PlanetasController planetasController = new PlanetasController(planetasHandlerMock.Object);
            ViewResult vista = planetasController.crearPlaneta(planeta) as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("El planeta " + planeta.nombre + " fue creado con éxito :)", vista.ViewBag.Message);
        }
    }
}
