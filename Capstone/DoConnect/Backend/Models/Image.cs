using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Image
    {
        public int ImageId { get; set; }

        public string ImagePath { get; set; } = string.Empty;

        public int? QuestionId { get; set; }
        public int? AnswerId { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public Question? Question { get; set; } 
        public Answer? Answer { get; set; }
    }
}