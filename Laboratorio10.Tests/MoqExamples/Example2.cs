using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace WebApplication2.Tests.MoqExamples {
    public interface IDogsUpdate {
        bool Update(string breed);
    }
    
    public class HuskyController : Controller {
        protected IDogsUpdate updateDogsService;
        public HuskyController(IDogsUpdate updateDogsService) {
            this.updateDogsService = updateDogsService;
        }
        public ActionResult UpdateDog(string breed) {
            var result = this.updateDogsService.Update(breed);
            //Add some logic here
            if (breed == "husky") {
                ViewBag.Message = "The breed is Husky";
                return View("UpdateDogHusky");
            }
            return null;
        }
    }

    [TestClass]
    public class Example2 {
        [TestMethod]
        public void TestUpdateDogFromDogsController() {
            //Act
            var huskyServiceMock = new Mock<IDogsUpdate>();
            huskyServiceMock.Setup(huskyService => huskyService.Update("husky")).Returns(true);

            //Arrange
            var huskyController = new HuskyController(huskyServiceMock.Object);
            ViewResult vista = huskyController.UpdateDog("husky") as ViewResult;

            //Assert
            Assert.IsNotNull(vista);
            Assert.AreEqual("The breed is Husky", vista.ViewBag.Message);
        }
    }
}
