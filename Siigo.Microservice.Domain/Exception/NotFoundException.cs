using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class NotFoundException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 404 NotFoundException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public NotFoundException(string details = null) : base(StatusCodes.Status404NotFound, "Resource Not Found",
            details)
        {
        }

        /// <summary>
        ///     Create 404 NotFoundException
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public NotFoundException(string code, string message, string details = null) : base(StatusCodes.Status404NotFound,
            message, details, code)
        {
        }
    }
}

