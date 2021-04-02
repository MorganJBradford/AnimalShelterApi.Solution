using AnimalShelter.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;

namespace AnimalShelter
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

      services.AddDbContext<AnimalShelterContext>(opt =>
        opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("V1", new OpenApiInfo
        {
          Version = "v1",
          Title = "AnimalShelter API",
          Description = "An api to access animals at this fictitious animal shelter",
          TermsOfService = new Uri("Use it how you like"),
          Contact = new OpenApiContact
          {
            Name = "Morgan Bradford",
            Email = "morganjbradford95@gmail.com",
            Url = new Uri("https://github.com/MorganJBradford"),
          },
          License = new OpenApiLicense
          {
            Name = "MIT",
            Url = new Uri("https://opensource.org/licenses/MIT"),
          }
        });
      });
    }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseSwagger();

      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/V1/swagger.json", "My API V1");
      });
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}