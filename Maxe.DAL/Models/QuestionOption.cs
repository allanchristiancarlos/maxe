using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    public class QuestionOption
    {
        /**
         * Gets or sets the identifier of the question option.
         *
         * @return  The identifier of the question option.
         */
        [DataMember]
        public int QuestionOptionId { get; set; }

        /**
         * Gets or sets the identifier of the question.
         *
         * @return  The identifier of the question.
         */

        [IgnoreDataMember]
        public int QuestionId { get; set; }


        /**
         * Gets or sets the identifier of the option choice.
         *
         * @return  The identifier of the option choice.
         */
        [IgnoreDataMember]
        public int OptionChoiceId { get; set; }

        /**
         * Gets or sets the option choice.
         *
         * @return  The option choice.
         */
        [DataMember]
        public virtual OptionChoice OptionChoice { get; set; }
    }
}