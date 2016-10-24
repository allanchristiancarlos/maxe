using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Maxe.DAL.Models
{
    /**
     * An examinee.
     *
     * @author  Allan.carlos
     * @date    10/17/2016
     */
    [DataContract]
    public class Examinee
    {
        /**
         * Gets or sets the identifier of the examinee.
         *
         * @return  The identifier of the examinee.
         */
        [DataMember]
        public int ExamineeId { get; set; }

        /**
         * Gets or sets the person's first name.
         *
         * @return  The name of the first.
         */
        [DataMember]
        public string FirstName { get; set; }

        /**
         * Gets or sets the person's last name.
         *
         * @return  The name of the last.
         */
        [DataMember]
        public string LastName { get; set; }

        /**
         * Gets or sets the email.
         *
         * @return  The email.
         */
        [DataMember]
        public string Email { get; set; }

        /**
         * Gets or sets the phone number.
         *
         * @return  The phone number.
         */
        [DataMember]
        public string PhoneNumber { get; set; }

        /**
         * Gets or sets the exams.
         *
         * @return  The exams.
         */

        [IgnoreDataMember]
        public virtual ICollection<Exam> Exams { get; set; }
    }
}