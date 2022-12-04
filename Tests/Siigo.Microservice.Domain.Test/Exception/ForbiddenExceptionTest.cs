using Microsoft.AspNetCore.Http;
using Siigo.Microservice.Domain.Exception;
using Xunit;

namespace Siigo.Microservice.Domain.Test.Exception
{
    public sealed class ForbiddenExceptionTest
    {
        private readonly string details = "ForbiddenException Detail";

        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new ForbiddenException(details);
            //Asserts
            Assert.Equal(details, exception.Details);
            Assert.Equal(StatusCodes.Status403Forbidden, exception.StatusCode);
            Assert.Equal("Forbidden", exception.Message);

        }
    }
}
