using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * A question set.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */

    [DataContract]
    public class Exam
    {
        /**
         * Gets or sets the identifier of the exam.
         *
         * @return  The identifier of the exam.
         */

        [DataMember]
        public int ExamId { get; set; }

        /**
         * Gets or sets the title.
         *
         * @return  The title.
         */
        [DataMember]
        public string Title { get; set; }

        /**
         * Gets or sets the sections.
         *
         * @return  The sections.
         */

        [DataMember]
        public virtual ICollection<ExamSection> Sections { get; set; }
    }
}