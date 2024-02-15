using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Adopt_Pet.Api.Tests
{
    public class TutorRepositoryTests : DependencyInjection
    {
        private readonly TutorRepository _tutorRepository;
        private readonly SignInManager<TutorModel> _signInManager;
        private readonly UserManager<TutorModel> _userManager;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public TutorRepositoryTests() : base()
        {
            _userManager = _serviceProvider.GetRequiredService<UserManager<TutorModel>>();
            _signInManager = _serviceProvider.GetRequiredService<SignInManager<TutorModel>>();
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
            _tokenService = _serviceProvider.GetRequiredService<TokenService>();

            _tutorRepository = new TutorRepository(_userManager, _mapper, _signInManager, _tokenService);
        }
        
        [Fact]
        public async Task SaveTutorTeste()
        {
            var tutorDto = new TutorDto
            {
                Username = "username",
                City = "city",
                State = "state",
                Email = "Email@email.com",
                PhoneNumber = 123456,
                Password = "@Password123",
                Repassword = "@Password123"
                

            };
            var tutor = await _tutorRepository.Save(tutorDto);
             
            Assert.True(tutor);
            
        }

        [Fact]
        public async Task GetIdTutorTeste()
        {
            var tutor = await _tutorRepository.GetIdTutor("1");
            Assert.NotNull(tutor);
        }

        [Fact]
        public async Task UpdateTutorTeste()
        {
            var tutorDto = new TutorDto
            {
                Username = "username",
                City = "city",
                State = "state",
                Email = "Email@email.com"
            };
            var result = await _tutorRepository.UpdateTutor(tutorDto, "2");
            Assert.NotNull(result);

        }

        [Fact]
        public async Task DeleteTutorTeste()
        {
            await _tutorRepository.Delete("1");
        }

        [Fact]
        public async Task Login_SuccessfulLogin_ReturnsToken()
        {
            // Arrange
            var dto = new TutorLoginDto { Username = "Login3", Password = "@gA487177" };
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, true, false);
            var expectedTutor = new TutorModel { Id = "1", UserName = "username" };
            var user = _userManager.Users.FirstOrDefault((x => x.UserName == dto.Username));
                              
            
            var token = _tokenService.GenerateTokenTutor(user);
            

            // Act
            

            // Assert
            Assert.NotNull(token);
        }

      
    }


    }




