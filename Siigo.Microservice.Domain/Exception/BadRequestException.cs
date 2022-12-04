using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class BadRequestException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private BadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 400 BadRequestException
        /// </summary>
        /// <param name="details"></param>
        public BadRequestException(string details = null) : base(StatusCodes.Status400BadRequest, "Bad Request",
            details)
        {
        }

        /// <summary>
        ///     Create 400 BadRequestException
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public BadRequestException(string code, string message, string details = null) : base(
            StatusCodes.Status400BadRequest, message, details, code)
        {
        }
    }
}