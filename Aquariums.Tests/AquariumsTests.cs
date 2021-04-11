namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    public class AquariumsTests
    {
        private string testName = "Testy";
        //private string nullName = null;
        Fish testFish;
        
        [SetUp]
        public void Setup()
        {
            testFish = new Fish(testName);
        }

        [Test]
        public void Fish_Corect_Set_Name()
        {
            Assert.AreEqual(testFish.Name, testName);
        }

        [Test]
        public void Aquarium_Corect_Set_Name()
        {
            Aquarium testAquarium = new Aquarium("Test", 2);
            Assert.AreEqual(testAquarium.Name, "Test");
            Assert.AreEqual(testAquarium.Capacity, 2);

        }

        [Test]
        public void Fish_Corect_Set_Available()
        {
            Assert.AreEqual(testFish.Available, true);
        }

        [Test]
        public void Aquarium_Null_Name_Throw_And_Message()
        {
            string name = null;

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium testAquarium = new Aquarium(name, 5);
            });

            Assert.AreEqual(ex.Message, "Invalid aquarium name! (Parameter 'value')");

        }

        [Test]
        public void Aquarium_Empty_Throw_And_Message()
        {
            string name = "";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium testAquarium = new Aquarium(name, 5);
            });

            Assert.AreEqual(ex.Message, "Invalid aquarium name! (Parameter 'value')");

        }

        [Test]
        public void Aquarium_Negative_Capacity_Throw_And_Message()
        {


            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                Aquarium testAquarium = new Aquarium("Test", -2);
            });

            Assert.AreEqual(ex.Message, "Invalid aquarium capacity!");

        }

        [Test]
        public void Is_Set_Emty_List_Of_Fish()
        {
            Aquarium testAquarium = new Aquarium("Test", 2);

            Assert.AreEqual(testAquarium.Count, 0);
        }

        [Test]
        public void Add_Corect()
        {
            Aquarium testAquarium = new Aquarium("Test", 2);

            testAquarium.Add(testFish);

            Assert.AreEqual(testAquarium.Count, 1);
        }

        [Test]
        public void Add_Over_Capacity_Throw_And_Message()
        {
            Aquarium testAquarium = new Aquarium("Test", 2);

            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.Add(new Fish("Three"));
            });

            Assert.AreEqual(ex.Message, "Aquarium is full!");
        }

        [Test]
        public void Remove_Corectly()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);

            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));
            testAquarium.Add(new Fish("Three"));

            testAquarium.RemoveFish("Two");

            Assert.AreEqual(testAquarium.Count, 2);
            
        }

        [Test]
        public void Remove_Corectly_2()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);

            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));
            testAquarium.Add(new Fish("Three"));

            testAquarium.RemoveFish("Two");

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.RemoveFish("Two");
            });

            Assert.AreEqual(ex.Message, "Fish with the name Two doesn't exist!");

        }

        [Test]
        public void Remove_NON_Excisting_Fish_Throw_And_Message()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);

            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));
            testAquarium.Add(new Fish("Three"));

            

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.RemoveFish("Five");
            });

            Assert.AreEqual(ex.Message, "Fish with the name Five doesn't exist!");
        }

        [Test]
        public void Sell_Available_Fish()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);

            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));
            testAquarium.Add(new Fish("Three"));

            testAquarium.SellFish("Testy");

            Assert.AreEqual(testFish.Available, false);
        }

        [Test]
        public void Sell_NON_Available_Fish()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);

            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));
            testAquarium.Add(new Fish("Three"));

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                testAquarium.SellFish("Five");
            });

            Assert.AreEqual(ex.Message, "Fish with the name Five doesn't exist!");
        }

        [Test]
        public void Report()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);
            testAquarium.Add(testFish);

            string report = testAquarium.Report();

            Assert.AreEqual(report, "Fish available at Test: Testy");
        }

        [Test]
        public void Report_2()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);
            testAquarium.Add(testFish);
            testAquarium.Add(new Fish("Two"));

            testAquarium.SellFish("Two");
            
            string report = testAquarium.Report();

            Assert.AreEqual(report, "Fish available at Test: Testy, Two");
        }

        [Test]
        public void Empty_Report()
        {
            Aquarium testAquarium = new Aquarium("Test", 3);
            

            string report = testAquarium.Report();

            Assert.AreEqual(report, "Fish available at Test: ");
        }



    }
}
