using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{

    protected const int InitialBalance = 300;
    private readonly UsersContext _context;

    public UsersController(UsersContext context)
    {
        _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
    {
        return await _context.Users
            .Select(x => UserToDTO(x))
            .ToListAsync();
    }

    // GET: api/User/5
    // <snippet_GetByID>
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUser(uint id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return UserToDTO(user);
    }
    // </snippet_GetByID>

    // PUT: api/User/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Update>
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(uint id, UserDTO userDTO)
    {
        if (id != userDTO.Id)
        {
            return BadRequest();
        }

        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        user.Name = userDTO.Name;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!UserExists(id, _context))
        {
            return NotFound();
        }

        return NoContent();
    }
    // </snippet_Update>

    // POST: api/User
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // <snippet_Create>
    [HttpPost]
    public async Task<ActionResult<UserDTO>> PostUser(UserDTO userDTO)
    {
        // Проверяем, что ID передан и его еще нет в базе
        if (userDTO.Id == 0 || UserExists(userDTO.Id, _context))
        {
            return Conflict("User already exists or invalid ID.");
        }

        var user = new User
        {
            Id = userDTO.Id,  // Используем переданный ID
            Balance = InitialBalance,
            Name = userDTO.Name
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetUsers),
            new { id = user.Id },
            UserToDTO(user));
    }

    // </snippet_Create>

    // DELETE: api/TodoItems/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(uint id)
    {
        var todoItem = await _context.Users.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Users.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    public static bool UserExists(uint id, UsersContext _context)
    {
        return _context.Users.Any(e => e.Id == id);
    }

    private static UserDTO UserToDTO(User user) =>
       new UserDTO
       {
           Id = user.Id,
           Name = user.Name,
       };
}