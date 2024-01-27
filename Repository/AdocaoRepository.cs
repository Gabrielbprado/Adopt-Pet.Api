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
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Data.Dtos.AdocaoDtos;

namespace Adopt_Pet.Api.Repository;


public class AdocaoRepository : IAdocaoRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly IAbrigoRepository _abrigoRepository;
    public AdocaoRepository(DataContext context, IMapper mapper, IAbrigoRepository abrigoRepository)
    {
        _context = context;
        _mapper = mapper;
        _abrigoRepository = abrigoRepository;
    }
    public async Task Adopte(AdocaoDto dto)
    {
        try
        {
            var adopt = _mapper.Map<AdocaoModel>(dto);
            _context.AdocaoModel.Add(adopt);

            var pet = await _context.petModels.FindAsync(dto.pet_id);
            if (pet == null)
            {
                throw new ApplicationException("Pet não encontrado");
            }
            pet.adopted = true;
            _context.SaveChanges();
        }  catch
        {
            throw new ApplicationException("Falha ao Adotar o Pet");
        }


    }

  

    public async Task Delete(int id,AbrigoLoginDto dto)
    {
        try
        {
            var pet = await _context.AdocaoModel.FindAsync(id);
            if (pet == null)
            {
                throw new ApplicationException("pet não encontrado");

            }
            await _abrigoRepository.Login(dto);
            _context.AdocaoModel.Remove(pet);
            _context.SaveChanges();
        }
        catch
        {
            throw new ApplicationException("Falha ao Deletar o Pet");
        }

    }



  
}

