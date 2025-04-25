using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.Api.Model;
using Microsoft.AspNetCore.Cors;

namespace Employee.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowCors")]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeMasterController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeMaster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeData>>> GetEmployees()
        {

            return await _context.EmployeeData.ToListAsync();
        }

        // GET: api/EmployeeMaster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeData>> GetEmployee(int id)
        {
            var employee = await _context.EmployeeData.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // GET: api/EmployeeMaster/queryparam
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<EmployeeData>>> GetEmployees([FromQuery] string param)
        //{
        //    if(param == null)
        //    {
        //        return await _context.EmployeeData.ToListAsync();
        //    }

        //    var employees = await _context.EmployeeData.Where(x=>x.firstName.Contains(param)).ToListAsync();

        //    if (employees.Count()==0)
        //    {
        //        return NotFound();
        //    }

        //    return  employees;
        //}


        // PUT: api/EmployeeMaster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, EmployeeData employee)
        {
            if (id != employee.employeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeMaster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeData>> PostEmployee(EmployeeData employee)
        {
            _context.EmployeeData.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.employeeId }, employee);
        }

        // DELETE: api/EmployeeMaster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.EmployeeData.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.EmployeeData.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.EmployeeData.Any(e => e.employeeId == id);
        }
    }
}
