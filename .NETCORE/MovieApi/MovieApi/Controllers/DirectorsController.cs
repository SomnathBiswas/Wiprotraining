using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

[ApiController]
[Route("api/[controller]")]
public class DirectorsController : ControllerBase
{
    private readonly AppDbContext _context;
    public DirectorsController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Directors.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var director = await _context.Directors.FindAsync(id);
        return director is null ? NotFound() : Ok(director);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Director director)
    {
        _context.Directors.Add(director);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = director.Id }, director);
    }

    [HttpGet("{id}/movies")]
    public async Task<IActionResult> GetMoviesByDirector(int id)
    {
        var movies = await _context.Movies.Where(m => m.DirectorId == id).ToListAsync();
        return movies.Any() ? Ok(movies) : NotFound();
    }
}
