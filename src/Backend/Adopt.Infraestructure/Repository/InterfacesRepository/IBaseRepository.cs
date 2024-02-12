namespace Adopt_Pet.Api.Repository.InterfacesRepository
{
    public interface IBaseRepository<Tdto,ReadTdto, UpdateTdto,T> where T : class where ReadTdto : class where UpdateTdto : class where Tdto : class
    {
        Task Save(T model);
        Task<ReadTdto> GetId(int id);
        Task<Task> Update(UpdateTdto dto,int id);
        Task<Task> Delete(int id);
        Task<IEnumerable<ReadTdto>> GetAll();
    }
}