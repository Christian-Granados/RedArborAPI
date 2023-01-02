using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedArbor.Employees.API.Models;
using RedArbor.Employees.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace RedArbor.Employees.API.Controllers
{
    [Route("api/redarbor")]
    public class RedArborController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeCore _employeeCore;
        private readonly ILogger<RedArborController> _logger;
        public RedArborController(IMapper mapper, IEmployeeCore employeeCore, ILogger<RedArborController> logger)
        {
            _mapper = mapper;
            _employeeCore = employeeCore;
            _logger = logger;
        }
        // Get all employees items
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            try
            {
                return _mapper.Map<List<Employee>>(_employeeCore.GetEmployees());
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, exception.Message);
            }
        }

        // Get an item by ID
        [HttpGet("{id:int}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            try
            {
                return _mapper.Map<Employee>(_employeeCore.GetEmployee(id));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, exception.Message);
            }
        }

        // Add a new item
        [HttpPost]
        public ActionResult<Employee> AddNewEmployee([FromBody] Employee newEmployee)
        {
            try
            {
                return _mapper.Map<Employee>(_employeeCore.AddEmployee(_mapper.Map<Core.Models.Employee>(newEmployee)));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, exception.Message);
            }
        }

        // Update an existing item
        [HttpPut("{id:int}")]
        public ActionResult EditEmployee([FromBody] Employee editedEmployee, [FromRoute] int id)
        {
            try
            {
                if (id != editedEmployee.Id) throw new ArgumentException("Los IDs de los elementos a modificar no coinciden");

                _employeeCore.UpdateEmployee(_mapper.Map<Core.Models.Employee>(editedEmployee), id);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, exception.Message);
            }
        }

        // GET: Delete an item
        [HttpDelete("{id:int}")]
        public ActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                _employeeCore.DeleteEmployee(id);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return StatusCode(500, exception.Message);
            }
        }
    }
}
