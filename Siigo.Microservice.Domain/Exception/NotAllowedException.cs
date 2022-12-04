using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class NotAllowedException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private NotAllowedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 405 NotAllowedException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public NotAllowedException(string details = null) : base(StatusCodes.Status405MethodNotAllowed,
            "Method Not Allowed",
            details)
        {
        }
    }
}

