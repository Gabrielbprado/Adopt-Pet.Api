﻿using adopt_pet.api.data.dtos.abrigodtos;
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

namespace Adopt_Pet.Api.Repository;


public class PetRepository : IPetRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    public PetRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        
        

    }
    public async Task Save(PetDto dto)
    {
        var model = _mapper.Map<PetModel>(dto);
        var Pet = await _context.petModels.AddAsync(model);
        _context.SaveChanges();

    }

    public async Task<ReadPetDto> GetIdPet(string id)
    {
        PetModel? pet = await _context.petModels.FindAsync(id);
        var dto = _mapper.Map<ReadPetDto>(pet);
        if (pet == null)
        {
            throw new ApplicationException("Pet não encontrado");
        }
        return dto;
    }

    public async Task UpdatePet(PetDto dto, string id)
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

    public async Task Delete(string id)
    {
        var pet = await _context.petModels.FindAsync(id);
        if (pet == null)
        {
            throw new ApplicationException("pet não encontrado");

        }
         _context.petModels.Remove(pet);
        _context.SaveChanges();

    }

 

    public async Task<IEnumerable<ReadPetDto>> GetAllPet()
    {
        var pet =  _context.petModels.ToList();
        var petdto = _mapper.Map<List<ReadPetDto>>(pet);
        return petdto;
    }



}
