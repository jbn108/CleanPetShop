using System.Collections.Generic;
using NTY.PetShop.Core.Models;

namespace NTY.PetShop.Domain.IRepositories
{
    public interface IPetTypeRepository
    {
        PetType ReadById(int petEntityTypeId);

        List<PetType> GetAll();
    }
}