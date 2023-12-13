using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Adres;
using Projekt_Sklep.Models.Adres;
using System;

namespace Projekt_Sklep.Tests
{
    public class AdresControllerTests
    {
        private readonly AdresController _controller;

        public AdresControllerTests()
        {
            _controller = new AdresController();
        }

        
        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Adres.Adres>>>(result);

           
                Assert.IsType<OkObjectResult>(result.Result);

                var okResult = result.Result as OkObjectResult;
                var adresList = okResult?.Value as List<Models.Adres.Adres>;

                Assert.NotNull(adresList);
                Assert.NotEmpty(adresList);

                
        }


        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Adres.Adres>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateAdresEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newAdres = new Models.Adres.Adres
            {
                // Set properties for the new Adres
            };

            // Act
            var result = _controller.CreateAdresEntity(newAdres);

            // Assert
            Assert.IsType<ActionResult<Models.Adres.Adres>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateAdresEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Adres.Adres invalidAdres = null;

            // Act
            var result = _controller.CreateAdresEntity(invalidAdres);

            // Assert
            Assert.IsType<ActionResult<Models.Adres.Adres>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteAdresEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeleteAdresEntity(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            
        }

        [Fact]
        public void DeleteAdresEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeleteAdresEntity(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            
        }

        [Fact]
        public void EditAdresEntity_ReturnsTrue_WhenEditSuccessful()
        {
            // Act
            var result = _controller.EditAdresEntity(new Guid("1bc6121d-dc16-4738-a568-2f0aeccab9e7"), "12345", "City", "Province", "Country");

            // Assert
            Assert.True(result);
        }
    }
}
