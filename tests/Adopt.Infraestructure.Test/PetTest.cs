using Xunit;
using Moq;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
using System.IO;
using Adopt.Domain.Services;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Adopt_Pet.Api.Tests.Repository
{
    public class PetRepositoryTests
    {
        [Fact]
        public async Task Save_Should_Save_Pet_With_Photo()
        {
            // Arrange
            var dto = new PetDto
            {
                abrigo_id = 1,
                name = "name",
                description = "description",
                adopted = false,
                age = "age",
                address = "address",
                PhotoFile = new FormFile(new MemoryStream(), 0, 0, "photo", "photo.jpg")
            };
   

            var photoMemoryStream = new MemoryStream();
            byte[] photoBytes = File.ReadAllBytes("Storage/Pet/dog.png");
            photoMemoryStream.Write(photoBytes, 0, photoBytes.Length);
            // Adicione uma imagem de teste ao MemoryStream
            // Exemplo: byte[] photoBytes = File.ReadAllBytes("caminho/para/sua/imagem.jpg");
            //          photoMemoryStream.Write(photoBytes, 0, photoBytes.Length);
            dto.PhotoFile = new FormFile(photoMemoryStream, 0, photoMemoryStream.Length, "photo", "photo.jpg");

            var mockMapper = new Mock<IMapper>();
            var mockContext = new Mock<DataContext>();
            var mockAbrigoRepository = new Mock<IAbrigoRepository>();
            var mockVisioIa = new Mock<VisioIa>();

            var petRepository = new PetRepository(mockContext.Object, mockMapper.Object, mockAbrigoRepository.Object, mockVisioIa.Object);

            // Act
            var result = await petRepository.Save(dto);
            Assert.True(result);

            // Assert
            // Você pode adicionar asserções aqui para verificar se o método Save comportou-se conforme o esperado
            // Por exemplo, você pode verificar se o arquivo foi salvo no local correto
            // e se a chamada para base.Save(model) ocorreu como esperado
        }
    }
}
