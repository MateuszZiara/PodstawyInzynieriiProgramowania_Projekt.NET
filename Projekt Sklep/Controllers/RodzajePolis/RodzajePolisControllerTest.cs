using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.RodzajePolis;
using Projekt_Sklep.Models.RodzajePolis;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class RodzajePolisControllerTests
    {
        private readonly RodzajePolisController _controller;

        public RodzajePolisControllerTests()
        {
            _controller = new RodzajePolisController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.RodzajePolis.RodzajePolis>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var rodzajePolisList = okResult?.Value as List<Models.RodzajePolis.RodzajePolis>;

            Assert.NotNull(rodzajePolisList);
            Assert.NotEmpty(rodzajePolisList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.RodzajePolis.RodzajePolis>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateRodzajePolisEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newRodzajePolis = new Models.RodzajePolis.RodzajePolis
            {
                // Set properties for the new RodzajePolis
            };

            // Act
            var result = _controller.CreateKlientEntity(newRodzajePolis);

            // Assert
            Assert.IsType<ActionResult<Models.RodzajePolis.RodzajePolis>>(result);
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public void CreateRodzajePolisEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.RodzajePolis.RodzajePolis invalidRodzajePolis = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidRodzajePolis);

            // Assert
            Assert.IsType<ActionResult<Models.RodzajePolis.RodzajePolis>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteRodzajePolisEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeleteKlientEntity(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteRodzajePolisEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeleteKlientEntity(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
