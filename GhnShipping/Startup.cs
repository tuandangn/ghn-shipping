using GhnShipping.Infrastructure;
using GhnShipping.Infrastructure.Settings;
using GhnShipping.Infrastructure.Directory;
using GhnShipping.Infrastructure.Network;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;
using GhnShipping.Services.Network;
using AutoMapper;
using GhnShipping.Infrastructure.Mapper;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace GhnShipping
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Defaults.Version, new OpenApiInfo
                {
                    Version = Defaults.Version,
                    Title = "GHN Shipping API",
                    Description = "GHN Shipping API customized",
                    Contact = new OpenApiContact
                    {
                        Name = "Tuan Dang",
                        Email = "nguyentuandang7@gmail.com",
                        Url = new Uri("https://facebook.com/ng.tuan.dang7"),
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            //services
            services.AddScoped<IWorkContext, WorkContext>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDirectoryService, DirectoryService>();

            //options
            var urlSettingsConfig = _configuration.GetSection(Defaults.UrlSettings);
            services.Configure<UrlSettings>(urlSettingsConfig);
            services.Configure<ApiSettings>(_configuration.GetSection(Defaults.ApiSettings));

            //http clients
            var urlSettings = urlSettingsConfig.Get<UrlSettings>();
            services.AddHttpClient(ClientNames.PRODUCTION, (services, client) => SetupClient(client, services, urlSettings.Production));
            services.AddHttpClient(ClientNames.DEVELOPMENT, (services, client) => SetupClient(client, services, urlSettings.Development));

            //auto mapper
            var mapperConfiguration = new MapperConfiguration(config => config.AddProfile<ModelProfile>());
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton(mapper);

            #region Local methods

            void SetupClient(HttpClient client, IServiceProvider services, string baseAddress)
            {
                client.BaseAddress = new Uri(baseAddress);

                var token = GetToken(services);
                client.DefaultRequestHeaders.Add(Defaults.TokenHeaderName, token);
            }

            string GetToken(IServiceProvider services)
            {
                using var scoped = services.CreateScope();
                var workContext = scoped.ServiceProvider.GetRequiredService<IWorkContext>();
                var token = workContext.GetToken();

                return token;
            }
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            //swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{Defaults.Version}/swagger.json", $"GHN Shipping Api - {Defaults.Version}");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
