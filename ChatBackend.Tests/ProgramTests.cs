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
    public void ShouldAddSignalRService() {

                // Arrange
                string[] args = new string[] { };   
                var builder = WebApplication.CreateBuilder(args);

                // Act
                builder.Services.AddSignalR();

                // Assert
                Assert.NotNull(builder);
        }
    }
}
