using System;

class Program
{
    static void Main()
    {
        Zoo zoo = new Zoo();
        ZooSimulation simulation = new ZooSimulation();

        // Basic setup
        var tigerHabitat = new Habitat("Tiger", 5, 0.3, 1);
        zoo.Habitats.Add(tigerHabitat);

        var tiger = new Tiger("Male", 50);
        zoo.Animals.Add(tiger);
        tigerHabitat.AddAnimal(tiger);

        zoo.MeatStock = 1000;

        while (true)
        {
            Console.WriteLine("\n--- ZOO MENU ---");
            Console.WriteLine("1. Show zoo status");
            Console.WriteLine("2. Next month");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine($"Money: {zoo.Money}");
                Console.WriteLine($"Animals: {zoo.Animals.Count}");
                Console.WriteLine($"Month: {zoo.CurrentMonth}");
            }
            else if (choice == "2")
            {
                simulation.SimulateOneMonth(zoo);
                Console.WriteLine("Month simulated.");
            }
            else if (choice == "3")
            {
                break;
            }
        }
    }
}