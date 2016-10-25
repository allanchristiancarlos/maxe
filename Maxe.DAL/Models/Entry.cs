using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;

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
         * Gets or sets the time stamp.
         *
         * @return  The time stamp.
         */
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        /**
         * Gets or sets the Date/Time of the created at.
         *
         * @return  The created at.
         */
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataMember]
        [DisplayName("Submitted At")]
        public DateTime? SubmittedAt { get; set; }


        /**
         * Gets or sets the person's first name.
         *
         * @return  The name of the first.
         */
        [DataMember, Required]
        [DisplayName("First Name")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters only")]
        public string FirstName { get; set; }

        /**
         * Gets or sets the person's last name.
         *
         * @return  The name of the last.
         */
        [DataMember, Required]
        [DisplayName("Last Name")]
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters only")]
        public string LastName { get; set; }

        /**
         * Gets or sets the email.
         *
         * @return  The email.
         */

        [DataMember, Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        /**
         * Gets or sets the position.
         *
         * @return  The position.
         */

        [DataMember, Required]
        [DisplayName("Position")]
        public string Position { get; set; }

        /**
         * Gets or sets the mobile number.
         *
         * @return  The mobile number.
         */

        [DataMember, Required]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile Number")]
        [Phone]
        public string MobileNumber { get; set; }

        /**
         * Gets or sets the address.
         *
         * @return  The address.
         */
        [DataMember]
        [DisplayName("Address")]
        public string Address { get; set; }

        /**
         * Gets or sets the duration in minutes.
         *
         * @return  The duration in minutes.
         */
        [DataMember]
        [DisplayName("Duration In Minutes")]
        public Nullable<int> DurationInMinutes { get; set; }

        /**
         * Gets or sets the answers.
         *
         * @return  The answers.
         */

        public virtual ICollection<Answer> Answers { get; set; } 
    }
}