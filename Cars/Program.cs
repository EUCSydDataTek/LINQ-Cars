using Cars;
using System;

//var cars = ProcessFile("fuel.csv");

var cars = new List<PersonCar>
            {
                new PersonCar
                {
                    Name = "Car 1",
                    Passengers = new List<Person>
                    {
                        new Person { Name = "Person 1"},
                        new Person { Name = "Person 2"}
                    }
                },
                new PersonCar
                {
                    Name = "Car 2",
                    Passengers = new List<Person>
                    {
                        new Person { Name = "Person 3"},
                    }
                },
                new PersonCar
                {
                    Name = "Car 3",
                    Passengers = new List<Person>
                    {
                        new Person { Name = "Person 4"},
                        new Person { Name = "Person 5"}
                    }
                }
            };

foreach (PersonCar car in cars)
{
    Console.WriteLine(car.Name);
    foreach (Person person in car.Passengers)
    {
        Console.WriteLine($"--- {person.Name}");
    }
}

Console.WriteLine("\n*** With SelectMany ***");
foreach (Person person in cars.SelectMany(c => c.Passengers))
{
    Console.WriteLine($"--- {person.Name}");
}

#region SELECTMANY ON STRINGS
//var letterResult = cars.Select(c => c.Name);
//foreach (string name in letterResult)
//{
//    foreach (char letter in name)
//    {
//        Console.WriteLine(letter);
//    }
//}

//var letterResult2 = cars.SelectMany(c => c.Name)
//    .OrderBy(c => c);
//foreach (char letter in letterResult2)
//{
//    Console.WriteLine(letter);
//}
#endregion

#region Methods

List<Car> ProcessFile(string path)
{
    return File.ReadAllLines(path)
               .Skip(1)
               .Where(l => l.Length > 1)
               .ToCar() // <- Extension from CarExtensions
               .ToList();
}

#endregion

#region Classes

class PersonCar : Car
{
    public List<Person> Passengers { get; set; }
}

class Person
{
    public string Name { get; set; }
}

#endregion