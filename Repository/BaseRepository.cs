using adopt_pet.api.data.dtos.abrigodtos;
using Adopt_Pet.Api.Data;
using Adopt_Pet.Api.Repository.InterfacesRepository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Adopt_Pet.Api.Repository;


public class BaseRepository<Tdto, ReadTDto> : IBaseRepository<Tdto, ReadTDto> where Tdto : class where ReadTDto : class
{

    private readonly DataContext _context;
    private readonly IMapper _mapper;


    public BaseRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public virtual Task Save(Tdto dto)
    {
             
        _context.Set<Tdto>().Add(dto);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public virtual Task Update(Tdto dto,int id)
    {
        var t = _context.Set<Tdto>().Find(dto);
        if(t == null)
        {
            throw new ApplicationException("Não encontrado");
        }
        _context.Set<Tdto>().Update(dto);
        _context.SaveChanges();
        return Task.CompletedTask;
    }
    public virtual Task Delete(int id)
    {
        var t = _context.Set<Tdto>().Find(id);
        if(t == null)
        {
            throw new ApplicationException("Não encontrado");
        }
        _context.Set<Tdto>().Remove(t);
        _context.SaveChanges();
        return Task.CompletedTask;
    }

    public virtual Task<ReadTDto> GetId(int id)
    {
        var t = _context.Set<Tdto>().Find(id);
        if(t == null)
        {
            throw new ApplicationException("Não encontrado");
        }
        return Task.FromResult(_context.Set<ReadTDto>().Find(id)!);
    }

    public async Task<IEnumerable<ReadTDto>> GetAll()
    {
        var entities = await _context.Set<Tdto>().ToListAsync();
        return _mapper.Map<List<ReadTDto>>(entities);
    }
}

