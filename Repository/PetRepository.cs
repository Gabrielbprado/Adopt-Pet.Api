using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BCrypt;
using Adopt_Pet.Api.Data.Dtos.PetDtos;
using Microsoft.AspNetCore.Mvc;

namespace Adopt_Pet.Api.Repository;


public class PetRepository : IPetRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IAbrigoRepository _abrigoRepository;
    public PetRepository(DataContext context, IMapper mapper, IAbrigoRepository abrigoRepository)
    {
        _context = context;
        _mapper = mapper;
        _abrigoRepository = abrigoRepository;
    }
    public async Task Save(PetDto dto)
    {
        var filePath = Path.Combine("Storage",dto.PhotoFile.FileName);
        using Stream stream = new FileStream(filePath, FileMode.Create);
        dto.PhotoFile.CopyTo(stream);
        var model = _mapper.Map<PetModel>(dto);
        var Pet = await _context.petModels.AddAsync(model);
        _context.SaveChanges();

    }

    public async Task<ReadPetDto> GetIdPet(int id)
    {
        PetModel? pet = await _context.petModels.FindAsync(id);
        var dto = _mapper.Map<ReadPetDto>(pet);
        if (pet == null)
        {
            throw new ApplicationException("Pet não encontrado");
        }
        return dto;
    }

    public async Task UpdatePet(PetDto dto, int id)
    {
        var pet = await _context.petModels.FindAsync(id);
        if (pet == null)
        {
            throw new ApplicationException("pet não encontrado");
        }
        pet.name= dto.name;
        pet.age = dto.age;
        _context.SaveChanges();

    }

    public async Task Delete(int id,AbrigoLoginDto dto)
    {
        var pet = await _context.petModels.FindAsync(id);
        if (pet == null)
        {
            throw new ApplicationException("pet não encontrado");

        }
        await _abrigoRepository.Login(dto);
         _context.petModels.Remove(pet);
        _context.SaveChanges();

    }



    public IEnumerable<ReadPetDto> GetAllPet([FromQuery] int? Abrigo_id = null)
    {
        return _mapper.Map<List<ReadPetDto>>(_context.petModels.FromSqlRaw($"SELECT id, name, description ,adopted, address, age, image, Abrigo_id FROM petModels" +
            $" where petModels.Abrigo_id = {Abrigo_id}").ToList());

    }



}

