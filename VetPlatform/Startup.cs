using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VetPlatform.Api.Services;
using VetPlatform.Data;
using VetPlatform.Data.Providers;

namespace VetPlatform.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var adminConnectionString = Configuration.GetConnectionString("AdminConnectionString");
            var vetplatformConnectionString = Configuration.GetConnectionString("VetPlatformConnectionString");

            services.AddDbContext<TenantContext>
                (options => options.UseSqlServer(adminConnectionString));

            services.AddTransient<ITenantProvider, TenantProvider>();

            services.AddDbContext<VetPlatformContext>
                (options => options.UseSqlServer(vetplatformConnectionString));

            services.AddTransient<IBookingsService, BookingsService>();

            services.AddCors(options =>
            {
                options.AddPolicy("dev",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddHealthChecks();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                // base-address of your identityserver
                options.Authority = Configuration["IDPAuthority"];
                // name of the API resource
                options.Audience = "vp_portal_api";
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("dev");
            }
            else
            {
                app.UseHsts();
            }
            app.UseHealthChecks("/health");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
