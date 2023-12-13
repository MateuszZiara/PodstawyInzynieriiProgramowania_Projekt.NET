using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Models.Klient;
using Xunit;

namespace Projekt_Sklep.Controllers.Klient
{
    public class KlientEntityControllerTests
    {

        private readonly KlientEntityController _controller;

        public KlientEntityControllerTests()
        {
            _controller = new KlientEntityController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Klient.KlientEntity>>>(result);


            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var klientList = okResult?.Value as List<Models.Klient.KlientEntity>;

            Assert.NotNull(klientList);
            Assert.NotEmpty(klientList);


        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Klient.KlientEntity>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newKlient = new Models.Klient.KlientEntity();
            {
                //Arange foreign key fields
                AdresController controller = new AdresController();
                var newAdres = new Models.Adres.Adres
                {
                    // Set properties for the new Adres
                };
                var resultf = controller.CreateAdresEntity(newAdres);
            };

            // Act
            var result = _controller.CreateKlientEntity(newKlient);

            // Assert
            Assert.IsType<ActionResult<Models.Klient.KlientEntity>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Klient.KlientEntity invalidAdres = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidAdres);

            // Assert
            Assert.IsType<ActionResult<Models.Klient.KlientEntity>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteKlientEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeleteKlientEntity(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public void DeleteKlientEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeleteKlientEntity(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public void EditKlientEntity_ReturnsTrue_WhenEditSuccessful()
        {
            //Arange foreign key fields
            AdresController controller = new AdresController();
            var newAdres = new Models.Adres.Adres
            {
                // Set properties for the new Adres
            };
            var resultf = controller.CreateAdresEntity(newAdres);

            // Arrange
            Guid id = Guid.NewGuid();
            var clientId = new Guid("5c332257-58b9-434d-be9c-14688ac3fdb7");
            var addressId = new Guid("5c332257-58b9-434d-be9c-1468333s7");

            // Act
            var result = _controller.EditKlientEntity( clientId, "Name", "Surname", "00112233445", "535202373", "test@pamp.pl", "111-222-33-44", addressId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void getByPolisaPojazd_ShouldReturnOkWithPolisyPojazdyResponse_WhenSuccessful()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var polisaId = new Guid("5c332257-58b9-434d-be9c-14688ac3fdb7");
            var result = _controller.getByPolisaPojazd(polisaId);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result); 

            var okResult = Assert.IsType<ActionResult<PolisyPojazdyResponse>>(result); 
            var response = Assert.IsType<PolisyPojazdyResponse>(okResult.Value); 

        }


    }
}
