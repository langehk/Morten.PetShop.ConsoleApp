using System;
using Morten.PetShop.Core.ApplicationService;
using System.Collections.Generic;
using System.Text;
using Morten.PetShop.Entities;

namespace Morten.PetShop.ConsoleApp
{
    public class Printer : IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
            

            StartData();
            

        }

        
        public void StartUI()
        {
            string[] menuEnhender =
            {
                "List all pets",
                "Search for pet type",
                "Add new pet",
                "Remove pet",
                "Edit pet",
                "Sort after price",
                "5 cheapest pets",
                "Exit"
            };

            var selection = PetMenu(menuEnhender);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllPets();
                        ShowPets(pets);
                        break;
                    case 2:
                        var searchType = PrintFintPetByType();
                        _petService.FindPetByType(searchType);

                        break;
                    case 3:
                        var name = AskQuestion("Name: ");
                        var type = AskQuestion("Type: ");
                        var birthDate = AskQuestion("Birthdate: ");
                        var soldDate = AskQuestion("Solddate: ");
                        var color = AskQuestion("Color: ");
                        var previousOwner = AskQuestion("Previous owner: ");
                        var price = AskQuestion("Price: ");
                        var pet = _petService.NewPet(name, type, Convert.ToDateTime(birthDate),
                                            Convert.ToDateTime(soldDate), color,
                                                     previousOwner, Convert.ToDouble(price));
                        _petService.CreatePet(pet);
                        break;
                    case 4:
                        var iDForDelete = PrintFindPetById();
                        _petService.DeletePet(iDForDelete);
                        break;
                    case 5:
                        var idForEdit = PrintFindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        var newName = AskQuestion("Name: ");
                        var newType = AskQuestion("Type: ");
                        var newBirthDate = AskQuestion("Birthdate: ");
                        var newSoldDate = AskQuestion("Solddate: ");
                        var newColor = AskQuestion("Color: ");
                        var newPreviousOwner = AskQuestion("Previous owner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdatePet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Type = newType,
                            //Birthdate = Convert.ToDateTime(newBirthDate),
                            SoldDate = Convert.ToDateTime(newSoldDate),
                            Color = newColor,
                            //PrevOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice)
                        });
                        break;
                    case 6:
                        Console.WriteLine("...");
                        break;
                    case 7:
                        Console.WriteLine("...");
                        break;
                    default:
                        break;
                }
                selection = PetMenu(menuEnhender);
            }
            Console.WriteLine("Hej");


            Console.ReadLine();
        }

        private void StartData()
        {
            var pet1 = new Pet()
            {
                Name = "Pjuske",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Brun",
                PrevOwner = "Lars",
                Price = 2000.00

            };
            _petService.CreatePet(pet1);
            var pet2 = new Pet()
            {
                Name = "JohnBob",
                Type = "Kat",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Hvid",
                PrevOwner = "John",
                Price = 150.00
            };
            _petService.CreatePet(pet2);
            var pet3 = new Pet()
            {
                Name = "Ib",
                Type = "Gås",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Grå",
                PrevOwner = "Karl",
                Price = 350.00
            };
            _petService.CreatePet(pet3);
            var pet4 = new Pet()
            {
                Name = "Killer",
                Type = "Hund",
                Birthdate = new DateTime(2018, 08, 08),
                SoldDate = new DateTime(2019, 09, 09),
                Color = "Gul",
                PrevOwner = "Jens",
                Price = 5000.00
            };
            _petService.CreatePet(pet4);
        }

        int PrintFindPetById()
        {
            Console.WriteLine("Skriv id på Pet ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID er altid et tal");
            }

            return id;
        }
        string PrintFintPetByType()
        {
            Console.WriteLine("Skriv type på Pet ");
            string name = Console.ReadLine();
            return name;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private void ShowPets(List<Pet> pets)
        {
            Console.WriteLine("\nListe af film");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} | Navn: {pet.Name} | Type: {pet.Type} " +
                    $"| Birthdate: {pet.Birthdate} | Solddate: {pet.SoldDate}" +
                    $" | Color: {pet.Color} | Previous Owner: {pet.PrevOwner} | Price: {pet.Price}");
            }
            Console.WriteLine("____________________________________________________________________________");
            Console.WriteLine("\n");
        }
        //UI
        public static int PetMenu(string[] menuEnhender)
        {
            Console.WriteLine("Skriv et tal for at vælge: \n");

            for (int i = 0; i < menuEnhender.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuEnhender[i]);
            }
            int valg;
            while (!int.TryParse(Console.ReadLine(), out valg) || valg < 1 || valg > 8)
            {
                Console.WriteLine("Det ikke et tal på listen");
            }
            Console.WriteLine("Valg: " + valg);
            return valg;

        }
    }
}