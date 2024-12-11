using HrManagement.DataAccess.Data;
using HrManagement.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
namespace HrManagement.Controllers;
[ApiController]
[Route("[controller]")]
public class TestController: Controller
{
    [HttpGet]
    public IActionResult Test()
    {
        EmployeeRepository e = new EmployeeRepository(new HrManagementDbContext());
        return Ok(e.GetById(1));
    }
}