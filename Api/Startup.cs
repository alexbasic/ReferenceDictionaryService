using Contract;
using DAL;
using DAL.Repository;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Api
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
            services.AddControllers();

            //infrastructure
            services.AddTransient<ITransaction, Transaction>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IRepositoryFactory, RepositoryFactory>();

            //domain
            services.AddTransient<IReferenceService, ReferenceService>();
            services.AddTransient<IAttributeNameDescriptorService, AttributeNameDescriptorService>();
            services.AddTransient<IDataTypeDescriptorService, DataTypeDescriptorService>();
            services.AddTransient<IObjectEntityTypeService, ObjectEntityTypeService>();

            //data context
            services.AddDbContext<DbContext, ReferenceDataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ReferenceDataContext"))
                .LogTo(x => Console.WriteLine($"EF: {x}")),
                ServiceLifetime.Scoped,
                ServiceLifetime.Singleton);

            services.AddSwaggerGen(c =>
            {
                c.SchemaGeneratorOptions.UseAllOfToExtendReferenceSchemas = false;

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "reference dictionary service API",
                    Description = string.Empty,
                    TermsOfService = null,
                    Contact = new OpenApiContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = null,
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under Apache 2.0",
                        Url = null,
                    }
                });
                //c.SchemaGeneratorOptions.UseAllOfToExtendReferenceSchemas;

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "reference dictionary service");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
