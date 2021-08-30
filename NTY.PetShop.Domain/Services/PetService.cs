using System.Collections.Generic;
using NTY.PetShop.Core.IServices;
using NTY.PetShop.Core.Models;
using NTY.PetShop.Domain.IRepositories;

namespace NTY.PetShop.Domain.Services
{
    public class PetService : IPetService
    {
        private IPetRepository _petRepository;
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet Create(Pet pet)
        {
            return _petRepository.Add(pet);
        }

        public Pet Delete(int id)
        {
            return _petRepository.Delete(id);
        }

        public Pet ReadById(int id)
        {
            return _petRepository.ReadById(id);
        }

        public Pet UpdatePet(Pet pet)
        {
            return _petRepository.UpdatePet(pet);
        }

        public List<Pet> ReadAll()
        {
            return _petRepository.GetAll();
        }

        
    }
}