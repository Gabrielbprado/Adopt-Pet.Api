using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Adopt_Pet.Api.Data.Dtos.PetDtos;


namespace Adopt_Pet.Api.Repository;

public class PetRepository : BaseRepository<PetDto,ReadPetDto,UpdatePetDto,PetModel>, IPetRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IAbrigoRepository _abrigoRepository;
    public PetRepository(DataContext context, IMapper mapper, IAbrigoRepository abrigoRepository) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
        _abrigoRepository = abrigoRepository;
    }

    public async Task Save(PetDto dto)
    {
        var filePath = Path.Combine("Storage", dto.PhotoFile.FileName);
        using Stream stream = new FileStream(filePath, FileMode.Create);
        dto.PhotoFile.CopyTo(stream);
        var model = _mapper.Map<PetModel>(dto);
        model.Photo = filePath;
        await base.Save(model);
       
    }

    public  IEnumerable<ReadPetDto> GetAll(int? Abrigo_id = null)
    {
        List<ReadPetDto> pets = _mapper.Map<List<ReadPetDto>>(_context.petModels.FromSqlRaw($"SELECT id, name, description ,adopted, address, age, Photo, Abrigo_id FROM petModels" +
           $" where petModels.Abrigo_id = {Abrigo_id} AND petModels.adopted = false").ToList());


        foreach (var pet in pets)
           {

             pet.ImageBytes = File.ReadAllBytes(pet.Photo);

          }

          return pets;
    }

    public override ReadPetDto GetId(int id)
    {
        var pet = _context.petModels.Find(id);
        if (pet == null)
        {
            throw new ApplicationException("Pet não encontrado");
        }
        var dto = _mapper.Map<ReadPetDto>(pet);
        dto.ImageBytes = File.ReadAllBytes(dto.Photo);
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

