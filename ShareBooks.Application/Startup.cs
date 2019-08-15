using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShareBooks.Application.Middlewares;

namespace ShareBooks.Application
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddMvc( ).SetCompatibilityVersion( CompatibilityVersion.Version_2_2 );
            services.BuildServiceProvider( );
            services.AddLoggerMiddleware( );
            services.AddSwaggerMiddleware( );
        }

        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if ( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
            }

            app.UseMvc( );
            app.UseSwaggerMiddleware( );
        }
    }
}
