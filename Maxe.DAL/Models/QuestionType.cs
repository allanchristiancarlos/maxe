using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * A question type.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */
    [DataContract]
    public class QuestionType
    {
        /**
         * Gets or sets the identifier of the question type.
         *
         * @return  The identifier of the question type.
         */
        [DataMember]
        public int QuestionTypeId { get; set; }

        /**
         * Gets or sets the name of the friendly.
         *
         * @return  The name of the friendly.
         */
        [DataMember]
        public string FriendlyName { get; set; }

        /**
         * Gets or sets the name.
         *
         * @return  The name.
         */
        [DataMember]
        public string Name { get; set; }

        /**
         * Gets or sets the description.
         *
         * @return  The description.
         */
        [DataMember]
        public string Description { get; set; }

        /**
         * Gets or sets the questions.
         * 
         *
         * @return  The questions.
         */
        [IgnoreDataMember]
        public virtual ICollection<Question> Questions { get; set; }
    }
}