using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Pojazdy;
using Projekt_Sklep.Models.Pojazdy;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projekt_Sklep.Tests
{
    public class PojazdyControllerTests
    {
        private readonly PojazdyController _controller;

        public PojazdyControllerTests()
        {
            _controller = new PojazdyController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Pojazdy.Pojazdy>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var pojazdyList = okResult?.Value as List<Models.Pojazdy.Pojazdy>;

            Assert.NotNull(pojazdyList);
            Assert.NotEmpty(pojazdyList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Pojazdy.Pojazdy>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreatePojazdyEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newPojazdy = new Models.Pojazdy.Pojazdy
            {
                // Set properties for the new Pojazdy
            };

            // Act
            var result = _controller.CreateKlientEntity(newPojazdy);

            // Assert
            Assert.IsType<ActionResult<Models.Pojazdy.Pojazdy>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreatePojazdyEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Pojazdy.Pojazdy invalidPojazdy = null;

            // Act
            var result = _controller.CreateKlientEntity(invalidPojazdy);

            // Assert
            Assert.IsType<ActionResult<Models.Pojazdy.Pojazdy>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeletePojazdyEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeletePojazdy(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeletePojazdyEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeletePojazdy(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditPojazdy_ReturnsTrue_WhenEditSuccessful()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.EditPojazdy(true, new Guid("db721749-08bb-44ea-898e-c96e0f6d1f1f"), 123, "Brand", "Model", 2022);

            // Assert
            Assert.True(result);
        }
    }
}
