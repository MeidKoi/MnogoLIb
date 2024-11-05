using BusinessLogic.Services;
using DataAccess.Wrapper;
using Domain.Interfaces;
using Domain.Models;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MnogoLibAPI.MiddleWare;
using System.Reflection;

namespace MnogoLibAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var platform = Environment.OSVersion.Platform.ToString();

            if (platform == "Unix")
            {
                builder.Services.AddDbContext<MnogoLibContext>(
                     options => options.UseSqlServer(
                                        builder.Configuration["ConnectionString"]));
            }
            else if (platform == "Win32NT")
            {
                builder.Services.AddDbContext<MnogoLibContext>(
                    options => options.UseSqlServer(
                                    "Server=LAPTOP-ISLFEJ9E;Database=MnogoLib;Trusted_Connection=True;"));
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

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MnogoLib API",
                    Description = "Äàííîå API ïîçâîëÿåò âçàèìîäåéñòâîâàòü ñ îñíîâíûìè è ñàìûìè ÷àñòî èñïîëüçóåìûìè ñóùíîñòÿìè",
                    Contact = new OpenApiContact
                    {
                        Name = "Ïðèìåð êîíòàêòà",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Ïðèìåð ëèöåíçèè",
                        Url = new Uri("https://example.com/license")
                    }
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<MnogoLibContext>();
                context.Database.Migrate();

                context.Database.EnsureCreated();

                context.AuthorStatuses.AddRange(
                    new AuthorStatus { NameAuthorStatus = "Ongoing" },
                    new AuthorStatus { NameAuthorStatus = "Completed" },
                    new AuthorStatus { NameAuthorStatus = "Stopped" },
                    new AuthorStatus { NameAuthorStatus = "Discontinued" }
                );

                context.Categories.AddRange(
                    new Category { NameCategory = "Manga" },
                    new Category { NameCategory = "Manhua" },
                    new Category { NameCategory = "Manhwa" },
                    new Category { NameCategory = "Comics" }
                );
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

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}