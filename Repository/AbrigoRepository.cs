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

namespace Adopt_Pet.Api.Repository;


public class AbrigoRepository : IAbrigoRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly TokenService _tokenService;
    public AbrigoRepository(DataContext context, IMapper mapper, TokenService tokenService)
    {
        _context = context;
        _mapper = mapper;
        _tokenService = tokenService;
        
        

    }
    public async Task Save(AbrigoDto dto)
    {
        var model = _mapper.Map<AbrigoModel>(dto);
        var password = dto.Password;
        var hash = HashPassword(password);
        model.PasswordHash = hash;
        var abrigo = await _context.abrigoModels.AddAsync(model);
        _context.SaveChanges();

    }

    public async Task<ReadAbrigoDto> GetIdAbrigo(string id)
    {
        AbrigoModel? abrigo = await _context.abrigoModels.FindAsync(id);
        var dto = _mapper.Map<ReadAbrigoDto>(abrigo);
        if (abrigo == null)
        {
            throw new ApplicationException("Abrigo não encontrado");
        }
        return dto;
    }

    public async Task UpdateAbrigo(AbrigoDto dto, string id)
    {
        var abrigo = await _context.abrigoModels.FindAsync(id);
        if (abrigo == null)
        {
            throw new ApplicationException("AbrigoDtos não encontrado");
        }
        abrigo.UserName = dto.Username;
        _context.SaveChanges();

    }

    public async Task Delete(string id)
    {
        var Abrigo = await _context.abrigoModels.FindAsync(id);
        if (Abrigo == null)
        {
            throw new ApplicationException("Abrigo não encontrado");

        }
         _context.abrigoModels.Remove(Abrigo);
        _context.SaveChanges();

    }

 

    public async Task<IEnumerable<ReadAbrigoDto>> GetAllAbrigo()
    {
        var abrigo =  _context.abrigoModels.ToList();
        var abrigodto = _mapper.Map<List<ReadAbrigoDto>>(abrigo);
        return abrigodto;
    }

    public async Task<string> Login(AbrigoLoginDto dto)
    {
        var abrigo = await _context.abrigoModels.FirstOrDefaultAsync(x => x.UserName == dto.Username);
        if (abrigo == null)
        {
            bool validPassword = BCrypt.Net.BCrypt.Verify(dto.Password, abrigo.PasswordHash);
            if (!validPassword)
            {
                throw new ApplicationException("Senha incorreta");
            }
            throw new ApplicationException("Usuario não encontrado");
        }
        return _tokenService.GenerateTokenAbrigo(abrigo);
    }

    private string HashPassword(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        return hash;
    }

}
