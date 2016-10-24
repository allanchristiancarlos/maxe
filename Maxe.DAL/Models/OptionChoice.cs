using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * An option choice.
     *
     * @author  Allan.carlos
     * @date    10/18/2016
     */
    [DataContract]
    public class OptionChoice
    {
        /**
         * Gets or sets the identifier of the option choice.
         *
         * @return  The identifier of the option choice.
         */
        [DataMember]
        public int OptionChoiceId { get; set; }

        /**
         * Gets or sets the name.
         *
         * @return  The name.
         */
        [DataMember]
        public string Name { get; set; }

        /**
         * Gets or sets the identifier of the option group.
         *
         * @return  The identifier of the option group.
         */

        [IgnoreDataMember]
        public int? OptionGroupId { get; set; }

        /**
         * Gets or sets the group the option belongs to.
         *
         * @return  The option group.
         */

        [IgnoreDataMember]
        public virtual OptionGroup OptionGroup { get; set; }
    }
}