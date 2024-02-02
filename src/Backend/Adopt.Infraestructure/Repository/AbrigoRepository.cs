using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BCrypt;


namespace Adopt_Pet.Api.Repository;


public class AbrigoRepository : BaseRepository<AbrigoDto,ReadAbrigoDto, UpdateAbrigoDto, AbrigoModel>,IAbrigoRepository
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly TokenService _tokenService;
    public AbrigoRepository(DataContext context, IMapper mapper, TokenService tokenService) : base(context, mapper)
    {
        _context = context;
        _mapper = mapper;
        _tokenService = tokenService;
        
        

    }
    public async Task Save(AbrigoDto dto)
    {
        try
        {
            var model = _mapper.Map<AbrigoModel>(dto);
            var password = dto.Password;
            var hash = HashPassword(password);
            model.PasswordHash = hash;
            await base.Save(model);
        }catch 
        {
            throw new ApplicationException("Falha ao Cadastrar o Abrigo Verifique se Todos os Campos estão preenchidos Corretamente");
        }

    }

    public async Task<IEnumerable<ReadAbrigoDto>> GetAll()
    {
        try
        {
            return await base.GetAll();
        }
        catch
        {
            throw new ApplicationException("Falha ao Listar os Abrigos");
        }
    }
    public ReadAbrigoDto GetId(int id)
    {
        try
        {
            var dto = base.GetId(id);
            return dto;
        }
        catch
        {
            throw new ApplicationException("Ops Occoreu Um Erro No Servidor Por Favo Tente Novamente");
        }
    }

    public async Task<Task> Update(UpdateAbrigoDto dto, int id)
    {
        try
        {
          return  await base.Update(dto, id);
            
        } catch
        {
            throw new ApplicationException("Falha ao Atualizar o Abrigo Verifique se Todos os Campos estão preenchidos Corretamente");
        }

    }

    public async Task Delete(AbrigoLoginDto dto,int id)
    {
        try
        {   await Login(dto);
            await base.Delete(id);
            _context.SaveChanges();
        } catch
        {
            throw new ApplicationException("Falha ao Deletar o Abrigo");
        }

    }





    public async Task<string> Login(AbrigoLoginDto dto)
    {
        var abrigo = await _context.AbrigoModel.FirstOrDefaultAsync(x => x.UserName == dto.Username);
        if (abrigo == null)
        {
            throw new ApplicationException("Abrigo não encontrado");
        }
            bool validPassword = BCrypt.Net.BCrypt.Verify(dto.Password, abrigo.PasswordHash);
            if (!validPassword)
            {
                throw new ApplicationException("Senha incorreta");
            }
        return _tokenService.GenerateTokenAbrigo(abrigo);
    }

    private string HashPassword(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        return hash;
    }

}
