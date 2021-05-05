using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phonebook.BLL.Interfaces;
using Phonebook.BLL.Services;
using Phonebook.DAL.DataContext;
using Phonebook.DAL.Entities;
using Phonebook.DAL.Repositories;
using Phonebook.DAL.Repositories.Interfaces;
using VueCliMiddleware;

namespace Phonebook.WEB
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
      string configurationString = Configuration.GetConnectionString("DefaultConnection");
      
      services.AddControllers();
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp";
      });
      services.AddDbContext<DatabaseContext>(option => 
        option.UseSqlServer(configurationString));
      services.AddScoped(x => new PhoneBookEntryRepository(x.GetService<DatabaseContext>()));
      
      services.AddScoped<IPhoneBookEntryService, PhoneBookEntryService>(x => new PhoneBookEntryService(
        x.GetService<PhoneBookEntryRepository>()));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseSpaStaticFiles();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = env.IsDevelopment() ? "ClientApp/" : "dist";

        if (env.IsDevelopment())
        {
          spa.UseVueCli(npmScript: "serve");
        }
      });
    }
  }
}
