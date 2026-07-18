using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    private readonly AppDbContext _context;

    public StatusController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Status
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Status>>> GetAll()
    {
        return await _context.Statuses.ToListAsync();
    }

    // GET: api/Status/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Status>> GetById(int id)
    {
        var status = await _context.Statuses.FindAsync(id);

        if (status == null)
            return NotFound();

        return status;
    }

    // POST: api/Status
    [HttpPost]
    public async Task<ActionResult<Status>> Create(Status status)
    {
        _context.Statuses.Add(status);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById),
            new { id = status.Id }, status);
    }

    // PUT: api/Status/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Status status)
    {
        if (id != status.Id)
            return BadRequest();

        _context.Entry(status).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Status/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var status = await _context.Statuses.FindAsync(id);

        if (status == null)
            return NotFound();

        _context.Statuses.Remove(status);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}