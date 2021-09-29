using ActionDB;
using MassTransit;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using Pact;
using System;
using System.IO;
using TestApplication.ActionFilters;
using TestApplication.Services;


namespace TestApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();

            //services.Configure<RabbitMqConfiguration>(Configuration.GetSection("RabbitMq"));

            services.ConfigureCors();
            services.ConfigureIISIntegration();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureLoggerService();
            services.ConfigureAllModelsActions();
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            services.AddScoped<IAuthenticationManager, AuthenticationManager>();
            services.ConfigureSwagger();
            services.ConfigureCurrencyService();
            services.ConfigureFilters();
            services.AddScoped<ValidationFilterAttribute>();
            services.ConfigureVersioning();
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddAntiforgery(options =>
            {
                //options.FormFieldName = "AntiForgeryFieldName";
                options.HeaderName = "X-XSRF-TOKEN";
                options.Cookie.Name = "XSRF-TOKEN";
            });

            //services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                {                        // amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl       
                    //config.UseHealthCheck(provider);
                    config.Host(new Uri("amqps://gpqcunnl:5Qc8rpPCYk7gvXQwLIXZwXqhvVwYjClr@beaver.rmq.cloudamqp.com/gpqcunnl&queue=queue1"));
                }));
                services.AddMassTransitHostedService();
            });

            services.ConfigureMicroserviceOrder();
            
            //services.AddHostedService<CurrencyService>();
            //services.AddMemoryCache();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
    
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger, IAntiforgery antiforgery)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");



            app.UseAuthentication();
            app.UseAuthorization();

            //app.Use(next => context =>
            //{
            //    string path = context.Request.Path.Value;

            //    //if (string.Equals(path, "/", StringComparison.OrdinalIgnoreCase))
            //    //{
            //        var tokens = antiforgery.GetAndStoreTokens(context);
            //        context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken,
            //            new CookieOptions() { HttpOnly = false });
            //    //}
            //    return next(context);
            //});
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Rerer-er Web Api v1");
                s.SwaggerEndpoint("/swagger/v2/swagger.json", "Rerer-er Web Api v2");
            });
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
