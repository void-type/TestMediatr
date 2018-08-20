using AutoMapper;
using MediatrRailwayExample.Models;
using MediatrRailwayExample.Models.CoreAspNet;
using MediatrRailwayExample.Models.CoreModel;
using MediatrRailwayExample.Models.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MediatrRailwayExample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Infrastructure Services
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<HttpActionResultResponder>();

            // Domain Services
            services.AddAutoMapper(typeof(DomainProfile));
            services.AddMediatR(typeof(DomainProfile));
            services.AddTransient<LoaneeData>();
            services.AddTransient<IValidator<GetLoanee.Request>, GetLoanee.RequestValidator>();

            // Post Processing Behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(GetLoanee.LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FallibleLoggingBehavior<,>));

            // Pre Processing Behaviors
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
