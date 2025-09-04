using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ImageApiController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [Authorize]
        [HttpPost("upload/question/{questionId}")]
        public async Task<IActionResult> UploadQuestionImage(int questionId, IFormFile file)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null) return NotFound("Question not found");

            if (question.Status != "Approved")
            {
                return BadRequest(new { message = "Cannot upload images until this question is approved by an Admin." });
            }

            if (file == null || file.Length == 0) return BadRequest("Invalid file");

            // Save file to /uploads
            var uploadsDir = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");
            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new Image
            {
                QuestionId = questionId,
                ImagePath = $"/uploads/{fileName}"
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return Ok(new { image.ImageId, image.ImagePath });
        }

        [Authorize]
        [HttpPost("upload/answer/{answerId}")]
        public async Task<IActionResult> UploadAnswerImage(int answerId, IFormFile file)
        {
            var answer = await _context.Answers.FindAsync(answerId);

            
            if (answer == null) return NotFound("Answer not found");

            if (answer.Question == null || answer.Question.Status != "Approved")
                return BadRequest(new { message = "Cannot upload images until the parent question is approved." });


            if (answer.Status != "Approved")
                return BadRequest(new { message = "Cannot upload images until this answer is approved by an Admin." });

            if (file == null || file.Length == 0) return BadRequest("Invalid file");

            var uploadsDir = Path.Combine(_env.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "uploads");
            if (!Directory.Exists(uploadsDir))
                Directory.CreateDirectory(uploadsDir);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsDir, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var image = new Image
            {
                AnswerId = answerId,
                ImagePath = $"/uploads/{fileName}"
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return Ok(new { image.ImageId, image.ImagePath });
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetQuestionImages(int questionId)
        {
            var images = await _context.Images
                .Where(i => i.QuestionId == questionId)
                .ToListAsync();

            return Ok(images);
        }

        [HttpGet("answer/{answerId}")]
        public async Task<IActionResult> GetAnswerImages(int answerId)
        {
            var images = await _context.Images
                .Where(i => i.AnswerId == answerId)
                .ToListAsync();

            return Ok(images);
        }
    }
}
