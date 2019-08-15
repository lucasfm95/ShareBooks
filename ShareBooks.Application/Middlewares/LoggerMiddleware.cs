using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShareBooks.Application.Middlewares
{
    public static class LoggerMiddleware
    {
        public static void AddLoggerMiddleware( this IServiceCollection services )
        {
            //todo: Config log mongoDB
            Log.Logger = new LoggerConfiguration( )
                .MinimumLevel.Debug( )
                .MinimumLevel.Override( "Microsoft", LogEventLevel.Information )
                .Enrich.FromLogContext( )
                .WriteTo.Console( )
                .WriteTo.File( $@".\log\{DateTime.Now.Date.ToString("yyyy-MM-dd")}-log.txt" )
                //.WriteTo.MongoDB( "mongodb://localhost:27017/logs", collectionName: "applog" )
                .CreateLogger( );
        }
    }
}
