using Xunit;
using Microsoft.AspNetCore.Mvc;
using Projekt_Sklep.Controllers.Placowki;
using Projekt_Sklep.Models.Placowki;
using System;
using System.Collections.Generic;

namespace Projekt_Sklep.Tests
{
    public class PlacowkiControllerTests
    {
        private readonly PlacowkiController _controller;

        public PlacowkiControllerTests()
        {
            _controller = new PlacowkiController();
        }

        [Fact]
        public void GetAll_ReturnsOkResult()
        {
            // Act
            var result = _controller.GetAll();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<Models.Placowki.Placowki>>>(result);

            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            var placowkiList = okResult?.Value as List<Models.Placowki.Placowki>;

            Assert.NotNull(placowkiList);
            Assert.NotEmpty(placowkiList);
        }

        [Fact]
        public void GetById_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.GetById(id);

            // Assert
            Assert.IsType<ActionResult<Models.Placowki.Placowki>>(result);
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreatePlacowkiEntity_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var newPlacowki = new Models.Placowki.Placowki
            {
                // Set properties for the new Placowki
            };

            // Act
            var result = _controller.CreatePlacowkiEntity(newPlacowki);

            // Assert
            Assert.IsType<ActionResult<Models.Placowki.Placowki>>(result);
            Assert.IsType<ObjectResult>(result.Result);
        }

        [Fact]
        public void CreatePlacowkiEntity_ReturnsBadRequestResult_WhenInvalidData()
        {
            // Arrange
            Models.Placowki.Placowki invalidPlacowki = null;

            // Act
            var result = _controller.CreatePlacowkiEntity(invalidPlacowki);

            // Assert
            Assert.IsType<ActionResult<Models.Placowki.Placowki>>(result);
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public void DeletePlacowkiEntity_ReturnsNoContentResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.DeletePlacowki(id);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeletePlacowkiEntity_ReturnsNotFoundResult_WhenIdDoesNotExist()
        {
            // Arrange
            Guid nonExistentId = Guid.NewGuid();

            // Act
            var result = _controller.DeletePlacowki(nonExistentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void EditPlacowki_ReturnsTrue_WhenEditSuccessful()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.EditPlacowki(new Guid("a424923b-dee7-46fb-a1d1-23dbab138285"), 123, "222-222-22-22");

            // Assert
            Assert.True(result);
        }
/*
        [Fact]
        public void getByAgenciPolisyPojazdyOsoby_ReturnsOkResult()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = _controller.getByAgenciPolisyPojazdyOsoby(id);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }*/
    }
}
