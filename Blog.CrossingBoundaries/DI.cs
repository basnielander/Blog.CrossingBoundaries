using AutoMapper;
using Blog.CrossingBoundaries.Data;
using Blog.CrossingBoundaries.Data.Repositories;
using Blog.CrossingBoundaries.Domain.Interfaces;
using Blog.CrossingBoundaries.Domain.Managers;
using Blog.CrossingBoundaries.UI;
using Blog.CrossingBoundaries.UI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.IO;

namespace Blog.CrossingBoundaries
{
    internal static class DI
    {
        private readonly static ServiceProvider _serviceProvider;

        public readonly static IConfiguration Configuration = new ConfigurationBuilder()
                                                                      .AddJsonFile("appsettings.json", false, true)
                                                                      .Build();

        public static readonly LoggerFactory MyLoggerFactory = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

        static DI()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddAutoMapper()
                .AddDbContext<DatabaseContext>(o => o.UseLoggerFactory(MyLoggerFactory).UseSqlServer(Configuration.GetConnectionString("OrdersDatabase"))) //
                .AddSingleton<IOrderRepository, OrderRepository>()
                .AddSingleton<IOrderManager, OrderManager>()
                .AddSingleton<IOrderController, OrderController>()                
                .BuildServiceProvider();

            var logger = _serviceProvider.GetService<ILoggerFactory>()
                            .CreateLogger<Program>();
            logger.LogDebug("Starting application");
        }

        
        public static TService GetService<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }

    }
}
