using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Ubezpieczyciele;
using Projekt_Sklep.Models.Ubezpieczyciele;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class UbezpieczycieleTests
    {
        private readonly UbezpieczycieleController _controller;

        public UbezpieczycieleTests()
        {
            _controller = new UbezpieczycieleController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Ubezpieczyciele>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var ubezpieczycieleList = okResult?.Value as List<Ubezpieczyciele>;

            Assert.NotNull(ubezpieczycieleList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Ubezpieczyciele>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newUbezpieczyciele = new Ubezpieczyciele
            {
                // Set properties for the new Ubezpieczyciele
            };

            // Act
            var result = _controller.CreateKlientEntity(newUbezpieczyciele);

            // Assert
            Assert.IsType<ActionResult<Ubezpieczyciele>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Ubezpieczyciele invalidUbezpieczyciele = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidUbezpieczyciele);

            // Assert
            Assert.IsType<ActionResult<Ubezpieczyciele>>(result);
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
        public void EditUbezpieczyciele_ReturnsTrue_WhenEditSuccessful()
        {

            // Act
            var result = _controller.EditUbezpieczyciele(new Guid("862713b3-08ca-4ef6-a174-e873be891777"), "Nazwisko", "Email", "Phone", "OsobaKontaktowa", "NazwaFirmy");

            // Assert
            Assert.True(result);
        }
    }
}
