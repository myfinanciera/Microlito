using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class NotAcceptableException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private NotAcceptableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 406 NotAcceptableException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public NotAcceptableException(string details = null) : base(StatusCodes.Status406NotAcceptable,
            "Not Acceptable",
            details)
        {
        }
    }
}

