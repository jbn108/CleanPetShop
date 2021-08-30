using System;

namespace NTY.PetShop.Core.Models
{
    
    
    public class Pet
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public PetType Type { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {BirthDate} - {SoldDate} - {Color} - {Price} - {Type.Name}";
        }
    }
}