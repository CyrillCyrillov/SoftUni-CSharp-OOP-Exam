using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int size = 0;
        
        public FreshwaterFish(string name, decimal price) : base(name, "Can only live in FreshwaterAquarium!", price)
        {
        }

        public override void Eat()
        {
            size += 3;
        }
    }
}
