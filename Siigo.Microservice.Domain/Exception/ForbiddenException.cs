using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class ForbiddenException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private ForbiddenException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        /// <summary>
        ///     Create 403 ForbiddenException
        /// </summary>
        /// <param name="message"></param>
        /// <param name="details"></param>
        public ForbiddenException(string details = null) : base(StatusCodes.Status403Forbidden, "Forbidden",
            details)
        {
        }
    }
}

