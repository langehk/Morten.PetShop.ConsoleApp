using System;

using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Morten.PetShop.Core.ApplicationService.Services;
using Morten.PetShop.Core.DomainService;
using Morten.PetShop.Core.ApplicationService;
using Morten.PetShop.Infrastructure.Data;

namespace Morten.PetShop.ConsoleApp
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