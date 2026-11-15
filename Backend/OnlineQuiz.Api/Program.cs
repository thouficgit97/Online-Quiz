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
        var configuration = builder.Services.AddInfranstructure(builder.Configuration.GetConnectionString("DefaultConnection"));
        SchemaUpdate schema = new SchemaUpdate(configuration);
        schema.Execute(true, true);
        if (schema.Exceptions.Count > 0)
        {
            foreach (var exception in schema.Exceptions)
            {
                Console.Error.WriteLine(exception.Message);
            }
        }
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
            {
                policy
                    .SetIsOriginAllowed(origin =>
                        Uri.TryCreate(origin, UriKind.Absolute, out var uri) &&
                        uri.Host == "localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
        var app = builder.Build();
        app.UseCors("AllowFrontend");
        app.Run();
    }
}
