using Adopt.Domain.Services;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos.TutorDtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using Adopt_Pet.Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;



namespace Adopt_Pet.Api.Repository;


public class TutorRepository : ITutorRepository
{
    private readonly IMapper _mapper;
    private readonly SignInManager<TutorModel> _signInManager;
    private readonly UserManager<TutorModel> _userManeger;
    private readonly TokenService _tokenService;
    private readonly UploadFileAzure _uploadFileAzure;

    public TutorRepository(UserManager<TutorModel> userManager, IMapper mapper, SignInManager<TutorModel> signInManager, TokenService service, UploadFileAzure uploadFileAzure)
    {
        _userManeger = userManager;
        _mapper = mapper;
        _signInManager = signInManager;
        _tokenService = service;
        _uploadFileAzure = uploadFileAzure;
        
       
    }
    public async Task<bool> Save(TutorDto dto)
    {
        var model = _mapper.Map<TutorModel>(dto);
        model.Photo = "null";
        var tutor = await _userManeger.CreateAsync(model, dto.Password);
        if (!tutor.Succeeded)
        {
            throw new ApplicationException("Falha ao Cadastrar o Usuario");
        }
        return true;
        
    }

    public async Task<ReadTutorDto> GetIdTutor(string id)
    {
        TutorModel? tutor = await _userManeger.FindByIdAsync(id) ?? throw new ApplicationException("Tutor não encontrado");
        var dto = _mapper.Map<ReadTutorDto>(tutor);
        dto.databytes = await _uploadFileAzure.DowloadFile(tutor.Photo);
        return dto;
    }

    public async Task<bool> UpdateTutor(TutorDto dto, string id)
    {
        try
        {
            var tutor = await _userManeger.FindByIdAsync(id) ?? throw new ApplicationException("Tutor não encontrado");
            tutor.UserName = dto.Username;
            tutor.NormalizedUserName = dto.Username.ToUpper();
            var result = await _userManeger.UpdateAsync(tutor);
            return true;
        }catch (Exception e)
        {
            throw new ApplicationException($"Ocorreu um erro ao atualizar o tutor: {e.Message}");
        }

    }

    public async Task<bool> Delete(string id)
    {
        try
        {
            var tutor = await _userManeger.FindByIdAsync(id) ?? throw new ApplicationException("Tutor não encontrado");
            await _userManeger.DeleteAsync(tutor);
            return true;
        } catch (Exception e)
        {
            throw new ApplicationException($"Ocorreu um erro ao deletar o tutor: {e.Message}");
        }

    }

    public async Task<string> Login(TutorLoginDto dto)
    {
        var tutorLogin = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, true, false);
        if (!tutorLogin.Succeeded)
        {
            throw new ApplicationException("Falha ao Logar");
        }

        var tutor =  _signInManager.UserManager.Users.FirstOrDefault(x => x.UserName == dto.Username);
        if (tutor == null)
        {
            throw new ApplicationException("Usuario nao Encontrado");
        }
        var token =  _tokenService.GenerateTokenTutor(tutor);
        return token;
    }

    public async Task<ReadTutorDto> GetTutor(string username)
    {
        var tutor = await _userManeger.FindByNameAsync(username) ?? throw new ApplicationException("Tutor não encontrado");

        var dto = _mapper.Map<ReadTutorDto>(tutor);
        if(tutor.Photo != "null") 
        {
            dto.databytes = await _uploadFileAzure.DowloadFile(tutor.Photo); 
        }
        
        return dto;
    }

    public async Task<string> UploadPhoto(string id, IFormFile file)
    {
        try
        {

            using (MemoryStream stream = new MemoryStream())
            {
                file.CopyTo(stream);
                var bytes = stream.ToArray();
                var base64 = Convert.ToBase64String(bytes);
                var filePath = _uploadFileAzure.UploadFile(base64, "adopt");
                var tutuor = await _userManeger.FindByIdAsync(id) ?? throw new ApplicationException("Tutor não encontrado");
                tutuor.Photo = filePath;
                await _userManeger.UpdateAsync(tutuor);
                
            }
            return "Foto atualizada com sucesso";
            
        }
        catch (Exception e)
        {
            
            throw new ApplicationException($"Ocorreu um erro ao fazer o upload da foto: {e.Message}");
        }
    }

  
}
