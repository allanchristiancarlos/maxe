using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;

namespace Maxe.DAL.Models
{
    /**
     * An answer.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */

    public class Answer
    {
        /**
         * Gets or sets the identifier of the answer.
         *
         * @return  The identifier of the answer.
         */
        [DataMember]
        public int AnswerId { get; set; }

        /**
         * Gets or sets the answer value.
         *
         * @return  The answer value.
         */
        [DataMember]
        public Nullable<int> NumberValue { get; set; }

        /**
         * Gets or sets the answer string value.
         *
         * @return  The answer string value.
         */
        [DataMember]
        public string StringValue { get; set; }


        /**
         * Gets or sets the identifier of the question.
         *
         * @return  The identifier of the question.
         */
        [DataMember]
        [Required]
        public int QuestionId { get; set; }

        /**
         * Gets or sets the question.
         *
         * @return  The question.
         */
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Question Question { get; set; }

        /**
         * Gets or sets the identifier of the entry.
         *
         * @return  The identifier of the entry.
         */
        [DataMember]
        public int EntryId { get; set; }

        /**
         * Gets or sets the entry.
         *
         * @return  The entry.
         */
        [IgnoreDataMember]
        [JsonIgnore]
        public virtual Entry Entry { get; set; }

        /**
         * Gets or sets the answer items.
         *
         * @return  The answer items.
         */
        public virtual ICollection<AnswerItem> AnswerItems { get; set; }
    }
}