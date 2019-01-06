using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaveBase.WebAPI.Database;
using CaveBase.WebAPI.Repositories;
using CaveBase.WebAPI.Services.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CaveBase.WebAPI
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
            //CORS
            services.AddCors();
            
            //AutoMapper
            var autoMapperConfig = new AutoMapper.MapperConfiguration(config => { config.AddProfile(new AutoMapperProfileConfiguration()); });
            var mapper = autoMapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            //MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //SQL Database
            services.AddDbContext<CaveServiceContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CaveService")));

            //Register Repositories
            services.AddScoped<CaveRepository>();
            services.AddScoped<ClubRepository>();
            services.AddScoped<CountryRepository>();
            services.AddScoped<CaverRepository>();
            services.AddScoped<DifficultyRatingRepository>();
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
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyMethod());

            app.UseMvc();
        }
    }
}
