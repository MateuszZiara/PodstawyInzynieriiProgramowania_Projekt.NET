using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.WyplatyiSzkody;
using Projekt_Sklep.Models.WyplatyiSzkody;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class WyplatyiSzkodyTests
    {
        private readonly WyplatyiSzkodyController _controller;

        public WyplatyiSzkodyTests()
        {
            _controller = new WyplatyiSzkodyController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<WyplatyiSzkody>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var wyplatyiSzkodyList = okResult?.Value as List<WyplatyiSzkody>;

            Assert.NotNull(wyplatyiSzkodyList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<WyplatyiSzkody>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newWyplatyiSzkody = new WyplatyiSzkody
            {
                // Set properties for the new WyplatyiSzkody
            };

            // Act
            var result = _controller.CreateKlientEntity(newWyplatyiSzkody);

            // Assert
            Assert.IsType<ActionResult<WyplatyiSzkody>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateKlientEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            WyplatyiSzkody invalidWyplatyiSzkody = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidWyplatyiSzkody);

            // Assert
            Assert.IsType<ActionResult<WyplatyiSzkody>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteKlientEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeleteWyplatyiSzkody(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteKlientEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeleteWyplatyiSzkody(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
