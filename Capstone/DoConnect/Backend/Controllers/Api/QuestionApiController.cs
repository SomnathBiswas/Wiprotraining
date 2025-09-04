using Backend.Data;
using Backend.Models;
using Backend.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var questions = await _context.Questions
            .Include(q => q.User)
            .Include(q => q.Answers).ThenInclude(a => a.User)
            .Include(q => q.Images)
            .Select(q => new QuestionDto
            {
                QuestionId = q.QuestionId,
                QuestionTitle = q.QuestionTitle,
                QuestionText = q.QuestionText,
                Status = q.Status,
                CreatedAt = q.CreatedAt,
                Username = q.User.Username,
                ImagePaths = q.Images
                    .Select(img => $"{baseUrl}/uploads/{Path.GetFileName(img.ImagePath)}").ToList(),

                Answers = q.Answers.Select(a => new AnswerDto
                {
                    AnswerId = a.AnswerId,
                    QuestionId = a.QuestionId,
                    AnswerText = a.AnswerText,
                    Status = a.Status,
                    CreatedAt = a.CreatedAt,
                    Username = a.User.Username,
                    ImagePaths = a.Images
                        .Select(img => $"{baseUrl}/uploads/{Path.GetFileName(img.ImagePath)}").ToList()
                }).ToList()
            })
                .ToListAsync();

            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var projected = await _context.Questions
                .Include(q => q.User)
                .Include(q => q.Images) 
                .Include(q => q.Answers).ThenInclude(a => a.User)
                .Include(q => q.Answers).ThenInclude(a => a.Images)
                .Where(q => q.QuestionId == id)
                .Select(q => new QuestionDto
                {
                    QuestionId = q.QuestionId,
                    QuestionTitle = q.QuestionTitle,
                    QuestionText = q.QuestionText,
                    Status = q.Status,
                    CreatedAt = q.CreatedAt,
                    Username = q.User.Username,
                    ImagePaths = q.Images.Select(img => img.ImagePath).ToList(),
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        AnswerId = a.AnswerId,
                        QuestionId = a.QuestionId,
                        AnswerText = a.AnswerText,
                        Status = a.Status,
                        CreatedAt = a.CreatedAt,
                        Username = a.User.Username,
                        ImagePaths = a.Images.Select(img => img.ImagePath).ToList()

                    }).ToList()
                })
                .FirstOrDefaultAsync();


            if (projected == null) return NotFound();

            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            projected.ImagePaths = projected.ImagePaths
                .Select(p => $"{baseUrl}/uploads/Questions/{System.IO.Path.GetFileName(p)}")
                .ToList();

            foreach (var a in projected.Answers)
            {
                a.ImagePaths = a.ImagePaths
                    .Select(p => $"{baseUrl}/uploads/Answers/{System.IO.Path.GetFileName(p)}")
                    .ToList();
            }

            return Ok(projected);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            int userId = int.Parse(userIdClaim);

            var question = new Question
            {
                UserId = userId,
                QuestionTitle = dto.QuestionTitle,
                QuestionText = dto.QuestionText,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            var result = new QuestionDto
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                QuestionText = question.QuestionText,
                Status = question.Status,
                CreatedAt = question.CreatedAt,
                Username = (await _context.Users.FindAsync(userId))?.Username ?? "Unknown",
                Answers = new List<AnswerDto>()
            };


            return CreatedAtAction(nameof(GetQuestion), new { id = question.QuestionId }, result);
        }


        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] Question updatedQuestion)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();

            question.QuestionTitle = updatedQuestion.QuestionTitle;
            question.QuestionText = updatedQuestion.QuestionText;
            question.Status = updatedQuestion.Status;

            await _context.SaveChangesAsync();

            var result = new QuestionDto
            {
                QuestionId = question.QuestionId,
                QuestionTitle = question.QuestionTitle,
                QuestionText = question.QuestionText,
                Status = question.Status,
                CreatedAt = question.CreatedAt,
                Username = (await _context.Users.FindAsync(question.UserId))?.Username ?? "Unknown",
                Answers = new List<AnswerDto>()
            };
            // return Ok(question);
                return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions
                .Include(q => q.Images)
                .Include(q => q.Answers)
                    .ThenInclude(a => a.Images)
                .FirstOrDefaultAsync(q => q.QuestionId == id);

            if (question == null) return NotFound();

            // Delete images of answers
            foreach (var answer in question.Answers)
            {
                _context.Images.RemoveRange(answer.Images);
            }

            // Delete images of question
            _context.Images.RemoveRange(question.Images);

            // Delete answers
            _context.Answers.RemoveRange(question.Answers);

            // Delete question
            _context.Questions.Remove(question);

            await _context.SaveChangesAsync();

            return Ok(new { message = "Question deleted successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();

            question.Status = "Approved";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Question approved successfully" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/reject")]
        public async Task<IActionResult> RejectQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return NotFound();

            question.Status = "Rejected";
            await _context.SaveChangesAsync();

            return Ok(new { message = "Question rejected successfully" });
        }

    }
}
