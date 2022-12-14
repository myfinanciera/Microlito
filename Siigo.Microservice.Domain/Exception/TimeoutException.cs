using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class TimeoutException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private TimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 408 TimeoutException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public TimeoutException(string details = null) : base(StatusCodes.Status408RequestTimeout, "Request Timeout",
            details)
        {
        }

        /// <summary>
        ///     Create 408 TimeoutException
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        /// <param name="source"></param>
        public TimeoutException(string code, string message, string details = null) : base(
            StatusCodes.Status408RequestTimeout, message, details, code)
        {
        }
    }
}

