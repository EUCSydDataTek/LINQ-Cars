using Cars;

var cars = ProcessFile("fuel.csv");

var result = cars.Any(c => c.Manufacturer == "Ford");
//var result = cars.All(c => c.Manufacturer == "Ford");
//var result = cars.Contains(new Car { Name = "Prius Eco" }, new CarComparer());

Console.WriteLine(result);

#region Methods

List<Car> ProcessFile(string path)
{
    return File.ReadAllLines(path)
               .Skip(1)
               .Where(l => l.Length > 1)
               .Select(Car.ParseFromCsv)
               .ToList();
}

#endregion