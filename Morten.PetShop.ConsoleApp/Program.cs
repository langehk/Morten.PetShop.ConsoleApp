using System;

using System.Linq;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Core.ApplicationService.Services;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace EASV.PetShop.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }


    }
}