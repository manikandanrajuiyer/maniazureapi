using FluentValidation;
using Mani.Azure.Api.Business.Interfaces;
using Mani.Azure.Api.Common.Validators;
using Mani.Azure.Api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Mani.Azure.Api.Sample.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusinessLayer _empBusinessLayer;

        private readonly IEmployeeValidator _validator;

        
        public EmployeeController(IEmployeeBusinessLayer employeeBusinessLayer, IEmployeeValidator validator)
        {
            _empBusinessLayer = employeeBusinessLayer;
            _validator = validator;
        }

        [HttpPost]
        [Produces(typeof(Employee))]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee empData)
        {

            try
            {
                _validator.Validate(empData);

                Employee emp = await _empBusinessLayer.InsertEmployee(empData);
                return Ok(emp);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { empData, ex.Message });
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { ErrorMsg = ex.Message });
            }
        }
    }
}
