using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        private string name;
        private string species;
        private int size;
        private decimal price;

        public Fish(string name, string species, decimal price)
        {
            Name = name;
            Species = species;
            Price = price;
        }


        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //throw new ArgumentException(ExceptionMessages.InvalidName);
                    throw new ArgumentException("Fish name cannot be null or empty.");
                }

                name = value;
            }
        }


        public string Species
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    //throw new ArgumentException(ExceptionMessages.InvalidName);
                    throw new ArgumentException("Fish species cannot be null or empty.");
                }

                name = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
            private set
            {

                size = value;
            }

        }

        public decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                if (value <= 0)
                {
                    //throw new ArgumentException(ExceptionMessages.InvalidName);
                    throw new ArgumentException("Fish price cannot be below or equal to 0.");
                }

                price = value;
            }
        }

        public virtual void Eat()
        {
             
        }
    }
}
