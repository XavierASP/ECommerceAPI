using AutoMapper;
using ECommerceAPI.Data;
using ECommerceAPI.DTO;
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
        private readonly IMapper _mapper;

        public EmployeeController(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeReadDTO>>> Get()
        {
            var employees = await _repository.GetAll();
            var employeesDTO = _mapper.Map<IEnumerable<EmployeeReadDTO>>(employees);

            return Ok(employeesDTO);
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
            var oldEmployee = _repository.Get(employee.Id);
            if (oldEmployee == null)
            {
                _repository.Add(employee);

                return CreatedAtRoute("GetEmployeeById",
                new { id = employee.Id },
                 employee);
            }
            else
            {

                _repository.Update(employee);
                return NoContent();
            }
            //if (id != employee.Id)
            //{
                
            //    return BadRequest();
            //}
            //_repository.Update(employee);
            //return NoContent();

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
            return NoContent();

        }
    }
}
