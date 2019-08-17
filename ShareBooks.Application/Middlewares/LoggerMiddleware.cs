using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.Middlewares
{
    [ExcludeFromCodeCoverage]
    public static class LoggerMiddleware
    {
        public static void AddLoggerMiddleware( this IServiceCollection services )
        {
            //todo: Config log mongoDB
            Log.Logger = new LoggerConfiguration( )
                .MinimumLevel.Information( )
                .MinimumLevel.Override( "Microsoft", LogEventLevel.Information )
                .Enrich.FromLogContext( )
                .WriteTo.Console( )
                .WriteTo.File( $@".\log\log.txt", rollingInterval: RollingInterval.Day, restrictedToMinimumLevel: LogEventLevel.Error)
                //.WriteTo.MongoDB( "mongodb://localhost:27017/logs", collectionName: "applog" )
                .CreateLogger( );
        }
    }
}
