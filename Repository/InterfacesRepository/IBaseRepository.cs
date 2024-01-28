namespace Adopt_Pet.Api.Repository.InterfacesRepository
{
    public interface IBaseRepository<Tdto,ReadTdto> where Tdto : class where ReadTdto : class
    {
        Task Save(Tdto dto);
        Task<ReadTdto> GetId(int id);
        Task Update(Tdto dto, int id);
        Task Delete(int id);
        Task<IEnumerable<ReadTdto>> GetAll();
    }
}