using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * A question.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */
    [DataContract]
    public class Question
    {
        /**
         * Gets or sets the identifier of the question.
         *
         * @return  The identifier of the question.
         */
        [DataMember]
        public int QuestionId { get; set; }

        /**
         * Gets or sets the label.
         *
         * @return  The label.
         */
        [DataMember]
        public string Label { get; set; }

        /**
         * Gets or sets the right answer.
         *
         * @return  The right answer.
         */
        [IgnoreDataMember]
        public string RightAnswer { get; set; }

        /**
         * Gets or sets the order.
         *
         * @return  The order.
         */
        [DataMember]
        public int Order { get; set; }

        /**
         * Gets or sets the identifier of the question type.
         *
         * @return  The identifier of the question type.
         */
        [IgnoreDataMember]
        public int QuestionTypeId { get; set; }

        /**
         * Gets or sets the identifier of the question set.
         *
         * @return  The identifier of the question set.

        /**
         * Gets or sets the type of the question.
         *
         * @return  The type of the question.
         */

        [DataMember]
        public virtual QuestionType QuestionType { get; set; }


        /**
         * Gets or sets the identifier of the exam section.
         *
         * @return  The identifier of the exam section.
         */
        [IgnoreDataMember]
        public int ExamSectionId { get; set; }

        /**
         * Gets or sets the exam section.
         *
         * @return  The exam section.
         */

        [IgnoreDataMember]
        public virtual ExamSection ExamSection { get; set; }

        /**
         * Gets or sets options for controlling the question.
         *
         * @return  Options that control the question.
         */

        [DataMember]
        public virtual ICollection<QuestionOption> QuestionOptions { get; set; }

        /**
         * Gets or sets the groups the option belongs to.
         *
         * @return  The option groups.
         */

        [DataMember]
        public virtual ICollection<OptionGroup> OptionGroups { get; set; }

        /**
         * Gets or sets a value indicating whether the required.
         *
         * @return  True if required, false if not.
         */

        [DataMember]
        public bool Required { get; set; }
    }
}