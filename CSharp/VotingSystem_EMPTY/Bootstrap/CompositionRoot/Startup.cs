﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using ApplicationLogic;
using Bootstrap.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap.CompositionRoot
{
  public class Startup
  {

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    { 
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
        .AddControllersAsServices();

      services.AddScoped(ctx => new UsersController());
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

      app.UseHttpsRedirection();
      app.UseMvc();

      app.Map("a/a/a", builder => )
    }
  }
}
