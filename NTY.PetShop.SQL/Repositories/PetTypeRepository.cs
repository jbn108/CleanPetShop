using System.Collections.Generic;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.SQL.Entities;

namespace NTY.PetShop.SQL.Repositories
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private static List<PetType> _petsTypeTable;
        
        public PetTypeRepository()
        {
           _petsTypeTable = new List<PetType>();
           
           _petsTypeTable.Add(new PetType()
           {
               Id = 1,
               Name = "Dog",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 2,
               Name = "Cat",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 3,
               Name = "Fish",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 4,
               Name = "Monkey",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 5,
               Name = "Lobster",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 6,
               Name = "Oister",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 7,
               Name = "Pig",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 8,
               Name = "Chicken",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 9,
               Name = "Kangaroo",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 10,
               Name = "Shrimp",
           });
           _petsTypeTable.Add(new PetType()
           {
               Id = 11,
               Name = "Seal",
           });
        }
        
        public PetType ReadById(int petEntityTypeId)
        {
            foreach(var petType in _petsTypeTable)
            {
                if (petType.Id == petEntityTypeId)
                {
                    return petType;
                }
            }
            return null;
        }

        public List<PetType> GetAll()
        {
            return _petsTypeTable;
        }
    }
}