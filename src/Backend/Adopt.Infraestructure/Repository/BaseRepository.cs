using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace Adopt_Pet.Api.Repository;


public class BaseRepository<Tdto, ReadTDto,UpdateTdto,T> : IBaseRepository<Tdto,ReadTDto, UpdateTdto, T> where T : class where ReadTDto : class where UpdateTdto : class where Tdto : class
{

    private readonly DataContext _context;
    private readonly IMapper _mapper;


    public  BaseRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Task Save(T model)
    {
         
        _context.Set<T>().Add(model);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public async virtual Task<Task> Update(UpdateTdto dto, int id)
    {
        var t = await Verification(id);       
        _mapper.Map(dto, t);
        await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
    public async virtual Task<Task> Delete(int id)
    {

        var t = await Verification(id);
         _context.Set<T>().Remove(t);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public virtual ReadTDto GetId(int id)
    {
        var t = _context.Set<T>().Find(id);
        if(t == null)
        {
            throw new ApplicationException("Não encontrado");
        }
        var tdto = _mapper.Map<ReadTDto>(t);
        return tdto;
    }

    public async Task<IEnumerable<ReadTDto>> GetAll()
    {
        var entities = await _context.Set<T>().ToListAsync();
        return _mapper.Map<List<ReadTDto>>(entities);
    }

    public async Task<T> Verification(int id)
    {
        var t = await _context.Set<T>().FindAsync(id);
        if (t == null)
        {
            throw new ApplicationException("Não encontrado");
        }
        return t;
    }


}

