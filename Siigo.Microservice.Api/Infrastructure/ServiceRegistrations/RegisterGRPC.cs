
using Calzolari.Grpc.AspNetCore.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Siigo.Microservice.Api.Filter;
using Siigo.Microservice.Api.Infrastructure.Extensions;

namespace Siigo.Microservice.Api.Infrastructure.ServiceRegistrations;

public sealed class RegisterGrpc : IServiceRegistration
{
    public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddSingleton<ExceptionInterceptor>();

        services.Configure<KestrelServerOptions>(options =>
        {
            //options.AllowSynchronousIO = true;
        });
        
        services.AddGrpc(
            options =>
            {

                options.EnableDetailedErrors = false;
                options.EnableMessageValidation();
                options.Interceptors.Add<ExceptionInterceptor>();
                // TODO: add interceptor for auth JWT
                //options.Interceptors.Add(new AuthorizeFilterGrpc(configuration));
            }
        );// .AddJsonTranscoding();



        /*services.AddSingleton<IServerErrorHandler>(_ =>
        {
            // combine application and unexpected handlers into one handler
            var collection = new ServerErrorHandlerCollection(
                new ExceptionInterceptor()
            );
            
            return collection;
        });

        services
            .AddServiceModelGrpc(options =>
            {
                options.DefaultErrorHandlerFactory = serviceProvider =>
                    serviceProvider.GetRequiredService<IServerErrorHandler>();
            });*/
        
        services.AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
        });
        
        
        services.AddGrpcHttpApi(options =>
        {
            // options.JsonFormatter = new JsonFormatter(JsonFormatter.Settings.Default);
        });
        services.AddGrpcReflection();
        services.AddGrpcValidation();
        services.AddGrpcSwagger();
        //services.AddGrpcCoreAdapter();
        //services.AddRestGrpcAdapter();
    }
}