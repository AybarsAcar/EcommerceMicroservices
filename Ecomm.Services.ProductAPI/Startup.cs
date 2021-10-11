using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecomm.Services.ProductAPI.DataContext;
using Ecomm.Services.ProductAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace Ecomm.Services.ProductAPI
{
  public class Startup
  {
    private readonly IConfiguration _config;

    public Startup(IConfiguration configuration)
    {
      _config = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecomm.Services.ProductAPI", Version = "v1" });
      });

      services.AddDbContext<ApplicationDbContext>(opt =>
      {
        opt.UseNpgsql(_config.GetConnectionString("DefaultConnection"));
      });

      var mapper = MappingConfiguration.ConfigureMaps().CreateMapper();
      services.AddSingleton(mapper);
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddScoped<IProductRepository, ProductRepository>();
    }


    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecomm.Services.ProductAPI v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}