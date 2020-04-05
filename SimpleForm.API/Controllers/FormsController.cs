using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleForm.BLL;
using SimpleForm.DAL;

namespace SimpleForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        private readonly SimpleFormDbContext _context;

        public FormsController(SimpleFormDbContext context)
        {
            _context = context;
        }

        // GET: api/Forms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form>>> GetForms()
        {
            return await _context.Forms.Include(x => x.Sender).ToListAsync();
        }

        // GET: api/Forms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Form>> GetForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);

            if (form == null)
            {
                return NotFound();
            }

            return form;
        }

        // PUT: api/Forms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForm(int id, Form form)
        {
            if (id != form.Id)
            {
                return BadRequest();
            }

            _context.Entry(form).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormExists(id))
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

        // POST: api/Forms
        [HttpPost]
        public async Task<ActionResult<Form>> PostForm(Form form)
        {
            var user = new User();
            user.Email = form.Sender.Email;
            user.FirstName = form.Sender.FirstName;
            user.LastName = form.Sender.LastName;

            var userInDb = _context.Users.SingleOrDefaultAsync(u => u.Email == user.Email
                                                                && u.FirstName == user.FirstName
                                                                && u.LastName == user.LastName).Result;
            if (userInDb != null)
            {
                form.Sender.Id = userInDb.Id;
                form.UserId = userInDb.Id;
            }

            _context.Forms.Add(form);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForm", new { id = form.Id }, form);
        }

        // DELETE: api/Forms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Form>> DeleteForm(int id)
        {
            var form = await _context.Forms.FindAsync(id);
            if (form == null)
            {
                return NotFound();
            }

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();

            return form;
        }

        private bool FormExists(int id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
