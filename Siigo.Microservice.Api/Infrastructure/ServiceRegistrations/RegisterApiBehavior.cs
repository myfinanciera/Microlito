// unset

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Infrastructure.Extensions;
using Siigo.Microservice.Domain.Exception;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations
{
    public sealed class RegisterApiBehavior : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    ValidationProblemDetails error = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => new ValidationProblemDetails(actionContext.ModelState)).FirstOrDefault();
                    var errorField = error?.Errors.Last().Key ?? String.Empty;
                    var field = Regex.Replace(errorField, "[^A-Za-z0-9_ ]", String.Empty);
                    var errorValue = error?.Errors.Values.Last().FirstOrDefault() ?? string.Empty;
                    Match match = Regex.Match(errorValue, ".+?(?=Path)");
                    var message = match.Success ? match.Value : errorValue;
                    throw new BadRequestException("invalid_type", $"Tipo de dato inválido: {field}.", message);
                };
            });
        }
    }
}
