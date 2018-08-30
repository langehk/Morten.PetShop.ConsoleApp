﻿using System;

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
                Name = "pip",
                Type = "Fugl",
                BirthDate = new DateTime(2013, 05, 08),
                SoldDate = new DateTime(2019, 05, 09),
                Color = "grøn",
                PreviousOwner = "Brian",
                Price = 3500

            };
            _petService.CreatePet(pet1);

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
            Console.WriteLine("____________________________________________________________________________");
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
            Console.WriteLine("selection: " + selection);
            return selection;

        }
    }
}