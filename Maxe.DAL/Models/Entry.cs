using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Maxe.DAL.Models
{
    /**
     * An answer set.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */

    public class Entry
    {
        /**
         * Gets or sets the identifier of the entry.
         *
         * @return  The identifier of the entry.
         */
        [DataMember]
        public int EntryId { get; set; }

        /**
         * Gets or sets the identifier of the exam.
         *
         * @return  The identifier of the exam.
         */
        [DataMember]
        [Required]
        public int? ExamId { get; set; }

        /**
         * Gets the exam.
         *
         * @return  The exam.
         */
        [ForeignKey("ExamId")]
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Exam Exam { get; set; }

        /**
         * Gets or sets the Date/Time of the created at.
         *
         * @return  The created at.
         */
        [DataMember]
        public DateTime SubmittedAt { get; set; }

        /**
         * Gets or sets the identifier of the examinee.
         *
         * @return  The identifier of the examinee.
         */
        [DataMember]
        public int ExamineeId { get; set; }

        /**
         * Gets or sets the examinee.
         *
         * @return  The examinee.
         */
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Examinee Examinee { get; set; }

        /**
         * Gets or sets the answers.
         *
         * @return  The answers.
         */

        public virtual ICollection<Answer> Answers { get; set; } 
    }
}