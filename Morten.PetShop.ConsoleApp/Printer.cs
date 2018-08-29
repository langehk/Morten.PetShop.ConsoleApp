using System;
using Morten.PetShop.Core.ApplicationService;
using System.Collections.Generic;
using System.Text;

namespace Morten.PetShop.ConsoleApp
{
    public class Printer
    {
        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
            ShowAllPets();
        }

        private void ShowAllPets()
        {
            var listOfPets = _petService.GetPets();
            foreach (var pet in listOfPets)
            {
                Console.WriteLine("Id: " + pet.Id + " Type: " + pet.Type);
            }
        }
    }
}