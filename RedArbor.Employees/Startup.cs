using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RedArbor.Employees.DAL.Data;
using Microsoft.EntityFrameworkCore;
using RedArbor.Employees.DAL.Interfaces;
using RedArbor.Employees.DAL;
using RedArbor.Employees.Core.Interfaces;
using RedArbor.Employees.Core;
using AutoMapper;
using System;

namespace RedArbor.Employees
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
            services.AddDbContext<EFContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<DapperContext>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Converters.Add(new API.Utils.JsonDatesConverter());
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RedArbor.Employees", Version = "v1" });
            });

            IMapper mapper = new MapperConfiguration(mapperConfig => { mapperConfig.AddProfile(new API.Maps.EmployeesMapping()); }).CreateMapper();
            services.AddSingleton(mapper);
            services.AddTransient<IEmployeeDAL, EmployeeDAL>();
            services.AddTransient<IEmployeeCore, EmployeeCore>();
            services.AddTransient<IEmployeeReadingDAL, EmployeeReadingDAL>();
            services.AddTransient<IEmployeeWritingDAL, EmployeeWritingDAL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedArbor.Employees v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
