using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using MyFirstAPI.Model;
using MyFirstAPI.ViewModel;

namespace MyFirstAPI.Controllers
{
	[ApiController]
	[Route("api/v1/employee")]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		//get
		[HttpGet]
		public IActionResult Get()
		{
			var employees = _employeeRepository.Get();
			return Ok(employees);
		}

		//post
		[HttpPost]
		public IActionResult Add(EmployeeViewModel employeeView)
		{
			var employee = new Employee(employeeView.Id, employeeView.Name, employeeView.Email, employeeView.BaseSalary, employeeView.BirthDate);
			_employeeRepository.Add(employee);
			return Ok();
		}
	}
}
