using System;
using System.ComponentModel.DataAnnotations;

namespace Maxe.Api.Models
{
    public class PostQuestion
    {
        [Required]
        public int QuestionTypeId { get; set; }

        [Required]
        public int ExamSectionId { get; set; }

        [Required]
        public string Label { get; set; }

        public int Order { get; set; }

        public string RightAnswer { get; set; }
    }
}