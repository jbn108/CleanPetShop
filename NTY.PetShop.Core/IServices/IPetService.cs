using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Core.IServices
{
    public interface IPetService
    {
        Pet Create(Pet pet);

        Pet Delete(int id);

        Pet ReadById(int id);

        Pet UpdatePet(Pet pet);

        List<Pet> ReadAll();
        
        
    }
}