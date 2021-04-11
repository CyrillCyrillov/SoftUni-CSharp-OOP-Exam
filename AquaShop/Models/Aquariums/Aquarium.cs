using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;

        private int capacity;

        private int comfort;

        private HashSet<string> notAvalableNames;

        private List<IFish> fishes;

        private List<IDecoration> decorations;




        public Aquarium(string name, int capacity)
        {
            Name = name;

            Capacity = capacity;

            decorations = new List<IDecoration>();

            fishes = new List<IFish>();
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
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                if(notAvalableNames.Contains(value))
                {
                    //throw new ArgumentException(ExceptionMessages.InvalidName);
                    throw new ArgumentException("Aquarium name is not avalible");
                }

                name = value;
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            private set
            {
                if (value <= 0)
                {
                    //throw new ArgumentException(ExceptionMessages.InvalidName);
                    throw new ArgumentException("Capacity must be positive number!");
                }
                

                capacity = value;
            }
        }

        public int Comfort
        {
            get
            {
                int sumOfComfort = 0;

                foreach (var element in decorations)
                {
                    sumOfComfort += element.Comfort;
                }
                
                return sumOfComfort;
            }
        }

        public ICollection<IDecoration> Decorations
        {
            get
            {
                return decorations;
            }
            
        }

        public ICollection<IFish> Fish
        {
            get
            {
                return fishes;
            }

        }

        public void AddDecoration(IDecoration decoration)
        {
            decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            
            if(Capacity < fishes.Count + 1)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public void Feed()
        {
            foreach (var fish in fishes)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            string result = null;
            if(fishes.Count == 0)
            {
                result = "none";
            }
            else
            {
                /*
                "{aquariumName} ({aquariumType}):
                    Fish: {fishName1}, {fishName2}, {fishName3} (…) / none
                    Decorations: {decorationsCount}
                    Comfort: {aquariumComfort}"

                */
                
            }

            return result;
        }

        public bool RemoveFish(IFish fish)
        {
            var fishForRemove = fishes.FirstOrDefault(n => n.Name == fish.Name);

            if(fishForRemove == null)
            {
                return false;
            }

            fishes.Remove(fishForRemove);
            return true;


        }
    }
}
