using HrManagement.DataAccess.Data;
using HrManagement.DataAccess.Models;
using HrManagement.DataAccess.Repository.Base;
namespace HrManagement.DataAccess.Repository;
public class EmployeeRepository(HrManagementDbContext context) : BaseRepository<Employee>(context)
{
    protected override void UpdateEntity(Employee oldEntity, Employee newEntity)
    {
        oldEntity.Name = newEntity.Name;
        oldEntity.Position = newEntity.Position;
        oldEntity.Salary = newEntity.Salary;
        oldEntity.HireDate = newEntity.HireDate;
        oldEntity.DepartmentId = newEntity.DepartmentId;
    }
    protected void DeleteAdditionalDependencies()
    {
        throw new NotImplementedException();
    }
}