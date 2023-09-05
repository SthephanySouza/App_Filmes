using FilmeApi.DataBase;
using FilmeApi.Repository;
using FilmeApi.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace FilmeApi {
    public class Program {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DBFilmesContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
                );

            builder.Services.AddScoped<IFilmeRepo, FilmeRepo>();
            builder.Services.AddScoped<IGeneroRepo, GeneroRepo>();
            builder.Services.AddScoped<IDiretorRepo, DiretoRepo>();
            builder.Services.AddScoped<IAtorRepo, AtorRepo>();

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