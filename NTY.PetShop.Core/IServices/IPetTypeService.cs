using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Core.IServices
{
    public interface IPetTypeService
    {
        PetType Create(PetType pet);

        PetType Delete(int id);

        PetType ReadById(int id);

        PetType UpdatePet(PetType pet);

        List<Pet> ReadAll();
    }
}