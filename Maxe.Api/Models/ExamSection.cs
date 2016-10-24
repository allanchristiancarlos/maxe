using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Maxe.Api.Models
{
    public class ListAnswer
    {
        [Required]
        public List<SingleAnswer> Answers;
    }

    public class SingleAnswer
    {
        [Required]
        public int QuestionId { get; set; }

        public string ValueString { get; set; }
        public Nullable<int> ValueInt { get; set; }
        public List<string> ListString { get; set; }
        public List<int> ListInt { get; set; }
    }
}