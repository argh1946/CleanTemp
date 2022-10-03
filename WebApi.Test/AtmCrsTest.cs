using AutoMapper;
using Core.Contracts;
using Core.Contracts.AtmCrs;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using WebApi.Controllers;

namespace WebApi.Test
{
    public class Tests
    {
        private AtmCrsController _atmCrsController;
        private Mock<IAtmCrsService> _atmCrsServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<AtmCrsController>> _loggerMock;

        [SetUp]
        public void Setup()
        {
            _atmCrsServiceMock = new Mock<IAtmCrsService>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<AtmCrsController>>();         
            _atmCrsController = new AtmCrsController(_atmCrsServiceMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task Should_Return_GetAllAtmCrsOutput_Instance()
        {
            // Arrange
            IEnumerable<AtmCrs> atmCrsList = new List<AtmCrs>();
            _atmCrsServiceMock.Setup(p => p.GetAllAsync()).Returns(Task.FromResult(atmCrsList));

            // Act
            var result = await _atmCrsController.GetAllAtmCrs();
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Test]
        public async Task Should_Return_AddAtmCrs()
        {
            // Arrange
            _atmCrsServiceMock.Setup(p => p.AddAsync(new AtmCrs()));

            // Act
            var result = await _atmCrsController.AddAtmCrsAsync(new AtmCrs());
            var okResult = result as OkObjectResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);
        }


    }
}