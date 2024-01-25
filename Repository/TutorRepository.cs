﻿using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Adopt_Pet.Api.Repository;


public class TutorRepository : ITutorRepository
{
    private readonly IMapper _mapper;
    private readonly UserManager<TutorModel> _userManeger;
    private readonly SignInManager<TutorModel> _signInManager;
    private readonly TokenService _tokenService;
    public TutorRepository(UserManager<TutorModel> userManager, IMapper mapper, SignInManager<TutorModel> signInManager)
    {
        _userManeger = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
    }
    public async Task Save(AbrigoDto dto)
    {
        var model = _mapper.Map<TutorModel>(dto);
        var tutor = await _userManeger.CreateAsync(model, dto.Password);
        if (!tutor.Succeeded)
        {
            throw new ApplicationException("Falha ao Cadastrar o Usuario");
        }

    }

    public async Task<ReadTutorDto> GetIdTutor(string id)
    {
        TutorModel? tutor = await _userManeger.FindByIdAsync(id);
        var dto = _mapper.Map<ReadTutorDto>(tutor);
        if (tutor == null)
        {
            throw new ApplicationException("Tutor não encontrado");
        }
        return dto;
    }

    public async Task UpdateTutor(AbrigoDto dto, string id)
    {
        var tutor = await _userManeger.FindByIdAsync(id);
        if (tutor == null)
        {
            throw new ApplicationException("Tutor não encontrado");
        }
        tutor.UserName = dto.Username;
        tutor.NormalizedUserName = dto.Username.ToUpper();

    }

    public async Task Delete(string id)
    {
        var tutor = await _userManeger.FindByIdAsync(id);
        if (tutor == null)
        {
            throw new ApplicationException("Tutor não encontrado");

        }
        await _userManeger.DeleteAsync(tutor);

    }

    public async Task<string> Login(TutorLoginDto dto)
    {
        var tutorLogin = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, true, false);
        if (!tutorLogin.Succeeded)
        {
            throw new ApplicationException("Falha ao Logar");
        }

        var tutor = _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName == dto.Username);
        var token =  _tokenService.GenerateTokenTutor(tutor);
        return token;
    }
}
