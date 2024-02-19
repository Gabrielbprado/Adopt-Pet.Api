using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.AbrigoDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BCrypt;
using System.Text.RegularExpressions;


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
    public async Task<bool> Save(AbrigoDto dto)
    {
            if(!IsValidCnpj(dto.CNPJ))
            {
                throw new ApplicationException("Cnpj Invalido");
            }
        try
        {
            var model = _mapper.Map<AbrigoModel>(dto);
            var password = dto.Password;
            var hash = HashPassword(password);
            model.PasswordHash = hash;

            await base.Save(model);
            return true;
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
    public async Task<ReadAbrigoDto> GetId(int id)
    {
        try
        {
            var dto = await base.GetId(id);
            return dto;
        }
        catch
        {
            throw new ApplicationException("Ops Occoreu Um Erro No Servidor Por Favo Tente Novamente");
        }
    }

    public async Task<bool> Update(UpdateAbrigoDto dto, int id)
    {
        try
        {
           await base.Update(dto, id);
            return true;
            
        } catch
        {
            throw new ApplicationException("Falha ao Atualizar o Abrigo Verifique se Todos os Campos estão preenchidos Corretamente");
        }

    }

    public async Task<bool> Delete(AbrigoLoginDto dto,int id)
    {
        try
        {   await Login(dto);
            await base.Delete(id);
            return true;
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

    public string HashPassword(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password);
        return hash;
    }

    public bool IsValidCnpj(string cnpj)
    {
        cnpj = Regex.Replace(cnpj, "[^0-9]", "");

        if (cnpj.Length != 14)
            return false;

        int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        string tempCnpj = cnpj.Substring(0, 12);
        int sum = 0;

        for (int i = 0; i < 12; i++)
        {
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
        }

        int remainder = sum % 11;
        remainder = (remainder < 2) ? 0 : 11 - remainder;

        string digit = remainder.ToString();
        tempCnpj += digit;
        sum = 0;

        for (int i = 0; i < 13; i++)
        {
            sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
        }

        remainder = sum % 11;
        remainder = (remainder < 2) ? 0 : 11 - remainder;

        digit += remainder.ToString();

        return cnpj.EndsWith(digit);
    }
}


