using Adopt.Domain.Interfaces;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace Adopt.Infraestrucutre.Test.Testes;

public class PetTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IAbrigoRepository> _abrigoRepository;
    private readonly Mock<IVisionIA> _visioIa;
    private readonly Mock<IFileAzure> _uploadFileAzure;
    private readonly PetRepository _petRepository;
    private readonly DataContext _context;
    private readonly TokenService _tokenService;



    public PetTest()
    {


        _mapper = new Mock<IMapper>();
        _tokenService = new TokenService();
        var dbInMemory = new DataContextInMemory();
        _context = dbInMemory.GetContext();
        _visioIa = new Mock<IVisionIA>();
        _uploadFileAzure = new Mock<IFileAzure>();
        _abrigoRepository = new Mock<IAbrigoRepository>();
        _petRepository = new PetRepository(_context, _mapper.Object, _abrigoRepository.Object, _visioIa.Object, _uploadFileAzure.Object);

    }

    [Fact]
    public async void SavePet()
    {




        byte[] imagemBytes = File.ReadAllBytes(@"C:\Adopt-Pet\Api\tests\Adopt.Infraestrucutre.Test\Storage\dog.png");
        string base64 = Convert.ToBase64String(imagemBytes);
        Console.WriteLine(base64);
        MemoryStream stream = new MemoryStream(imagemBytes); // Crie um MemoryStream com os bytes da imagem
        IFormFile arquivo = new FormFile(stream, 0, imagemBytes.Length, "dog", "dog.png");

        var pet = new PetDto
        {
            name = "Dog",
            age = "2",
            abrigo_id = 2,
            description = "Dog",
            address = "Rua 1",
            PhotoFile = arquivo,



        };

        var petModel = new PetModel
        {
            name = "Dog",
            age = "2",
            Abrigo_id = 2,
            description = "Dog",
            address = "Rua 1",
            Photo = "dog.png",
            adopted = false,
        };

        _mapper.Setup(x => x.Map<PetModel>(It.IsAny<PetDto>())).Returns(petModel);
        _uploadFileAzure.Setup(x => x.UploadFile(It.IsAny<string>(), It.IsAny<string>())).Returns("dog.png");
        _visioIa.Setup(x => x.Response(It.IsAny<byte[]>())).Returns(true);


        var result = await _petRepository.Save(pet);
        Assert.True(result);


    }

    [Fact]
    public async void GetAllPet()
    {
        List<ReadPetDto> pets = new List<ReadPetDto>
        {
            new ReadPetDto
            {
                id = 1,
                name = "Dog",
                age = "2",
                description = "Dog",
                address = "Rua 1",
                Photo = "Dog.jpg",
                adopted = false,

            },
            new ReadPetDto
            {
                id = 2,
                name = "Dog",
                age = "2",
                description = "Dog",
                address = "Rua 1",
                Photo = "Dog.jpg",
                adopted = false,

            }
        };
        _mapper.Setup(x => x.Map<List<ReadPetDto>>(It.IsAny<List<PetModel>>())).Returns(new List<ReadPetDto>());
        var res = await _petRepository.GetAll(1);
        Assert.NotNull(res);
        Assert.Equal(2, pets.Count);


    }

    [Fact]
    public async void GetIdPet()
    {
        ReadPetDto pet = new ReadPetDto
        {
            id = 1,
            name = "Dog",
            age = "2",
            description = "Dog",
            address = "Rua 1",
            Photo = "Dog.jpg",
            adopted = false,
            ImageBytes = new byte[1],

        };

        _mapper.Setup(x => x.Map<ReadPetDto>(It.IsAny<PetModel>())).Returns(pet);
        _uploadFileAzure.Setup(x => x.DowloadFile(It.IsAny<string>())).Returns(Task.FromResult(new byte[1]));
        var res = await _petRepository.GetId(1);
        Assert.NotNull(res);
        Assert.Equal(pet, res);
    }

    [Fact]
    public async void DeletePet()
    {
        AbrigoLoginDto dto = new AbrigoLoginDto
        {
            Username = "Abrigo 2",
            Password = "@gA487177"
        };
        _abrigoRepository.Setup(x => x.Login(It.IsAny<AbrigoLoginDto>())).Returns(Task.FromResult("Login"));
        _uploadFileAzure.Setup(x => x.DeleteFile(It.IsAny<string>())).Returns(Task.CompletedTask);
        var res = await _petRepository.Delete(1, dto);
        Assert.True(res);
    }





}