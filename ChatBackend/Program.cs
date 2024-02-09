
using ChatBackend.Hubs;

namespace ChatBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add SignalR service
            builder.Services.AddSingleton<ConnectedUserTransient>();
            builder.Services.AddSignalR(options=>options.EnableDetailedErrors = true);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseRouting();
            app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            //app.UseEndpoints(endpoints => endpoints.MapHub<ChatHub>);
            //app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            // Map SignalR Hub to /chatHub
            app.MapHub<ChatHub>("/chatHub");

            app.MapControllers();

            app.Run();
        }
    }
}
