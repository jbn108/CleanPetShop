using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;

namespace NTY.PetShop.UI
{
    public class Menu
    {
        private IPetService _petService;
        private IPetTypeRepository _petTypeRepository;
        
        public Menu(IPetService service, IPetTypeRepository typeRepo)
        {
            _petService = service;
            _petTypeRepository = typeRepo;
        }

        public void Start()
        {
            Print(StringConstants.GreetingMessage);
            ShowMainMenu();
            StartLoop();
        }

        private void StartLoop()
        {
            
            int choice;
            while ((choice = GetMenuSelection()) != 0)
            {
                switch (choice)
                {
                    //Show
                    case 1:
                        ReadAll();
                        ShowMainMenu();
                        break;
                    //Search
                    case 2:
                        SearchByType();
                        ShowMainMenu();
                        break;
                    //Create
                    case 3:
                        CreatePet();
                        ShowMainMenu();
                        break;
                    //Delete
                    case 4:
                        DeletePet();
                        ShowMainMenu();
                        break;
                    //Update
                    case 5:
                        EditPet();
                        break;
                    //ShowByPrice
                    case 6:
                        SortByPrice();
                        break;
                    //ShowCheapest
                    case 7:
                        ShowCheapestPet();
                        break;
                    //Exit
                    case 0:
                        break;
                    //Error
                    case -1:
                        Print(StringConstants.ErrorMessage);
                        break;
                    default:
                        break;
                }
            }
        }

        private void EditPet()
        {
            ReadAll();
            Print(StringConstants.SelectPetToEdit);
            var pet = _petService.ReadById(GetMenuSelection());
            Print($"Old name: {pet.Name} - enter new name:");
            var name = Console.ReadLine();
            Print($"Old color: {pet.Color} - enter new name:");
            var color = Console.ReadLine();
            var birthDate = DateTime.Now;
            var soldDate = DateTime.Now;
            double price = GetPetPrice();
            int type = GetPetType();
            
            _petService.UpdatePet(new Pet()
            {
                BirthDate = birthDate,
                Color = color,
                Id = pet.Id,
                Name = name,
                Price = price,
                SoldDate = soldDate,
                Type = _petTypeRepository.ReadById(type)
            });
            
        }

        private void ShowCheapestPet()
        {
            var cheap = _petService.ReadAll().OrderBy(p => p.Price).ToList();
            for (int i = 0; i < cheap.Capacity; i++)
            {
                if (i == 5)
                {
                    break;
                }
                Print(cheap[i].ToString());
            }
        }

        private void SortByPrice()
        {
            var petsByPrice = _petService.ReadAll().OrderBy(p => p.Price).ToList();
            foreach (var pet in petsByPrice)
            {
                Print($"{pet.Name} - {pet.Type} - {pet.Color} - {pet.Price} - {pet.BirthDate}");
            }
        }

        private void DeletePet()
        {
            Print(StringConstants.DeletePetText);
            Pet pet = _petService.Delete(GetMenuSelection());
            Print($"The pet {pet.Name} was deleted!");
        }

        private void SearchByType()
        {
            Print(StringConstants.SearchByPriceMenuText);
            PrintPetTypes();
            int typeId = GetMenuSelection();
            Print(StringConstants.Lines);
            Print($"Showing all pets of type {_petTypeRepository.ReadById(typeId).Name}");
            foreach (var pet in _petService.ReadAll())
            {
                if (pet.Type.Id == typeId)
                {
                    Print($"{pet.Name} - {pet.Color} - {pet.Price} - {pet.BirthDate}");
                }
            }
        }

        private void CreatePet()
        {
            Print(StringConstants.CreatePetText);
            Print(StringConstants.Lines);
            Print(StringConstants.CreatePetName);
            var name = Console.ReadLine();
            Print(StringConstants.CreatePetColor);
            var color = Console.ReadLine();
            var birthDate = DateTime.Now;
            var soldDate = DateTime.Now;
            double price = GetPetPrice();
            int type = GetPetType();

            _petService.Create(new Pet()
            {
                BirthDate = birthDate,
                Color = color,
                Id = null,
                Name = name,
                Price = price,
                SoldDate = soldDate,
                Type = _petTypeRepository.ReadById(type)
            });
        }


        private int GetPetType()
        {
            PrintPetTypes();
            Print(StringConstants.CreatePetType);
            return GetMenuSelection();
        }

        private void PrintPetTypes()
        {
            foreach (var petType in _petTypeRepository.GetAll())
            {
                Print($"Id: {petType.Id} - {petType.Name}");
            }
        }

        private double GetPetPrice()
        {
            while (true)
            {
                Console.WriteLine(StringConstants.CreatePetPrice);
                var priceString = Console.ReadLine();
                double price;
                if (double.TryParse(priceString, out price))
                {
                    return price;
                }
                Console.WriteLine("You must enter a number!");
            }
        }

        private void ReadAll()
        {
            Print("Here are all pets:");
            Print(StringConstants.Lines);
            var pets = _petService.ReadAll();
            foreach (var pet in pets)
            {
                Print($"{pet.Id}, {pet.Name}, {pet.Price}, {pet.Color}, {pet.Type.Name}");
            }
        }

        private int GetMenuSelection()
        {
            
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            Print("");
            Print(StringConstants.Lines);
            Print(StringConstants.ShowPetsMenuMessage);
            Print(StringConstants.SearchPetsByTypeMenuMessage);
            Print(StringConstants.CreatePetMenuMessage);
            Print(StringConstants.DeletePetMenuMessage);
            Print(StringConstants.UpdatePetMenuMessage);
            Print(StringConstants.SortPetsByPriceMessage);
            Print(StringConstants.ShowCheapestPetsMenuMessage);
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
}