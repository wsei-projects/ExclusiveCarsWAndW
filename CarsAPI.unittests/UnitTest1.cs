using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using CarsAPI.Controllers;
using CarsAPI.Data;
using CarsAPI.Models;
using CarsAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Moq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CarsAPI.unittests
{
        public class CarClassesControllerTests
        {
            [Fact]
            public void GetCarClasses_ReturnsAllCarClasses()
            {
                // Arrange
                var carClasses = new List<CarClass>
            {
                new CarClass { Id = 1, Name = "Class 1" },
                new CarClass { Id = 2, Name = "Class 2" },
                new CarClass { Id = 3, Name = "Class 3" }
            };

                var dbContextMock = new Mock<AppDbContext>();
                var dbSetMock = new Mock<DbSet<CarClass>>();

                dbSetMock.As<IQueryable<CarClass>>().Setup(m => m.Provider).Returns(carClasses.AsQueryable().Provider);
                dbSetMock.As<IQueryable<CarClass>>().Setup(m => m.Expression).Returns(carClasses.AsQueryable().Expression);
                dbSetMock.As<IQueryable<CarClass>>().Setup(m => m.ElementType).Returns(carClasses.AsQueryable().ElementType);
                dbSetMock.As<IQueryable<CarClass>>().Setup(m => m.GetEnumerator()).Returns(carClasses.AsQueryable().GetEnumerator());

                dbContextMock.Setup(c => c.CarClasses).Returns(dbSetMock.Object);

                var controller = new CarClassesController(dbContextMock.Object);

                // Act
                var result = controller.GetCarClasses();

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var carClassesDto = Assert.IsAssignableFrom<IEnumerable<CarClassDto>>(okResult.Value);
                Assert.Equal(carClasses.Count, carClassesDto.Count());
            }

            [Fact]
            public void GetCarClass_WithValidId_ReturnsCarClass()
            {
                // Arrange
                var carClass = new CarClass { Id = 1, Name = "Class 1" };

                var dbContextMock = new Mock<AppDbContext>();
                var dbSetMock = new Mock<DbSet<CarClass>>();

                dbSetMock.Setup(m => m.Find(carClass.Id)).Returns(carClass);

                dbContextMock.Setup(c => c.CarClasses).Returns(dbSetMock.Object);

                var controller = new CarClassesController(dbContextMock.Object);

                // Act
                var result = controller.GetCarClass(carClass.Id);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var carClassDto = Assert.IsType<CarClassDto>(okResult.Value);
                Assert.Equal(carClass.Id, carClassDto.Id);
                Assert.Equal(carClass.Name, carClassDto.Name);
            }

            [Fact]
            public void GetCarClass_WithInvalidId_ReturnsNotFound()
            {
                // Arrange
                var dbContextMock = new Mock<AppDbContext>();
                var dbSetMock = new Mock<DbSet<CarClass>>();

                dbSetMock.Setup(m => m.Find(It.IsAny<int>())).Returns<CarClass>(null);

                dbContextMock.Setup(c => c.CarClasses).Returns(dbSetMock.Object);

                var controller = new CarClassesController(dbContextMock.Object);

                // Act
                var result = controller.GetCarClass(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
