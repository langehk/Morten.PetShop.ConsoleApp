using System;

using System.Linq;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Core.ApplicationService.Services;
using EASV.PetShop.Core.DomainService;
using EASV.PetShop.Infrastructure.Data;
using EASV.PetShop.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace EASV.PetShop.ConsoleApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            FakeDB.InitData();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();


            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.PrintUI();
        }


    }
}