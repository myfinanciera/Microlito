using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class ConflictException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private ConflictException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 409 ConflictException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public ConflictException(string details = null) : base(StatusCodes.Status409Conflict, "Conflict",
            details)
        {
        }

        /// <summary>
        ///     Create 409 ConflictException
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public ConflictException(string code, string message, string details = null) : base(StatusCodes.Status409Conflict,
            message, details, code)
        {
        }
    }
}

