using System;

using System.Collections.Generic;
using EASV.PetShop.Core.ApplicationService;
using EASV.PetShop.Entities;

namespace EASV.PetShop.ConsoleApp
{
    public class Printer : IPrinter
    {
        readonly IPetService _petService;
        readonly IOwnerService _ownerService;

        public Printer(IPetService petService, IOwnerService ownerService)
        {
            _petService = petService;
            _ownerService = ownerService;
        }

        public void PrintUI()
        {
            string[] menuItems =
            {
                "List all Pets",//1
                "Create new Pet",//2
                "Delete Pet",//3
                "Update a Pet",//4
                "Search Pets by Type",//5
                "Sort Pets by Price",//6
                "Get 5 cheapest Pets",//7
                "OwnerMenu",//8
                "Exit"//9
            };

            string[] ownerMenuItems =
            {
                "List all Owners",//1
                "Create new Owner",//2
                "Delete Owner",//3
                "Update a Owner",//4
                "Return to Main Menu"//5
            };

            var selection = PrintMenu(menuItems);
            while (selection != 9)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetPets();
                        PrintPets(pets);
                        break;
                    case 2:
                        var petName = AskQuestion("Pet name: ");
                        var type = AskQuestion("Pet Type: ");
                        var birthDate = AskQuestion("Pet Birthdate: ");
                        var soldDate = AskQuestion("Pet Sold Date: ");
                        var color = AskQuestion("Pet Color: ");
                        var previousOwner = AskQuestion("Previous owner: ");
                        var price = AskQuestion("Pet Price: ");
                        var pet = _petService.NewPet(petName, type, Convert.ToDateTime(birthDate), Convert.ToDateTime(soldDate), color, previousOwner, Convert.ToDouble(price));
                        _petService.CreatePet(pet);
                        break;
                    case 3:
                        var idToDelete = FindPetId();
                        _petService.DeletePet(idToDelete);
                        break;
                    case 4:
                        var idForEdit = FindPetId();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.PetName + " " + petToEdit.PetType + " " + petToEdit.BirthDate + " " + petToEdit.SoldDate + " " + petToEdit.Color + " " + petToEdit.PreviousOwner + " " + petToEdit.Price);
                        var newName = AskQuestion("Pet name: ");
                        var newType = AskQuestion("Pet type: ");
                        var newBirthDate = AskQuestion("Birhtdate: ");
                        var newSoldDate = AskQuestion("Sold Date: ");
                        var newColor = AskQuestion("Pet Color: ");
                        var newPreviousOwner = AskQuestion("Previous Owner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdatePet(new Pet()
                        {
                            PetId = idForEdit,
                            PetName = newName,
                            PetType = newType,
                            BirthDate = Convert.ToDateTime(newBirthDate),
                            SoldDate = Convert.ToDateTime(newSoldDate),
                            Color = newColor,
                            PreviousOwner = newPreviousOwner,
                            Price = Convert.ToDouble(newPrice)
                        });
                        break;
                    case 5:
                        var typeToFind = FindPetType();
                        var result = _petService.FindPetByType(typeToFind);
                        foreach (var foundPets in result)
                        {
                            Console.WriteLine(foundPets.PetName);
                        }
                        break;
                    case 6:
                        var petByPrice = _petService.SortByPrice();
                        PrintPets(petByPrice);
                        break;
                    case 7:
                        ShowCheapestPets();
                        break;
                    case 8:
                        var ownerSelection = PrintOwnerMenu(ownerMenuItems);
                        while (ownerSelection != 5)
                        {
                            switch (ownerSelection)
                            {
                                case 1:
                                    var owners = _ownerService.GetOwners();
                                    PrintOwners(owners);
                                    break;
                                case 2:
                                    var firstName = AskQuestion("First name: ");
                                    var lastName = AskQuestion("Last name: ");
                                    var owner = _ownerService.NewOwner(firstName, lastName);
                                    _ownerService.CreateOwner(owner);
                                    break;
                                case 3:
                                    var ownerIdForEdit = FindOwnerId();
                                    var ownerToEdit = _ownerService.FindOwnerById(ownerIdForEdit);
                                    Console.WriteLine("Updating " + ownerToEdit.FirstName + " " + ownerToEdit.LastName);
                                    var newFirstname = AskQuestion("Firstname: ");
                                    var newLastname = AskQuestion("Lastname: ");
                                    _ownerService.UpdateOwner(new Owner()
                                    {
                                        OwnerId = ownerIdForEdit,
                                        FirstName = newFirstname,
                                        LastName = newLastname
                                    });
                                    break;
                                case 4:
                                    var ownerIdToDelete = FindOwnerId();
                                    _ownerService.DeleteOwner(ownerIdToDelete);
                                    break;
                                default:
                                    break;
                            }
                            ownerSelection = PrintOwnerMenu(ownerMenuItems);
                            Console.Clear();
                        }
                        break;
                    default:
                        break;
                }
                selection = PrintMenu(menuItems);
                Console.Clear();
            }
            AskQuestion("Press enter to exit");
        }



        private void ShowCheapestPets()
        {
            var list = _petService.Get5CheapestPets();
            foreach (var pet in list)
            {
                Console.WriteLine("Pet name: {0} Price: {1:N}", pet.PetName, pet.Price);
            }
        }

        private string FindPetType()
        {
            Console.WriteLine("Insert Pet Type: ");
            string type;
            type = Console.ReadLine();
            return type;
        }

        int FindPetId()
        {
            Console.WriteLine("Insert Pet Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }

        int FindOwnerId()
        {
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert number");
            }
            return id;
        }

        private void PrintPets(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var Pet in pets)
            {
                Console.WriteLine($"Id: {Pet.PetId} Name: {Pet.PetName} " +
                                  $"Type: {Pet.PetType} Birthdate: {Pet.BirthDate} " +
                    $"SoldDate: {Pet.SoldDate} Color: {Pet.Color} " +
                    $"Previous Owner {Pet.PreviousOwner} Price {Pet.Price}");
            }
        }
        private void PrintOwners(List<Owner> owners)
        {
            Console.WriteLine("\nList of Owners");
            foreach (var Owner in owners)
            {
                Console.WriteLine($"Id: {Owner.OwnerId} Name: {Owner.FirstName} {Owner.LastName}");
            }
        }

        int PrintMenu(string[] menuItems)
        {
            Console.WriteLine("\nPetShop Menu\n");
            Console.WriteLine("Please select a command\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + menuItems[i]);
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 9)
            {
                Console.WriteLine("\nPlease input a valid command");
            }
            return selection;
        }
        int PrintOwnerMenu(string[] ownerMenuItems)
        {
            Console.WriteLine("\nPetShop Owner Menu\n");
            Console.WriteLine("Please select a command\n");
            for (int i = 0; i < ownerMenuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + ownerMenuItems[i]);
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > 5)
            {
                Console.WriteLine("\nPlease input a valid command");
            }
            return selection;
        }

        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}