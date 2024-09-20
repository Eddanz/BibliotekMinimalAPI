using BibliotekFrontend.Components;
using BibliotekMinimalAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace BibliotekFrontend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        //Data base provider
        builder.Services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddQuickGridEntityFrameworkAdapter();

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint(); // Only in development
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // Enable HSTS in production for better security
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}

