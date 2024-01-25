using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Adopt_Pet.Api.Repository;


public class AbrigoRepository : IAbrigoRepository
{
    private readonly IMapper _mapper;
    private readonly UserManager<AbrigoModel> _userManeger;
    private readonly SignInManager<AbrigoModel> _signInManager;
    private readonly TokenService _tokenService;
    public AbrigoRepository(UserManager<AbrigoModel> userManager, IMapper mapper, SignInManager<AbrigoModel> signInManager)
    {
        _userManeger = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }
    public async Task Save(AbrigoDto dto)
    {
        var model = _mapper.Map<AbrigoModel>(dto);
        var abrigo = await _userManeger.CreateAsync(model,dto.Password);
        if(!abrigo.Succeeded)
        {
            throw new ApplicationException("Falha ao Cadastrar o Usuario");
        }
       
    }

    public async Task<ReadAbrigoDto> GetIdAbrigo(string id)
    {
        AbrigoModel? abrigo = await _userManeger.FindByIdAsync(id);
        var dto = _mapper.Map<ReadAbrigoDto>(abrigo);
        if(abrigo == null)
        {
            throw new ApplicationException("Abrigo não encontrado");
        }
        return dto;
    }

    public async Task UpdateAbrigo(AbrigoDto dto, string id)
    {
        var abrigo = await _userManeger.FindByIdAsync(id);
        if(abrigo == null)
        {
            throw new ApplicationException("AbrigoDtos não encontrado");
        }
        abrigo.UserName = dto.Username;
        abrigo.NormalizedUserName = dto.Username.ToUpper();

    }

    public async Task Delete(string id)
    {
        var Abrigo = await _userManeger.FindByIdAsync(id);
        if(Abrigo == null)
        {
            throw new ApplicationException("Abrigo não encontrado");

        }
        await _userManeger.DeleteAsync(Abrigo);
        
    }

    public async Task<string> Login(AbrigoLoginDto dto)
    {
        var AbrigoLogin = await _signInManager.PasswordSignInAsync(dto.Username,dto.Password,true,false);
        if (!AbrigoLogin.Succeeded)
        {
            throw new ApplicationException("Falha ao Logar");
        }
        
        var Abrigo = _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName == dto.Username);
        var token = _tokenService.GenerateTokenAbrigo(Abrigo);
        return token;
    }
}
