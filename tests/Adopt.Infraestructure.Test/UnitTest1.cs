using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace Adopt_Pet.Api.Tests.Repository
{
    public class BaseRepositoryTests
    {
        // Mocking DataContext and IMapper
        private readonly Mock<DataContext> _mockContext = new Mock<DataContext>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        // Sample entity and DTO classes for testing
        public class SampleEntity { }
        public class SampleDto { }

        // Method to initialize BaseRepository with mocked dependencies
        private BaseRepository<SampleDto, SampleDto, SampleDto, SampleEntity> CreateRepository()
        {
            return new BaseRepository<SampleDto, SampleDto, SampleDto, SampleEntity>(_mockContext.Object, _mockMapper.Object);
        }

        // Test Save method
        [Fact]
        public async Task SavePet()
        {
            PetModel dto = new PetModel();
            dto.Abrigo_id = 3;
            dto.name = "Rex";
            dto.description = "Dog";
            dto.adopted = false;
            dto.address = "Rua 1";
            dto.age = "3";
            dto.Photo = "Hello";
            _mockContext.Setup(c => c.Set<PetModel>().Add(dto)); 
            _mockContext.Setup(c => c.SaveChanges());
            

        }

        // Test Update method
        [Fact]
        public async Task Update_WhenCalled_ShouldUpdateEntity()
        {
            // Arrange
            var repository = CreateRepository();
            var id = 1;
            var dto = new SampleDto();
            var entity = new SampleEntity();

            _mockContext.Setup(c => c.Set<SampleEntity>().FindAsync(id)).ReturnsAsync(entity);

            // Act
            await repository.Update(dto, id);

            // Assert
            _mockMapper.Verify(m => m.Map(dto, entity), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        // Test Delete method
        [Fact]
        public async Task Delete_WhenCalled_ShouldRemoveEntity()
        {
            // Arrange
            var repository = CreateRepository();
            var id = 1;
            var entity = new SampleEntity();

            _mockContext.Setup(c => c.Set<SampleEntity>().FindAsync(id)).ReturnsAsync(entity);

            // Act
            await repository.Delete(id);

            // Assert
            _mockContext.Verify(c => c.Set<SampleEntity>().Remove(entity), Times.Once);
            _mockContext.Verify(c => c.SaveChanges(), Times.Once);
        }

        // Test GetId method
        [Fact]
        public void GetId_WithValidId_ShouldReturnDto()
        {
            // Arrange
            var repository = CreateRepository();
            var id = 1;
            var entity = new SampleEntity();
            var dto = new SampleDto();

            _mockContext.Setup(c => c.Set<SampleEntity>().Find(id)).Returns(entity);
            _mockMapper.Setup(m => m.Map<SampleDto>(entity)).Returns(dto);

            // Act
            var result = repository.GetId(id);

            // Assert
            Assert.Equal(dto, result);
        }

        // Test GetId method with invalid id
        [Fact]
        public void GetId_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            var repository = CreateRepository();
            var id = 1;

            _mockContext.Setup(c => c.Set<SampleEntity>().Find(id)).Returns((SampleEntity)null);

            // Act & Assert
            Assert.Throws<ApplicationException>(() => repository.GetId(id));
        }

       

        // Test Verification method
        [Fact]
        public async Task Verification_WithValidId_ShouldReturnEntity()
        {
            // Arrange
            var repository = CreateRepository();
            var id = 1;
            var entity = new SampleEntity();

            _mockContext.Setup(c => c.Set<SampleEntity>().FindAsync(id)).ReturnsAsync(entity);

            // Act
            var result = await repository.Verification(id);

            // Assert
            Assert.Equal(entity, result);
        }

        // Test Verification method with invalid id
        [Fact]
        public async Task Verification_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            var repository = CreateRepository();
            var id = 1;

            _mockContext.Setup(c => c.Set<SampleEntity>().FindAsync(id)).ReturnsAsync((SampleEntity)null);

            // Act & Assert
            await Assert.ThrowsAsync<ApplicationException>(() => repository.Verification(id));
        }
    }
}
