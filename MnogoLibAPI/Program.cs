using BusinessLogic.Services;
using Domain.Models;
using Domain.Wrapper;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MnogoLibAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MnogoLibContext>(
                options => options.UseSqlServer(
                                "Server=LAPTOP-ISLFEJ9E;Database=MnogoLib;Trusted_Connection=True;"));

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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
