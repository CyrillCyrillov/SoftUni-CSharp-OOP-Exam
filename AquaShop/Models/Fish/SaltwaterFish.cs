using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        private int size = 5;
        
        public SaltwaterFish(string name, decimal price) : base(name, "Can only live in SaltwaterAquarium!", price)
        {
        }

        public override void Eat()
        {
            size += 2;
        }
    }
}
