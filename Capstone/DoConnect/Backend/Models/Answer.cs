using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }

        [ForeignKey("Question")]
        [Required]
        public int QuestionId { get; set; } 

        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string AnswerText { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Question Question { get; set; } = null!;
        public User User { get; set; } = null!;
        // public ICollection<Image> Images { get; set; }
    }
}