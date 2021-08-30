using NTY.PetShop.Core.IServices;
using NTY.PetShop.Domain.IRepositories;
using NTY.PetShop.Domain.Services;
using NTY.PetShop.SQL.Repositories;

namespace NTY.PetShop.UI
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPetRepository petRepository = new PetRepository();
            IPetTypeRepository petTypeRepository = new PetTypeRepository();
            IPetService petService = new PetService(petRepository);
            
            var menu = new Menu(petService, petTypeRepository);
            menu.Start();
        }
    }
}