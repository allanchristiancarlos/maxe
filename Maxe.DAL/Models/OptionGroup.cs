using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * An option group.
     *
     * @author  Allan.carlos
     * @date    10/18/2016
     */

    [DataContract]
    public class OptionGroup
    {
        /**
         * Gets or sets the identifier of the option group.
         *
         * @return  The identifier of the option group.
         */
        [DataMember]
        public int OptionGroupId { get; set; }

        /**
         * Gets or sets the name.
         *
         * @return  The name.
         */
        [DataMember]
        public string Name { get; set; }

        /**
         * Gets or sets the identifier of the question.
         *
         * @return  The identifier of the question.
         */

        [DataMember]
        public int QuestionId { get; set; }

        /**
         * Gets or sets the question.
         *
         * @return  The question.
         */

        [IgnoreDataMember]
        public virtual Question Question { get; set; }

        /**
         * Gets or sets the option choices.
         *
         * @return  The option choices.
         */

        [DataMember]
        public virtual ICollection<OptionChoice> OptionChoices { get; set; }
    }
}