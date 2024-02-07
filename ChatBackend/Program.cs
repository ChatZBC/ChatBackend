
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
            builder.Services.AddSignalR();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapHub<ChatHub>("/chatHub");
            app.UseAuthorization();
<<<<<<< Updated upstream
            
            // SignalR middleware
=======
            app.UseRouting();
>>>>>>> Stashed changes
            app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            //app.UseEndpoints(endpoints => endpoints.MapHub<ChatHub>);
            //app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            // Map SignalR Hub to /chatHub
<<<<<<< Updated upstream
            app.MapHub<ChatHub>("/chatHub");
=======
>>>>>>> Stashed changes

            app.MapControllers();

            app.Run();
        }
    }
}
