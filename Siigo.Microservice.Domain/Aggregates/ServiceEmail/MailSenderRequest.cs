using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Siigo.Microservice.Domain.Aggregates.ServiceEmail
{
    [DataContract]
    public class MailSenderRequest
    {
        [DataMember(Name = "ExternalSendID", EmitDefaultValue = false)]
        public string ExternalSendId { get; set; }

        [DataMember(Name = "From")]
        public UserMail From { get; set; }

        [DataMember(Name = "To")]
        public List<UserMail> To { get; set; }

        [DataMember(Name = "HTMLPart")]
        public string Body { get; set; }

        [DataMember(Name = "Subject")]
        public string Subject { get; set; }
    }

    [DataContract]
    public class UserMail
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }
    }
}
