using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.SQL.Converters;
using NTY.PetShop.SQL.Entities;

namespace NTY.PetShop.SQL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private static List<PetEntity> _petsTable = new List<PetEntity>();
        private List<PetType> _petTypes = new PetTypeRepository().GetAll();
        private static int _id = 1;
        private readonly PetConverter _petConverter;

        public PetRepository()
        {
            _petConverter = new PetConverter();
            
            
            Add(new Pet()
            {
                BirthDate = DateTime.Now,
                Color = "Orange",
                Id = null,
                Name = "Haraldur",
                Price = 2524345547568.05,
                SoldDate = DateTime.Today,
                Type = _petTypes[1],
            });
            
            Add(new Pet()
            {
                BirthDate = DateTime.Now,
                Color = "Blue",
                Id = null,
                Name = "Haraldude",
                Price = 25345364686443.99,
                SoldDate = DateTime.Today,
                Type = _petTypes[2],
            });
            
            Add(new Pet()
            {
                BirthDate = DateTime.Now,
                Color = "Green",
                Id = null,
                Name = "Haralder",
                Price = 2500000000,
                SoldDate = DateTime.Today,
                Type = _petTypes[5],
            });
            
        }

        public Pet Add(Pet pet)
        {
            var petEntity = _petConverter.Convert(pet);
            petEntity.Id = _id++;
            _petsTable.Add(petEntity);
            return _petConverter.Convert(petEntity);
        }

        public Pet ReadById(int id)
        {
            foreach (var petEntity in _petsTable)
            {
                if (petEntity.Id == id)
                {
                    return _petConverter.Convert(petEntity);
                }
            }

            return null;
        }

        public Pet UpdatePet(Pet pet)
        {

            var petOld = _petsTable.FirstOrDefault(p => p.Id == pet.Id);
            if (petOld != null)
            {
                petOld.Name = pet.Name;
                petOld.Color = pet.Color;
                petOld.Price = pet.Price;
                petOld.BirthDate = pet.BirthDate;
                petOld.SoldDate = pet.SoldDate;
                petOld.TypeId = pet.Type.Id;
            }
            
            /*
            _petsTable.Remove(_petsTable.FirstOrDefault(p => p.Id == pet.Id));
            _petsTable.Add(_petConverter.Convert(pet));
            */
            return null;
        }

        public Pet Delete(int id)
        {
            var pet = ReadById(id);
            _petsTable.Remove(_petsTable.FirstOrDefault(p => p.Id == id));
            return pet;
        }

        public List<Pet> GetAll()
        {
            var listOfPets = new List<Pet>();
            foreach (var pet in _petsTable)
            {
                listOfPets.Add(_petConverter.Convert(pet));
            }
            return listOfPets;
        }

        public List<PetType> GetPetTypes()
        {
            return _petTypes;
        }
    } 
}