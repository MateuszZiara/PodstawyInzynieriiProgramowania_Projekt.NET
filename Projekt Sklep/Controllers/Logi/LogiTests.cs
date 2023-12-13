using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Logi;
using Projekt_Sklep.Models.Logi;
using System;
using System.Collections.Generic;
using Logi = Projekt_Sklep.Controllers.Logi.Logi;

namespace Projekt_Sklep.Tests
{
    public class LogiControllerTests
    {
        private readonly Logi _controller;

        public LogiControllerTests()
        {
            _controller = new Logi();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Logi.Logi>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var logiList = okResult?.Value as List<Models.Logi.Logi>;

            Assert.NotNull(logiList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Logi.Logi>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateLogiEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newLogi = new Models.Logi.Logi
            {
                // Set properties for the new Logi
            };

            // Act
            var result = _controller.CreateKlientEntity(newLogi);

            // Assert
            Assert.IsType<ActionResult<Models.Logi.Logi>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateLogiEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Logi.Logi invalidLogi = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidLogi);

            // Assert
            Assert.IsType<ActionResult<Models.Logi.Logi>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteLogiEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeleteLogi(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteLogiEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeleteLogi(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
