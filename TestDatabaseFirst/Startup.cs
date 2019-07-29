using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TestDatabaseFirst.Models;
using TestDatabaseFirst.Services.Interfaces;
using TestDatabaseFirst.Services.Repositories;

namespace TestDatabaseFirst
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
               {
                   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
               });

            //DbContext config
            var connection = Configuration.GetConnectionString("DatabaseFirstStringAux");

            services.AddDbContext<PostDatabaseFirstContext>(options => options.UseSqlServer(connection));
            // Dependecies
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IPostsRepository, PostsRepository>();
            services.AddTransient<IPostLikesRepository, PostLikesRepository>();
            services.AddTransient<IPostCommentsRepository, PostCommentsRepository>();

            //Swagger Config
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Info { Title = "Blog API created with Database first" });
            });

            services.AddCors(o => o.AddPolicy("Dev", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }
                ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseMvc();

            app.UseCors("Dev");
            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core API");
            });
        }
    }
}
