using System;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using NuGet.Packaging;
using Siigo.Microservice.Api.SeedWork;
using Siigo.Microservice.Domain.Exception;
using Siigo.Microservice.Infrastructure.Extensions;
using NotFoundException = Ardalis.GuardClauses.NotFoundException;

namespace Siigo.Microservice.Api.Filter
{
    public sealed class ExceptionInterceptor : Interceptor
    {
        private readonly ILogger<ExceptionInterceptor> _logger;

        public ExceptionInterceptor(ILogger<ExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <param name="continuation"></param>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <returns></returns>
        /// <exception cref="RpcException"></exception>
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw BuildRpcDetails(exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contextFeature"></param>
        /// <returns></returns>
        private RpcException BuildRpcDetails(Exception contextFeature)
        {
            // Controlled Exceptions 
            return contextFeature switch
            {
                NotFoundException exception => new RpcException(new Status(StatusCode.NotFound, exception.Message),
                    exception.Message),

                // Any Fluent Rules Business Validations 
                ClientErrorException clientErrorException => new RpcException(
                    new Status(StatusCode.FailedPrecondition, clientErrorException.Details),
                    clientErrorException.Message
                ),

                ArgumentNullException argumentNullException => new RpcException(
                    new Status(StatusCode.NotFound, argumentNullException.Message),
                    "NotFound Null Resource Validation"
                ),

                // Fluent Validators in IRequest Instances 
                InvalidRequestException invalidRequestException => BuildRpcExceptionFromInvalidRequestException(
                    invalidRequestException
                ),

                // Guard Validations
                ArgumentException argumentException => new RpcException(
                    new Status(StatusCode.InvalidArgument,
                        argumentException.Message)
                ),

                // Any Fluent Rules Business Validations 
                ValidationException validationException => new RpcException(
                    new Status(StatusCode.InvalidArgument, validationException.Message),
                    validationException.Errors?.FirstOrDefault()?.ErrorMessage!
                ),

                // Controlled server exception
                ServerErrorException serverErrorException => new RpcException(
                    new Status(StatusCode.Internal, serverErrorException.Details),
                    serverErrorException.Message
                ),

                // Exception Not Controlled => Internal Server Error
                _ => new RpcException(new Status(StatusCode.Internal, contextFeature.Message), contextFeature.Message)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static RpcException BuildRpcExceptionFromInvalidRequestException(InvalidRequestException exception)
        {
            var metadata = new Metadata();

            metadata.AddRange(
                from errorDetail
                    in exception.Details
                select new Metadata.Entry(
                    errorDetail.Code,
                    errorDetail.Message + errorDetail.Detail
                )
            );

            return new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request."), metadata, "prueba");
        }
    }
}