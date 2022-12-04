using System;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;
using Moq;
using Siigo.Microservice.Domain.Exception;
using Xunit;

namespace Siigo.Microservice.Domain.Test.Exception
{
    public sealed class BadRequestExceptionTest
    {
        private readonly string _details = "BadRequestException Detail";
        private readonly string _code = "Service Code Exception ";
        private readonly string _message = "Service Message Exception ";

        [Fact]
        public void CreateExceptionTest()
        {
            // Arrange
            var exception = new BadRequestException(_details);

            //Asserts
            Assert.Equal(_details, exception.Details);
            Assert.Equal(StatusCodes.Status400BadRequest, exception.StatusCode);
            Assert.Equal("Bad Request", exception.Message);

        }

        [Fact]
        public void Success_Model_When_Call_Another_Construct()
        {
            // Arrange
            var exception = new BadRequestException(_code, _message, _details);
        
            //Asserts
            Assert.Equal(_code, exception.Code);
            Assert.Equal(_message, exception.Message);
            Assert.Equal(_details, exception.Details);

        }
    }
}
