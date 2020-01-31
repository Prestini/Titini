using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Titini.Application.Common.Interfaces;
using Titini.Data;

namespace Titini.WebApi
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.File("log.txt")
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                #region Texto

                string texto = "";

                #endregion

                Log.Information(texto);
                var host = CreateHostBuilder(args).Build();
                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var concreteContext = scope.ServiceProvider.GetService<TitiniDbContext>();
                        concreteContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Ocorreu um erro ao tentar atualizar o Banco de Dados para a última versão.");
                    }
                }
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Erro na inicialização da aplicação");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
