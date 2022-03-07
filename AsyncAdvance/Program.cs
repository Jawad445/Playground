using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.Run(async context =>
            {
                //Simulation of Bad access
                //Task.Delay(System.TimeSpan.FromSeconds(2)).Wait();
                //Simulation of Good access
                await Task.Delay(TimeSpan.FromSeconds(2));
                await context.Response.WriteAsync("Hello World");

            });
        });
    }).Build().Run();