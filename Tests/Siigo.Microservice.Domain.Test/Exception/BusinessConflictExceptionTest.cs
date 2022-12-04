using Microsoft.AspNetCore.Http;
using Siigo.Microservice.Domain.Exception;
using Xunit;

namespace Siigo.Microservice.Domain.Test.Exception
{
    public sealed class BusinessConflictExceptionTest
    {
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new BusinessException("code", "message");
            Assert.Equal(StatusCodes.Status409Conflict, exception.StatusCode);

        }
    }
}