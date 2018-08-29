using System;

using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Morten.PetShop.Core.ApplicationService;
using Morten.PetShop.Core.ApplicationService.Implementation;
using Morten.PetShop.Core.DomainService;
using Morten.PetShop.Infrastructure.Data;

namespace Morten.PetShop.ConsoleApp
{
    public class Program
    {

        static void Main(String[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            new Printer(petService);

            Console.ReadLine();




        }
    }
}