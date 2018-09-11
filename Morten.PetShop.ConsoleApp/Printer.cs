using System;

using System.Collections.Generic;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.ConsoleApp
{
    public class Printer : IPrinter
    {
        private IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
            

            StartData();
        }
        /*
         * Shows the menu, with the options for the user.
         */ 
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
                    // Get a list of all pets
                    case 1:
                        var pets = _petService.GetAllPets();
                        ShowPets(pets);
                        break;
                        //Search for at pet type
                    case 2:
                        var searchType = PrintFintPetByType();
                        var result =_petService.FindPetByType(searchType);
                        foreach (var searchPet in result)
                        {
                            Console.WriteLine($"Id: {searchPet.Id} Name: { searchPet.Name}  Type: {searchPet.Type} BirthDate: {searchPet.BirthDate} SoldDate: {searchPet.SoldDate} Color: {searchPet.Color} PreviousOwner: {searchPet.PreviousOwner} Price: {searchPet.Price}");
                        }

                        break;

                        //Add a new pet
                    case 3:
                        var name = AskQuestion("Name: ");

                        var type = AskQuestion("Type: ");

                        var birthDate = AskQuestion("Birthdate: ");

                        var soldDate = AskQuestion("Solddate: ");

                        var color = AskQuestion("Color: ");

                        var previousOwner = AskQuestion("Previous owner: ");

                        var price = AskQuestion("Price: ");

                        var pet = _petService.NewPet
                                             (name, 
                                              type, 
                                              Convert.ToDateTime(birthDate),
                                              Convert.ToDateTime(soldDate), 
                                              color,
                                              previousOwner, 
                                              Convert.ToDouble(price));
                        
                        _petService.CreatePet(pet);
                        break;

                        // Remove a pet

                    case 4:
                        var iDForDelete = PrintFindPetById();
                        _petService.DeletePet(iDForDelete);
                        break;

                        //Edit a pet
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
                            BirthDate = Convert.ToDateTime(newBirthDate),
                            SoldDate = Convert.ToDateTime(newSoldDate),
                            Color = newColor,
                            PreviousOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice)
                        });
                        break;

                        // Sort after price "Lowest first"
                    case 6:
                        var sortResult = _petService.SortByprice();

                        foreach (var sortPet in sortResult)
                        {
                            Console.WriteLine($"Id: {sortPet.Id} | Name: { sortPet.Name} | Type: {sortPet.Type} | BirthDate: {sortPet.BirthDate} | SoldDate: {sortPet.SoldDate} | Color: {sortPet.Color} | PreviousOwner: {sortPet.PreviousOwner} | Price: {sortPet.Price}");
                        }
                        break;

                        //Find the 5 cheapest
                    case 7:
                        GetFiveCheapestPets();
                        break;
                    default:
                        break;
                }
                selection = PetMenu(menuEnhender);
            }
            Console.WriteLine("Closing program...");


            Console.ReadLine();
        }

        private void GetFiveCheapestPets()
        {
            var list = _petService.GetFiveCheapest();
            foreach (var pet in list)
            {
                Console.WriteLine($"Id: {pet.Id} | Name: { pet.Name} | Type: {pet.Type} | BirthDate: {pet.BirthDate} | SoldDate: {pet.SoldDate} | Color: {pet.Color} | PreviousOwner: {pet.PreviousOwner} | Price: {pet.Price}");
            }
        }

        /*
         *  Pre-added pets, "data" that will show up when initializing the program.
         */
        private void StartData()
        {
            var pet1 = new Pet()
            {
                Name = "pip",
                Type = "Bird",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2019, 05, 09),
                Color = "Black",
                PreviousOwner = "Brian",
                Price = 3500

            };
            _petService.CreatePet(pet1);

            var pet2 = new Pet()
            {
                Name = "Brian",
                Type = "Dog",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2015, 05, 09),
                Color = "Pink",
                PreviousOwner = "Ole",
                Price = 7777
                    
            };
            _petService.CreatePet(pet2);

            var pet3 = new Pet()
            {
                Name = "Allan",
                Type = "Dog",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2014, 05, 09),
                Color = "Yellow",
                PreviousOwner = "Ole",
                Price = 2345

            };
            _petService.CreatePet(pet3);

            var pet4 = new Pet()
            {
                Name = "Allan",
                Type = "Horse",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2014, 05, 09),
                Color = "Green",
                PreviousOwner = "Ole",
                Price = 2345

            };
            _petService.CreatePet(pet4);

            var pet5 = new Pet()
            {
                Name = "Karl",
                Type = "Goat",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2016, 05, 09),
                Color = "Purple",
                PreviousOwner = "Ole",
                Price = 3333

            };
            _petService.CreatePet(pet5);

            var pet6 = new Pet()
            {
                Name = "Otto",
                Type = "Dog",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2017, 05, 09),
                Color = "White",
                PreviousOwner = "Ole",
                Price = 9999

            };
            _petService.CreatePet(pet6);
        }

        int PrintFindPetById()
        {
            Console.WriteLine("Type a pet ID ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID");
            }

            return id;
        }
        string PrintFintPetByType()
        {
            Console.WriteLine("Pet type: ");
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
            Console.WriteLine("\nList of pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} | Navn: {pet.Name} | Type: {pet.Type} " +
                                  $"| Birthdate: {pet.BirthDate} | Solddate: {pet.SoldDate}" +
                                  $" | Color: {pet.Color} | Previous Owner: {pet.PreviousOwner} | Price: {pet.Price}");
            }
            Console.WriteLine("_____________________________^ PETS LISTED ABOVE ^__________________________________");
            Console.WriteLine("\n");
        }
        //UI
        public static int PetMenu(string[] menuEnhender)
        {
            Console.WriteLine("Type a number: \n");

            for (int i = 0; i < menuEnhender.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + menuEnhender[i]);
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 8)
            {
                Console.WriteLine("That's not a valid number");
            }
            Console.WriteLine("Your selected numer: " + selection);
            return selection;

        }
    }
}