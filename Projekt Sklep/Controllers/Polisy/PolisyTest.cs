using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Polisy;
using Projekt_Sklep.Models.Polisy;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class PolisyControllerTests
    {
        private readonly PolisyController _controller;

        public PolisyControllerTests()
        {
            _controller = new PolisyController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Polisy.Polisy>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var polisyList = okResult?.Value as List<Models.Polisy.Polisy>;

            Assert.NotNull(polisyList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Polisy.Polisy>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreatePolisyEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newPolisy = new Models.Polisy.Polisy
            {
                // Set properties for the new Polisy
            };

            // Act
            var result = _controller.CreateKlientEntity(newPolisy);

            // Assert
            Assert.IsType<ActionResult<Models.Polisy.Polisy>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreatePolisyEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Polisy.Polisy invalidPolisy = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidPolisy);

            // Assert
            Assert.IsType<ActionResult<Models.Polisy.Polisy>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeletePolisyEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeletePolisy(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeletePolisyEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeletePolisy(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CzyAktywna_ReturnsFalse_WhenPolisyIsActive()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.czyAktywna(new Guid("a0d0cb98-04bf-4078-b563-32fdb379c62c"));

            // Assert
            Assert.False(result);
        }

       
    }
}
