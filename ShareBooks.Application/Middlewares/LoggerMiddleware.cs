using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ShareBooks.Application.Middlewares
{
    [ExcludeFromCodeCoverage]
    public static class LoggerMiddleware
    {
        public static void AddLoggerMiddleware( this IServiceCollection services, IConfiguration Configuration )
        {
            Console.WriteLine(  );
            Log.Logger = new LoggerConfiguration( )
                .MinimumLevel.Information( )
                .MinimumLevel.Override( "Microsoft", LogEventLevel.Information )
                .Enrich.FromLogContext( )
                .WriteTo.Console( )
#if DEBUG
                .WriteTo.File( $@".\log\log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Error)
#endif
                .WriteTo.MongoDB( Configuration.GetConnectionString("LogMongoDbConnection"), collectionName: "applog", restrictedToMinimumLevel: LogEventLevel.Error )
                .CreateLogger( );
        }
    }
}
