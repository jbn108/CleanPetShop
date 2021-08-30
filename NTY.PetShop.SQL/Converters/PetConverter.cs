using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.SQL.Entities;
using NTY.PetShop.SQL.Repositories;

namespace NTY.PetShop.SQL.Converters
{
    
    public class PetConverter
    {
        private IPetTypeRepository _petTypeRepo = new PetTypeRepository();
        public PetEntity Convert(Pet pet)
        {
            return new PetEntity()
            {
                BirthDate = pet.BirthDate,
                Color = pet.Color,
                Id = pet.Id,
                Name = pet.Name,
                Price = pet.Price,
                SoldDate = pet.SoldDate,
                TypeId = pet.Type.Id
            };
        }
        
        public Pet Convert(PetEntity petEntity)
        {
            return new Pet()
            {
                Id = petEntity.Id,
                BirthDate = petEntity.BirthDate,
                Color = petEntity.Color,
                Name = petEntity.Name,
                Price = petEntity.Price,
                SoldDate = petEntity.SoldDate,
                Type = _petTypeRepo.ReadById(petEntity.TypeId)
            };
        }
    }
}