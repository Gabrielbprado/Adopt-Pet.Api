using Adopt.Domain.Services;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt_Pet.Api.Repository;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;

namespace Adopt.Infraestructure.Test
{
    public class PetTest
    {
        private readonly Mock<IMapper> _mapper;
        private readonly AbrigoRepository _abrigoRepository;
        private readonly VisioIa _visioIa;
        private readonly FileAzure _uploadFileAzure;
        private readonly PetRepository _petRepository;
        private readonly DataContext _context;
        private readonly TokenService _tokenService;


        public PetTest()
        {
           

            _mapper = new Mock<IMapper>();
            _tokenService = new TokenService();
            var dbInMemory = new DataContextInMemory();
             _context = dbInMemory.GetContext();
            _visioIa = new VisioIa();
            _uploadFileAzure = new FileAzure();
            _abrigoRepository = new AbrigoRepository(_context,_mapper.Object,_tokenService);
            _petRepository = new PetRepository(_context,_mapper.Object,_abrigoRepository,_visioIa,_uploadFileAzure);
        }

        [Fact]
        public async void SavePet()
        {
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write("Fake image data");
            writer.Flush();
            memoryStream.Position = 0;
            var pet = new PetDto
            {
                name = "Dog",
                age = "2",
                abrigo_id = 1,
                description = "Dog",
                address = "Rua 1",
                PhotoFile = null,


            };
            var result = await _petRepository.Save(pet);
            Assert.True(result);
        
                 
               }



  
       
    }
}