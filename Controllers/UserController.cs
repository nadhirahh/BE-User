using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", message = ex.Message });
            }
        }

        // GET: api/user/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<User>> GetUser(int id)
        // {
        //     try
        //     {
        //         var user = await _context.Users.FindAsync(id);

        //         if (user == null)
        //         {
        //             return NotFound(new { error = "User not found", message = $"User with ID {id} not found" });
        //         }

        //         return Ok(user);
        //     }
        //     catch (Exception ex)
        //     {
        //         return StatusCode(500, new { error = "Internal server error", message = ex.Message });
        //     }
        // }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            try
            {
                // Check for duplicate email
                if (_context.Users.Any(u => u.Mail == user.Mail))
                {
                    return Conflict(new { error = "Email already exists", message = "A user with the same email already exists" });
                }

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", message = ex.Message });
            }
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            try
            {
                // Check for duplicate email
                if (_context.Users.Any(u => u.Mail == user.Mail && u.Id != id))
                {
                    return Conflict(new { error = "Email already exists", message = "A user with the same email already exists" });
                }

                if (id != user.Id)
                {
                    return BadRequest(new { error = "Invalid user ID", message = "The provided user ID does not match the route parameter" });
                }

                _context.Entry(user).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound(new { error = "User not found", message = $"User with ID {id} not found" });
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", message = ex.Message });
            }
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound(new { error = "User not found", message = $"User with ID {id} not found" });
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error", message = ex.Message });
            }
        }

        // private bool UserExists(int id)
        // {
        //     return _context.Users.Any(e => e.Id == id);
        // }
    }
}
