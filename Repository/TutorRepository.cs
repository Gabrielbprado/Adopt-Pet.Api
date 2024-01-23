using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Data.Dtos;
using Adopt_Pet.Api.Models;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Adopt_Pet.Api.Repository;


public class TutorRepository : ITutorRepository
{
    private readonly IMapper _mapper;
    private readonly UserManager<TutorModel> _userManeger;
    public TutorRepository(UserManager<TutorModel> userManager, IMapper mapper)
    {
        _userManeger = userManager;
        _mapper = mapper;
    }
    public async Task Save(TutorDto dto)
    {
        var model = _mapper.Map<TutorModel>(dto);
        var tutor = await _userManeger.CreateAsync(model,dto.Password);
        if(!tutor.Succeeded)
        {
            throw new ApplicationException("Falha ao Cadastrar o Usuario");
        }
       
    }

    public async Task<TutorModel> GetIdTutor(string id)
    {
        var tutor = await _userManeger.FindByIdAsync(id);
        if(tutor == null)
        {
            throw new ApplicationException("Tutor não encontrado");
        }
        return tutor;
    }
}
