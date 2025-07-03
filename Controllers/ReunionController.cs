using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaApi.Models; 
using AgendaApi.Data;

[ApiController]
[Route("api/[controller]")]
public class ReunionesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReunionesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Aquí vienen los endpoints CRUD

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reunion>>> GetReuniones()
    {
        return await _context.Reuniones.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reunion>> GetReunion(int id)
    {
        var reunion = await _context.Reuniones.FindAsync(id);
        if (reunion == null)
            return NotFound();

        return reunion;
    }

    [HttpPost]
    public async Task<ActionResult<Reunion>> PostReunion(Reunion reunion)
    {
        _context.Reuniones.Add(reunion);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReunion), new { id = reunion.Id }, reunion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutReunion(int id, Reunion reunion)
    {
        if (id != reunion.Id)
            return BadRequest();

        _context.Entry(reunion).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReunion(int id)
    {
        var reunion = await _context.Reuniones.FindAsync(id);
        if (reunion == null)
            return NotFound();

        _context.Reuniones.Remove(reunion);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}
