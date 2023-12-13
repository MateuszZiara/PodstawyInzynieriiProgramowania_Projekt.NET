using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Roszczenia;
using Projekt_Sklep.Models.Roszczenia;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class RoszczeniaControllerTests
    {
        private readonly RoszczeniaController _controller;

        public RoszczeniaControllerTests()
        {
            _controller = new RoszczeniaController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Roszczenia.Roszczenia>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var roszczeniaList = okResult?.Value as List<Models.Roszczenia.Roszczenia>;

            Assert.NotNull(roszczeniaList);
            
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Roszczenia.Roszczenia>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateRoszczeniaEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newRoszczenia = new Models.Roszczenia.Roszczenia
            {
                // Set properties for the new Roszczenia
            };

            // Act
            var result = _controller.CreateRoszczeniaEntity(newRoszczenia);

            // Assert
            Assert.IsType<ActionResult<Models.Roszczenia.Roszczenia>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreateRoszczeniaEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Roszczenia.Roszczenia invalidRoszczenia = null;

            // Act
            var result = _controller.CreateRoszczeniaEntity(invalidRoszczenia);

            // Assert
            Assert.IsType<ActionResult<Models.Roszczenia.Roszczenia>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeleteRoszczeniaEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeleteRoszczenia(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteRoszczeniaEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeleteRoszczenia(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
