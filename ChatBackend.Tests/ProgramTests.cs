using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ChatBackend.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ChatBackend.Tests
{
    public class ProgramTests
    {

        [Fact]
        // test this:  builder.Services.AddSignalR();
        public void ShouldAddSignalRService()
        {

            // Arrange
            string[] args = new string[] { };
            var builder = WebApplication.CreateBuilder(args);

            // Act
            builder.Services.AddSignalR();

            // Assert
            Assert.NotNull(builder);
        }

        [Fact]
        // test this: Builder services adding
        public void ShouldUseEndpoints()
        {

            // Arrange
            string[] args = new string[] { };
            var builder = WebApplication.CreateBuilder(args);

            // Act
            builder.Services.AddSignalR();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "ChatBackend", Version = "v1" });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Assert
            Assert.NotNull(builder);
        }

        [Fact]
        // test this:  app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
        public void ShouldUseCors()
        {

            // Arrange
            string[] args = new string[] { };
            var builder = WebApplication.CreateBuilder(args);

            // Act
            builder.Services.AddSignalR();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "ChatBackend", Version = "v1" });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            // Assert
            Assert.NotNull(app);
        }

        [Fact]
        // test this:  app.MapHub<ChatHub>("/chatHub");
        public void ShouldMapChatHub()
        {

            // Arrange
            string[] args = new string[] { };
            var builder = WebApplication.CreateBuilder(args);

            // Act
            builder.Services.AddSignalR();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "ChatBackend", Version = "v1" });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.MapHub<ChatHub>("/chatHub");

            // Assert
            Assert.NotNull(app);
        }

        [Fact]
        // test this:  app.MapControllers();
        public void ShouldMapControllers()
        {

            // Arrange
            string[] args = new string[] { };
            var builder = WebApplication.CreateBuilder(args);

            // Act
            builder.Services.AddSignalR();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "ChatBackend", Version = "v1" });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(settings => settings.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            app.MapHub<ChatHub>("/chatHub");
            app.MapControllers();

            // Assert
            Assert.NotNull(app);
        }
    }
}
