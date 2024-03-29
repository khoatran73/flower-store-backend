﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using store.Dto.Authenticate;
using store.Dto.Comment;
using store.Entities;
using store.Mapper;
using store.Services;

namespace store;

public class Startup
{
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddEndpointsApiExplorer();
        services.AddControllers().AddNewtonsoftJson();
        services.AddService();
        services.AddScoped<IValidator<RegisterDto>, ValidateRegisterDto>();
        services.AddScoped<IValidator<CommentCreateDto>, ValidateCommentCreateDto>();
        
        var mapper = MapperExtension.AddMapper();
        services.AddSingleton(mapper);

        services.AddCors(options =>
        {
            options.AddPolicy(name: "cors",
                builder =>
                {
                    builder
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
        });
        
        services.AddDbContext<henrystoreContext>(options =>
        {
            var connectionString = new SqlConnectionStringBuilder()
            {
                DataSource = "KHOA-PRO\\MAYCHU",
                InitialCatalog = "henrystore",
                UserID = "sa",
                Password = "123456"
            }.ToString();
            options.UseSqlServer(connectionString);
        });
        
        // services.AddDbContext<Store1DbContext>(options =>
        // {
        //     var connectionString = new SqlConnectionStringBuilder()
        //     {
        //         DataSource = "KHOA-PRO\\TRAM1",
        //         InitialCatalog = "henrystore",
        //         UserID = "sa",
        //         Password = "123456"
        //     }.ToString();
        //     options.UseSqlServer(connectionString);
        // });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors("cors");
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}