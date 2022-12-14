using Microsoft.AspNetCore.Http;
using Siigo.Microservice.Domain.Exception;
using Xunit;

namespace Siigo.Microservice.Domain.Test.Exception
{
    public sealed class ServiceErrorExceptionTest
    {
        private readonly string _details = "Service General Exception ";
        private readonly string _code = "Service Code Exception ";
        private readonly string _message = "Service Message Exception ";

        [Fact]
        public void CreateExceptionTest()
        {
            var exception = new ServerErrorException(_code, _message, _details);
            //Asserts
            Assert.Equal(_details, exception.Details);
            Assert.Equal(_code, exception.Code);
            Assert.Equal(_message, exception.Message);
            Assert.Equal(StatusCodes.Status500InternalServerError, exception.StatusCode);
        }
    }
}
