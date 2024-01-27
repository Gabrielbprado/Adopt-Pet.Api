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
        try
        {
            var model = _mapper.Map<AbrigoModel>(dto);
            var password = dto.Password;
            var hash = HashPassword(password);
            model.PasswordHash = hash;
            var abrigo = await _context.AbrigoModel.AddAsync(model);
            _context.SaveChanges();
        }catch 
        {
            throw new ApplicationException("Falha ao Cadastrar o Abrigo Verifique se Todos os Campos estão preenchidos Corretamente");
        }

    }

    public async Task<ReadAbrigoDto> GetIdAbrigo(int id)
    {
        try
        {
            AbrigoModel? abrigo = await _context.AbrigoModel.FindAsync(id);
            var dto = _mapper.Map<ReadAbrigoDto>(abrigo);
            if (abrigo == null)
            {
                throw new ApplicationException("Abrigo não encontrado");
            }
            return dto;
        }
        catch 
        {
            throw new ApplicationException("Ops Occoreu Um Erro No Servidor Por Favo Tente Novamente");
        }
    }

    public async Task UpdateAbrigo(AbrigoDto dto, int id)
    {
        try
        {
            var abrigo = await _context.AbrigoModel.FindAsync(id);
            if (abrigo == null)
            {
                throw new ApplicationException("AbrigoDtos não encontrado");
            }
            abrigo.UserName = dto.Username;
            _context.SaveChanges();
        } catch
        {
            throw new ApplicationException("Falha ao Atualizar o Abrigo Verifique se Todos os Campos estão preenchidos Corretamente");
        }

    }

    public async Task Delete(int id)
    {
        try
        {
            var Abrigo = await _context.AbrigoModel.FindAsync(id);
            if (Abrigo == null)
            {
                throw new ApplicationException("Abrigo não encontrado");

            }
            _context.AbrigoModel.Remove(Abrigo);
            _context.SaveChanges();
        } catch
        {
            throw new ApplicationException("Falha ao Deletar o Abrigo");
        }

    }



    public IEnumerable<ReadAbrigoDto> GetAllAbrigo()
    {
        try
        {
            var abrigos = _context.AbrigoModel.ToList();
            return _mapper.Map<List<ReadAbrigoDto>>(abrigos);
        } catch
        {
            throw new ApplicationException("Falha ao Listar os Abrigos");
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