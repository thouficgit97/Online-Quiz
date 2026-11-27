using Microsoft.Extensions.FileProviders;
using NHibernate.Tool.hbm2ddl;

namespace OnlineQuiz.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        builder.Services.AddControllers();
        builder.Services.AddInfranstructure(builder.Configuration.GetConnectionString("DefaultConnection"));
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy
                    .WithOrigins("http://127.0.0.1:5001")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        var frontendPath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "..", "Frontend"));
        var frontendProvider = new PhysicalFileProvider(frontendPath);
        var app = builder.Build();
        app.UseCors("AllowFrontend");
        app.UseDefaultFiles(new DefaultFilesOptions { FileProvider = frontendProvider });
        app.UseStaticFiles(new StaticFileOptions { FileProvider = frontendProvider });
        builder.Services.AddSingleton<UserService>();
        builder.Services.AddSingleton<DBService>();
        var app = builder.Build();
        app.UseCors("AllowFrontend");
        app.MapControllers();
        app.Run();
    }
}
