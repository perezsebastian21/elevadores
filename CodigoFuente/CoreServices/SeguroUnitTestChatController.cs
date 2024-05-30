using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using API.Controllers;
using API.DataSchema;
using API.Services;
using Xunit;

namespace CoreServices.Test { 
    public class SeguroUnitTestChatController
    {
        [Fact]
        public async void GetAll_ReturnsAllSeguros()
        {
            // Arrange
            var seguros = new List<EV_Seguro>
            {
                new EV_Seguro { IdSeguro = 1, Nombre = "Seguro1" },
                new EV_Seguro { IdSeguro = 2, Nombre = "Seguro2" },
                new EV_Seguro { IdSeguro = 3, Nombre = "Seguro3" },
                new EV_Seguro { IdSeguro = 4, Nombre = "Seguro4" },
                new EV_Seguro { IdSeguro = 5, Nombre = "Seguro5" },
            };

            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.GetAll()).Returns(seguros);

            // Act
            var controller = new SeguroController(null, null, serviceMock.Object);
            var result = await controller.Get();

            // Assert
            var OkObjectResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            OkObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Should().BeOfType<ActionResult<IEnumerable<EV_Seguro>>>();
            var returnedSeguros = OkObjectResult.Value.Should().BeAssignableTo<IEnumerable<EV_Seguro>>().Subject;
            returnedSeguros.Should().HaveCount(5);
            returnedSeguros.Should().BeEquivalentTo(seguros);
        }
        [Fact]
        public async Task GetAll_ReturnsEmptyList()
        {
            // Arrange
            var emptyList = new List<EV_Seguro>();
            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.GetAll()).Returns(emptyList);

            // Act
            var controller = new SeguroController(null, null, serviceMock.Object);
            var result = await controller.Get();

            // Assert
            result.Should().BeOfType<ActionResult<IEnumerable<EV_Seguro>>>();

            var okObjectResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;

            var returnedSeguros = okObjectResult.Value.Should().BeAssignableTo<IEnumerable<EV_Seguro>>().Subject;
            okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            // Asegúrate de que la lista devuelta esté vacía
            returnedSeguros.Should().BeEmpty();
        }

        [Fact]
        public async void GetById_ReturnsSeguroOnSuccess()
        {
            // Arrange
            var seguro = new EV_Seguro { IdSeguro = 1, Nombre = "Seguro1" };

            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.GetByID(1)).ReturnsAsync(seguro);

            var controller = new SeguroController(null, null, serviceMock.Object);

            // Act
            var result = await controller.Get(1);

            // Assert
            result.Should().BeOfType<ActionResult<EV_Seguro>>();

            var okObjectResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);

            //var actionResult = okObjectResult.Value.Should().BeAssignableTo<EV_Seguro>().Subject;
            var actionResult = okObjectResult.Value.Should().BeOfType<EV_Seguro>().Subject;
            actionResult.Should().BeEquivalentTo(seguro, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async void GetById_ReturnsNotFoundOnNonExistingId()
        {
            // Arrange
            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.GetByID(It.IsAny<int>())).ReturnsAsync((EV_Seguro)null);

            var controller = new SeguroController(null, null, serviceMock.Object);

            // Act
            var result = await controller.Get(14); // Assuming ID 14 does not exist.

            // Assert
            result.Should().BeOfType<ActionResult<EV_Seguro>>();

            var notFoundResult = result.Result.Should().BeOfType<NotFoundResult>().Subject;
            notFoundResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async void GetByName_ReturnsSeguroOnSuccess()
        {
            // Arrange
            var seguro = new EV_Seguro { IdSeguro = 1, Nombre = "Seguro1" };

            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.GetByParam(It.IsAny<Expression<Func<EV_Seguro, bool>>>()))
                .ReturnsAsync(new List<EV_Seguro> { seguro });

            var controller = new SeguroController(null, null, serviceMock.Object);

            // Act
            var result = await controller.Get("Seguro1");

            // Assert
            var okObjectResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            var actionResult = okObjectResult.Value.Should().BeAssignableTo<IEnumerable<EV_Seguro>>().Subject;

            actionResult.Should().HaveCount(1);
            actionResult.First().Should().BeEquivalentTo(seguro);
        }

        [Fact]
        public async void GetByName_ReturnsNotFoundNotFoundOnNonExistingName()
        {
            // Arrange
            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.GetByParam(It.IsAny<Expression<Func<EV_Seguro, bool>>>()))
                .ReturnsAsync(new List<EV_Seguro>()); // Simula que no se encuentra ningún seguro

            var controller = new SeguroController(null, null, serviceMock.Object);

            // Act
            var result = await controller.Get("SeguroNoExistente");

            // Assert
            var notFoundObjectResult = result.Result.Should().BeOfType<NotFoundResult>().Subject;
            notFoundObjectResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);
            // Puedes agregar más aserciones si es necesario, por ejemplo:
            // notFoundObjectResult.StatusCode.Should().Be(404);
            // notFoundObjectResult.Value.Should().BeNull();
        }

        [Fact]
        public async void Post_CreatesSeguroReturnsOk()
        {
            // Arrange
            var newSeguro = new EV_Seguro { IdSeguro = 1, Nombre = "Seguro1" };

            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.Add(newSeguro));
            var controller = new SeguroController(null, null, serviceMock.Object);
            // Act

            var result = await controller.Post(newSeguro);

            // Assert
            var okResult = result.Should().BeOfType<OkResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            serviceMock.Verify(s => s.Add(newSeguro), Times.Once);
        }

        [Fact]
        public async void Delete_RemovesSeguroReturnsOk()
        {
            // Arrange
            var seguroId = 1;

            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            serviceMock.Setup(s => s.Delete(seguroId));

            var controller = new SeguroController(null, null, serviceMock.Object);

            // Act
            var result = await controller.Delete(seguroId);

            // Assert
            var okResult = result.Should().BeOfType<OkResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            serviceMock.Verify(s => s.Delete(seguroId), Times.Once);
        }

        [Fact]
        public async void Update_ReturnsOk()
        {
            // Arrange
            var seguroToUpdate = new EV_Seguro { IdSeguro = 1, Nombre = "Seguro1" };

            var serviceMock = new Mock<ICRUDService<EV_Seguro>>();
            //serviceMock.Setup(s => s.Update(It.IsAny<EV_Seguro>())).ReturnsAsync(seguroToUpdate);

            var controller = new SeguroController(null, null, serviceMock.Object);

            // Act
            var result = await controller.Update(seguroToUpdate);

            // Assert
            var okResult = result.Should().BeOfType<OkResult>().Subject;
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);
            // Verificar que el método Update del servicio se haya llamado exactamente una vez con el seguro proporcionado
            serviceMock.Verify(s => s.Update(It.Is<EV_Seguro>(seguro => seguro == seguroToUpdate)), Times.Once);
        }

      
    }
}