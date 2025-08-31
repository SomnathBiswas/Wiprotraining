using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Secure_Note_Taking_Api.Data;
using Secure_Note_Taking_Api.DataTranferObjects;
using Secure_Note_Taking_Api.Models;
using System.Security.Claims;

namespace Secure_Note_Taking_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NotesController : ControllerBase
    {
        private readonly SecureNoteDbContext _db;
        public NotesController(SecureNoteDbContext db) => _db = db;

        private int GetUserId()
        {
            var idClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return idClaim != null ? int.Parse(idClaim) : 0;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Note dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title) || string.IsNullOrWhiteSpace(dto.Content))
                return BadRequest(new { message = "Title & Content needed" });

            var note = new NoteModel
            {
                Title = dto.Title,
                Content = dto.Content,
                UserId = GetUserId()
            };

            _db.Notes.Add(note);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Note added successfully.", noteId = note.Id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var newuserId = GetUserId();
            var notes = await _db.Notes
                                 .Where(n => n.UserId == newuserId)
                                 .Select(n => new { n.Id, n.Title, n.Content })
                                 .ToListAsync();

            return Ok(notes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Note dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title) || string.IsNullOrWhiteSpace(dto.Content))
                return BadRequest(new { message = "Title & Content needed" });

            var newuserId1 = GetUserId();
            var note = await _db.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == newuserId1);
            if (note == null) return NotFound();

            note.Title = dto.Title;
            note.Content = dto.Content;
            await _db.SaveChangesAsync();

            return Ok(new { message = "Note updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var newuserId2 = GetUserId();
            var note = await _db.Notes.FirstOrDefaultAsync(n => n.Id == id && n.UserId == newuserId2);
            if (note == null) return NotFound();

            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Note deleted successfully." });
        }
    }
}
