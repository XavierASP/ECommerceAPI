using ECommerceAPI.Data;
using ECommerceAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepository<Employee> _repository;

        public EmployeeController(IRepository<Employee> repository)
        {
            _repository = repository;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = _repository.GetAll();
            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = _repository.Get(id);
            if (employee != null)
                return Ok(employee);
            else
                return NotFound();
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            _repository.Add(employee);
            return CreatedAtRoute("GetEmployeeById",
                new { id = employee.Id },
                 employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id) 
            {
                return BadRequest();
            }
            _repository.Update(employee);
            return NoContent();

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = _repository.Get(id);
            if (employee == null) 
            {
                return NotFound();
            }
            _repository.Delete(id);
            return Ok();

        }
    }
}
