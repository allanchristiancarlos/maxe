using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * A question set step.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */
    [DataContract]
    public class ExamSection
    {
        /**
         * Gets or sets the identifier of the exam section.
         *
         * @return  The identifier of the exam section.
         */

        [DataMember]
        public int ExamSectionId { get; set; }

        /**
         * Gets or sets the title.
         *
         * @return  The title.
         */
        [DataMember]
        public string Title { get; set; }

        /**
         * Gets or sets the identifier of the exam.
         *
         * @return  The identifier of the exam.
         */

        [IgnoreDataMember]
        public int ExamId { get; set; }


        /**
         * Gets or sets the set the question belongs to.
         *
         * @return  The question set.
         */
        [IgnoreDataMember]
        public virtual Exam Exam { get; set; }

        /**
         * Gets or sets the order.
         *
         * @return  The order.
         */
        [DataMember]
        public int Order { get; set; }

        /**
         * Gets or sets the questions.
         *
         * @return  The questions.
         */
        [DataMember]
        public virtual ICollection<Question> Questions { get; set; }
    }
}