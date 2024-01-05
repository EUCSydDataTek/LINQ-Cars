using Cars;

var cars = ProcessFile("fuel.csv");

foreach (var car in cars)
{
    Console.WriteLine(car.Name);
}

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