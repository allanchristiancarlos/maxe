using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Maxe.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Maxe.Api.Models
{
    public class PostEntry
    {
        /**
         * Gets or sets the identifier of the exam.
         *
         * @return  The identifier of the exam.
         */
        [Required]
        public int ExamId { get; set; }


        /**
         * Gets or sets the identifier of the examinee.
         *
         * @return  The identifier of the examinee.
         */
        [Required]
        public int ExamineeId { get; set; }

        /**
         * Gets or sets the answers.
         *
         * @return  The answers.
         */

        [Required]
        public ListAnswer Answers { get; set; }
    }
}