using juridical_api.Contracts;
using juridical_api.Db;
using juridical_api.Models.Entities;
using juridical_api.Repository;
using Microsoft.EntityFrameworkCore;
using juridical_api.DTO;
using System.Text.Json.Serialization;
using juridical_api.Profile;
using FluentValidation;
using juridical_api.Validators;

namespace juridical_api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.
                GetConnectionString("DatabaseConnection");
            builder.Services.AddDbContextPool<AppDbContext>(
                options => options.UseMySql(connectionString, 
                ServerVersion.AutoDetect(connectionString)));

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // Добавить эту строку для обработки циклических ссылок
            });

            builder.Services.AddScoped<IRepository<CasesEntities, CasesDto>, CasesRepository>();
            builder.Services.AddScoped<IRepository<ClientsEntities, ClientsDto>, ClientsRepository>();
            builder.Services.AddScoped<IRepository<ContractsEntities, ContractsDto>, ContractsRepository>();
            builder.Services.AddScoped<IRepository<CourtHearingsEntities, CourtHearingsDto>, CourtHearingsRepository>();
            builder.Services.AddScoped<IRepository<DocumentsEntities, DocumentsDto>, DocumentsRepository>();
            builder.Services.AddScoped<IRepository<LawyersEntities, LawyersDto>, LawyersRepository>();
            builder.Services.AddScoped<IRepository<PaymentsEntities, PaymentsDto>, PaymentsRepository>();
            builder.Services.AddScoped<IRepository<ReviewsEntities, ReviewsDto>, ReviewsRepository>();
            builder.Services.AddScoped<IRepository<TasksEntities, TasksDto>, TasksRepository>();

            builder.Services.AddAutoMapper(typeof(ClientsProfile));
            builder.Services.AddAutoMapper(typeof(CasesProfile));
            builder.Services.AddAutoMapper(typeof(ContractsProfile));
            builder.Services.AddAutoMapper(typeof(CourtHearingsProfile));
            builder.Services.AddAutoMapper(typeof(DocumentsProfile));
            builder.Services.AddAutoMapper(typeof(LawyersProfile));
            builder.Services.AddAutoMapper(typeof(PaymentsProfile));
            builder.Services.AddAutoMapper(typeof(ReviewsProfile));
            builder.Services.AddAutoMapper(typeof(TasksProfile));
            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddValidatorsFromAssemblyContaining<CasesValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ClientsValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ContractsValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<DocumentsValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<LawyersValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<PaymentsValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ReviewsValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<TasksValidator>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //app.UseStaticFiles();

            //app.UseRouting();

            //app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
