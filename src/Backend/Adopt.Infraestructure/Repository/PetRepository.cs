using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Adopt.Domain.Services;
using Microsoft.AspNetCore.Components.Forms;


namespace Adopt_Pet.Api.Repository;

public class PetRepository : BaseRepository<PetDto,ReadPetDto,UpdatePetDto,PetModel>, IPetRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IAbrigoRepository _abrigoRepository;
    private readonly VisioIa _visioIa;
    private readonly UploadFileAzure _uploadFileAzure;
    public PetRepository(DataContext context, IMapper mapper, IAbrigoRepository abrigoRepository,VisioIa visioIa, UploadFileAzure uploadFileAzure) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
        _abrigoRepository = abrigoRepository;
        _visioIa = visioIa;
        _uploadFileAzure = uploadFileAzure;
    }

    public async Task<bool> Save(PetDto dto)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            dto.PhotoFile.CopyTo(stream);
            var bytes = stream.ToArray();
            var isPet = _visioIa.Response(bytes);
            if (!isPet)
            {
                throw new ApplicationException("A imagem não é de um pet");
            }
            var base64 = Convert.ToBase64String(bytes);
            var filePath = _uploadFileAzure.UploadFile(base64, "adopt");
            var model = _mapper.Map<PetModel>(dto);
            model.Photo = filePath;
        await base.Save(model);
        return true;
        }
    
       
    }

    public async Task<IEnumerable<ReadPetDto>> GetAll(int? Abrigo_id = null)
    {
        List<ReadPetDto> pets = _mapper.Map<List<ReadPetDto>>(_context.petModels.FromSqlRaw($"SELECT id, name, description ,adopted, address, age, Photo, Abrigo_id FROM petModels" +
           $" where petModels.Abrigo_id = {Abrigo_id} AND petModels.adopted = false").ToList());


        foreach (var pet in pets)
           {

      
            pet.ImageBytes = await _uploadFileAzure.DowloadFile(pet.Photo);

        }

          return pets;
    }

    public async override Task<ReadPetDto> GetId(int id)
    {
        var pet = await _context.petModels.FindAsync(id);
        if (pet == null)
        {
            throw new ApplicationException("Pet não encontrado");
        }
        var dto = _mapper.Map<ReadPetDto>(pet);
        dto.ImageBytes = await _uploadFileAzure.DowloadFile(pet.Photo);
        return dto;
    }
    
    public async Task Delete(int id, AbrigoLoginDto dto)
    {         
        await _abrigoRepository.Login(dto);
        await base.Delete(id);
    }

    public async Task Update(UpdatePetDto dto, int id, AbrigoLoginDto dtoAbrigo)
    {
        await _abrigoRepository.Login(dtoAbrigo);
        await base.Update(dto, id);
    }

}

