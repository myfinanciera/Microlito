using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Siigo.Microservice.Domain.Exception
{
    [Serializable]
    public sealed class BusinessException : ClientErrorException
    {
        [ExcludeFromCodeCoverage]
        private BusinessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BusinessException(
            string code, string message, string details = null
        ) : base(StatusCodes.Status409Conflict, message, details, code)
        {
        }
    }
}

