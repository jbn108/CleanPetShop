using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Domain.IRepositories
{
    public interface IPetRepository
    {
        Pet Add(Pet pet);

        Pet ReadById(int id);

        Pet UpdatePet(Pet pet);

        Pet Delete(int id);

        List<Pet> GetAll();
    }
}