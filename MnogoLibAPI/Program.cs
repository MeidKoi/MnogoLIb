using BusinessLogic.Authorization;
using BusinessLogic.Helpers;
using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MnogoLibAPI.Authorization;
using MnogoLibAPI.Helpers;
using System.Reflection;
using System.Text;

namespace MnogoLibAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Зарегистрируйте AppSettings
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


            string platform = Environment.OSVersion.Platform.ToString();

            if (platform == "Unix")
            {
                builder.Services.AddDbContext<MnogoLibContext>(
                     options => options.UseSqlServer(
                                        builder.Configuration.GetConnectionString("Unix")));
            }
            else if (platform == "Win32NT")
            {
                builder.Services.AddDbContext<MnogoLibContext>(
                    options => options.UseSqlServer(
                                    builder.Configuration.GetConnectionString("Win32NT")));
            }

            builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMaterialService, MaterialService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IChatService, ChatService>();
            builder.Services.AddScoped<IChatUserService, ChatUserService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<ICommentRateService, CommentRateService>();
            builder.Services.AddScoped<IFileService, FileService>();
            builder.Services.AddScoped<IGroupMaterialService, GroupMaterialService>();
            builder.Services.AddScoped<IMaterialFileService, MaterialFileService>();
            builder.Services.AddScoped<IMaterialsUserStatusService, MaterialsUserStatusService>();
            builder.Services.AddScoped<IMessageUserService, MessageUserService>();
            builder.Services.AddScoped<IPaymentService, PaymentService>();
            builder.Services.AddScoped<IPaymentUserService, PaymentUserService>();
            builder.Services.AddScoped<IRateService, RateService>();

            builder.Services.AddScoped<IJwtUtils, JwtUtils>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddMapster();
            builder.Services.AddLogging();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MnogoLib API",
                    Description = "Site for reading manga",
                    Contact = new OpenApiContact
                    {
                        Name = "Contacts",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://example.com/license")
                    }
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                                    Enter 'Bearer' [space] and then your token in the text input below.
                                    \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                {
                    new OpenApiSecurityScheme
                    {
                    Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,

                    },
                    new List<string>()
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MnogoLibContext>();
                context.Database.Migrate();

                context.Database.EnsureCreated();

                if (!context.AuthorStatuses.Any())
                    context.AuthorStatuses.AddRange(
                        new AuthorStatus { NameAuthorStatus = "Ongoing" },
                        new AuthorStatus { NameAuthorStatus = "Completed" },
                        new AuthorStatus { NameAuthorStatus = "Stopped" },
                        new AuthorStatus { NameAuthorStatus = "Discontinued" }
                    );

                if (!context.Roles.Any())
                    context.Roles.AddRange(
                        new Role { NameRole = "User" },
                        new Role { NameRole = "Moder" },
                        new Role { NameRole = "Admin" }
                    );

                if (!context.Categories.Any())
                    context.Categories.AddRange(
                        new Category { NameCategory = "Manga" },
                        new Category { NameCategory = "Manhua" },
                        new Category { NameCategory = "Manhwa" },
                        new Category { NameCategory = "Comics" }
                    );

                if (!context.Genres.Any())
                    context.Genres.AddRange(
                        new Genre { NameGenre = "Cyberpunk" },
                        new Genre { NameGenre = "Isekai" },
                        new Genre { NameGenre = "Shonen" },
                        new Genre { NameGenre = "Shojo" },
                        new Genre { NameGenre = "Seinen" },
                        new Genre { NameGenre = "Josei" },
                        new Genre { NameGenre = "Fantasy" },
                        new Genre { NameGenre = "Horror" },
                        new Genre { NameGenre = "Romance" },
                        new Genre { NameGenre = "Comedy" },
                        new Genre { NameGenre = "Drama" },
                        new Genre { NameGenre = "Mystery" },
                        new Genre { NameGenre = "Thriller" },
                        new Genre { NameGenre = "Slice of Life" },
                        new Genre { NameGenre = "Sports" },
                        new Genre { NameGenre = "Historical" },
                        new Genre { NameGenre = "Supernatural" },
                        new Genre { NameGenre = "Psychological" },
                        new Genre { NameGenre = "Mecha" },
                        new Genre { NameGenre = "Post-Apocalyptic" }
                    );

                if (!context.UserStatuses.Any())
                    context.UserStatuses.AddRange(
                        new UserStatus { NameUserStatus = "Reading" },
                        new UserStatus { NameUserStatus = "In the plans" },
                        new UserStatus { NameUserStatus = "Abandoned" },
                        new UserStatus { NameUserStatus = "Favorite" }
                    );

                context.SaveChanges();
            }


            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(builder => builder.WithOrigins(new[] { "http://localhost:5088/", })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());


            app.UseCors(builder => builder.WithOrigins(new[] { "https://mnogolibapi-f7vitvir.b4a.run/", })
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}