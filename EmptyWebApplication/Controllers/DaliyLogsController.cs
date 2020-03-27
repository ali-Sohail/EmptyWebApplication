using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Context;

namespace EmptyWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaliyLogsController : ControllerBase
    {
        private readonly UsersDBContext _context;

        public DaliyLogsController(UsersDBContext context)
        {
            _context = context;
        }

        // GET: api/DaliyLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DaliyLog>>> GetDaliyLogs()
        {
            return await _context.DaliyLog.ToListAsync();
        }

        // GET: api/DaliyLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DaliyLog>> GetDaliyLog(int id)
        {
            var daliyLog = await _context.DaliyLog.FindAsync(id);

            if (daliyLog == null)
            {
                return NotFound();
            }

            return daliyLog;
        }

        // PUT: api/DaliyLogs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaliyLog(int id, DaliyLog daliyLog)
        {
            if (id != daliyLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(daliyLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DaliyLogExists(id))
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

        // POST: api/DaliyLogs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DaliyLog>> PostDaliyLog(DaliyLog daliyLog)
        {
            _context.DaliyLog.Add(daliyLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDaliyLog", new { id = daliyLog.Id }, daliyLog);
        }

        // DELETE: api/DaliyLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DaliyLog>> DeleteDaliyLog(int id)
        {
            var daliyLog = await _context.DaliyLog.FindAsync(id);
            if (daliyLog == null)
            {
                return NotFound();
            }

            _context.DaliyLog.Remove(daliyLog);
            await _context.SaveChangesAsync();

            return daliyLog;
        }

        private bool DaliyLogExists(int id)
        {
            return _context.DaliyLog.Any(e => e.Id == id);
        }
    }
}
