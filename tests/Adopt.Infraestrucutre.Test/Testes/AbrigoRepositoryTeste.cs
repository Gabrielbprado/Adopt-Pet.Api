using Adopt.Domain.Interfaces;
using Adopt.Domain.Services;
using adopt_pet.api.data.dtos.abrigodtos;
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

namespace Adopt.Infraestructure.Test;

public class AbrigoTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly AbrigoRepository _abrigoRepository;
    private readonly Mock<IVisionIA> _visioIa;
    private readonly Mock<IFileAzure> _uploadFileAzure;
    private readonly DataContext _context;
    private readonly TokenService _tokenService;
    private readonly Mock<IAbrigoRepository> _MockabrigoRepository;


    public AbrigoTest()
    {


        _mapper = new Mock<IMapper>();
        _tokenService = new TokenService();
        var dbInMemory = new DataContextInMemory();
        _context = dbInMemory.GetContext();
        _visioIa = new Mock<IVisionIA>();
        _uploadFileAzure = new Mock<IFileAzure>();
        _abrigoRepository = new AbrigoRepository(_context, _mapper.Object, _tokenService);
        _MockabrigoRepository = new Mock<IAbrigoRepository>();
    }

    [Fact]
    public async void SaveAbrigo()
    {
        AbrigoDto abrigoDto = new AbrigoDto
        {
            Username = "Abrigo 1",
            City = "Rua 1",
            PhoneNumber = "12389",
            CNPJ = "10.736.016/0001-10",
            Password = "@gA487177",
            State = "SP",
            Email = "email22@gmail.com",
            Repassword = "@gA487177",
        };
        AbrigoModel abrigoModel = new AbrigoModel
        {
            id = 3,
            UserName = "Abrigo 1",
            City = "Rua 1",
            PhoneNumber = "12389",
            CNPJ = "10.736.016/0001-10",
            PasswordHash = "@gA487177",
            State = "SP",
            Email = "email22@gmail.com",

        };

        _mapper.Setup(x => x.Map<AbrigoModel>(It.IsAny<AbrigoDto>())).Returns(abrigoModel);
        _MockabrigoRepository.Setup(x => x.HashPassword("Password")).Returns("@gA487177");
        _MockabrigoRepository.Setup(x => x.IsValidCnpj("10.736.016/0001-10")).Returns(true);
        var result = await _abrigoRepository.Save(abrigoDto);
        Assert.True(result);
    }

    [Fact]
   public async void GetAllPet()
    {
        List<ReadAbrigoDto> abrigos = new List<ReadAbrigoDto>
        {
            new ReadAbrigoDto
            {
                id = 1,
                username = "Dog",
                city = "2",
                state = "Dog",
                CNPJ = "Rua 1",
                email = "Dog.jpg",
                phonenumber = "2322",


            },
            new ReadAbrigoDto
            {
                  id = 1,
                username = "Dog",
                city = "2",
                state = "Dog",
                CNPJ = "Rua 1",
                email = "Dog.jpg",
                phonenumber = "2322",

            }
        };
        _mapper.Setup(x => x.Map<List<ReadAbrigoDto>>(It.IsAny<List<AbrigoModel>>())).Returns(abrigos);
        var res = await _abrigoRepository.GetAll();
        Assert.NotNull(res);
    
    }


    [Theory]
    [InlineData(1)]
    [InlineData(2)]

    public void GetAbrigoId(int id)
    {
        var abrigo = _abrigoRepository.GetId(id);
        Assert.NotNull(abrigo);


    }

    [Fact]
    public async void UpdateAbrigo()
    {
        UpdateAbrigoDto updateAbrigoDto = new UpdateAbrigoDto
        {
            Username = "Abrigo 1",
            City = "Rua 1",
            PhoneNumber = "12389",
            State = "SP",
            Email = "Email@Update@Gmail.com"
        };
        var result = await _abrigoRepository.Update(updateAbrigoDto, 1);
        Assert.True(result);
    }

    [Fact]
    public async void DeleteAbrigo()
    {
        var result = await _abrigoRepository.Delete(1);
        Assert.True(result);
    }

    [Fact]
    public async void LoginAbrigo()
    {
        AbrigoLoginDto dto = new AbrigoLoginDto
        {
            Username = "Abrigo 2",
            Password = "@gA487177"
        };
        var result = await _abrigoRepository.Login(dto);
        Assert.NotNull(result);
    }





}