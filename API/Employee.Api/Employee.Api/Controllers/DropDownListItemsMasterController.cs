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
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("allowCors")]
    public class DropDownListItemsMasterController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public DropDownListItemsMasterController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/DropDownListItemsMaster/queryparam
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DropDownListItems>>> GetDropDownListItems([FromQuery] string param)
        {            
            if (param == null)
            {
                return NotFound();
            }

            var ddlitems = await _context.DropDownListItems.Where(x => x.itemType.Contains(param)).ToListAsync();

            if (ddlitems.Count() == 0)
            {
                return NotFound();
            }

            return ddlitems;
        }


        // GET: api/DropDownListItemsMaster/GetAllDDLItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DropDownListItems>>> GetAllDDLItems()
        {
             return await _context.DropDownListItems.ToListAsync();
        }

        // GET: api/DropDownListItemsMaster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DropDownListItems>> GetDropDownListItems(int id)
        {
            var dropDownListItems = await _context.DropDownListItems.FindAsync(id);

            if (dropDownListItems == null)
            {
                return NotFound();
            }

            return dropDownListItems;
        }

        // PUT: api/DropDownListItemsMaster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDropDownListItems(int id, DropDownListItems dropDownListItems)
        {
            // if (id != dropDownListItems.ddlistId)
            if (id != dropDownListItems.id)
            {
                return BadRequest();
            }

            _context.Entry(dropDownListItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DropDownListItemsExists(id))
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

        // POST: api/DropDownListItemsMaster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DropDownListItems>> PostDropDownListItems(DropDownListItems dropDownListItems)
        {
            _context.DropDownListItems.Add(dropDownListItems);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetDropDownListItems", new { id = dropDownListItems.ddlistId }, dropDownListItems);
            return CreatedAtAction("GetDropDownListItems", new { id = dropDownListItems.id }, dropDownListItems);
        }

        // DELETE: api/DropDownListItemsMaster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDropDownListItems(int id)
        {
            var dropDownListItems = await _context.DropDownListItems.FindAsync(id);
            if (dropDownListItems == null)
            {
                return NotFound();
            }

            _context.DropDownListItems.Remove(dropDownListItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DropDownListItemsExists(int id)
        {
            //return _context.DropDownListItems.Any(e => e.ddlistId == id);
            return _context.DropDownListItems.Any(e => e.id == id);
        }
    }
}
