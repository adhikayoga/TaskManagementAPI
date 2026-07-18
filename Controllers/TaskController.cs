using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly AppDbContext _context;

    public TaskController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Task
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> Get()
    {
        return await _context.Tasks
            .Include(t => t.Category)
            .Include(t => t.Status)
            .ToListAsync();
    }

    // GET: api/Task/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TaskItem>> Get(int id)
    {
        var task = await _context.Tasks
            .Include(t => t.Category)
            .Include(t => t.Status)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (task == null)
            return NotFound();

        return task;
    }

    // POST: api/Task
    [HttpPost]
    public async Task<ActionResult<TaskItem>> Post(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    // PUT: api/Task/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TaskItem task)
    {
        if (id != task.Id)
            return BadRequest();

        _context.Entry(task).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Task/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return NotFound();

        task.IsDeleted = true;

        await _context.SaveChangesAsync();

        return NoContent();
    }
}