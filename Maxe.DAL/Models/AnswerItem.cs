using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * An answer item.
     *
     * @author  Allan.carlos
     * @date    10/24/2016
     */

    public class AnswerItem
    {
        [DataMember]
        public Nullable<int> AnswerItemId { get; set; }
        /**
         * Gets or sets the item number value.
         *
         * @return  The item number value.
         */
        [DataMember]
        public int NumberValue { get; set; }

        /**
         * Gets or sets the item string value.
         *
         * @return  The item string value.
         */
        [DataMember]
        public string StringValue { get; set; }

        /**
         * Gets or sets the identifier of the answer.
         *
         * @return  The identifier of the answer.
         */
        [DataMember]
        public Nullable<int> AnswerId { get; set; }

        /**
         * Gets or sets the answer.
         *
         * @return  The answer.
         */

        [IgnoreDataMember]
        public virtual Answer Answer { get; set; }
    }
}