using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace Siigo.Microservice.Domain.Aggregates.ServiceEmail
{

    [DataContract]
    public class MailSenderResponse
    {
        [DataMember(Name = "Messages")]
        public List<MailSenderMessageResponse> Messages { get; set; }
    }


    [DataContract]
    public class MailSenderMessageResponse
    {
        [DataMember(Name = "Status")]
        public string Status { get; set; }

        [DataMember(Name = "Message")]
        public string Message { get; set; }

        [DataMember(Name = "To")]
        public List<MailSentDetails> To { get; set; }

    }


    [DataContract]
    public class MailSentDetails
    {
        [DataMember(Name = "Status")]
        public bool Status { get; set; }

        [DataMember(Name = "Email")]
        public string Email { get; set; }

        [DataMember(Name = "MessageUUID")]
        public string MessageUuid { get; set; }

        [DataMember(Name = "MessageID")]
        public string MessageId { get; set; }

        [DataMember(Name = "MessageHref")]
        public string MessageHref { get; set; }

        [DataMember(Name = "ErrorReason")]
        public string ErrorReason { get; set; }
    }
}
