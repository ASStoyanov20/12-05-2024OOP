using HrManagement.DataAccess.Models;
namespace HrManagement.DataAccess.Repository.Base;
public interface IGenericRepository<T>
{
    public T? GetById(int id);
    public IQueryable<T> GetAll();
    public bool Add(T entity);
    public bool Update(T entity);
    public bool Delete(int i);
}