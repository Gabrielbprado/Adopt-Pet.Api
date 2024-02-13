using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository;
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

        public TutorRepositoryTests() : base()
        {
            var userManager = _serviceProvider.GetRequiredService<UserManager<TutorModel>>();
            var signInManager = _serviceProvider.GetRequiredService<SignInManager<TutorModel>>();
            var mapper = _serviceProvider.GetRequiredService<IMapper>();
            var tokenService = _serviceProvider.GetRequiredService<TokenService>();

            _tutorRepository = new TutorRepository(userManager, mapper, signInManager, tokenService);
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

       

    }
}
