using Microsoft.AspNetCore.Http;
using Siigo.Microservice.Domain.Exception;
using Xunit;

namespace Siigo.Microservice.Domain.Test.Exception
{
    public sealed class UnauthorizedExceptionTest
    {
        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new UnauthorizedException("unauthorized", "Unauthorized");
            //Asserts
            Assert.Equal(StatusCodes.Status401Unauthorized, exception.StatusCode);
            Assert.Equal("unauthorized", exception.Code);
        }
    }
}
