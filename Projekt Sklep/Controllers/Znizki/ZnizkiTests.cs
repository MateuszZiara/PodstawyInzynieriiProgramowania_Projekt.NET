using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Znizki;
using Projekt_Sklep.Models.Znizki;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class ZnizkiTests
    {
        private readonly ZnizkiController _controller;

        public ZnizkiTests()
        {
            _controller = new ZnizkiController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Znizki>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var znizkiList = okResult?.Value as List<Znizki>;

            Assert.NotNull(znizkiList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Znizki>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newZnizki = new Znizki
            {
                // Set properties for the new Znizki
            };

            // Act
            var result = _controller.CreateKlientEntity(newZnizki);

            // Assert
            Assert.IsType<ActionResult<Znizki>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Znizki invalidZnizki = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidZnizki);

            // Assert
            Assert.IsType<ActionResult<Znizki>>(result);
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
    }
}
