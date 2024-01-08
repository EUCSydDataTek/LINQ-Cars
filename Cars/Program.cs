using Cars;
using System.Text.Json;

var cars = ProcessFile("fuel.csv");

// Set json options (Optional)
JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
jsonOptions.WriteIndented = true;

// Create Json
string CarJson = JsonSerializer.Serialize(cars,jsonOptions);

// Save Json To Json file
File.WriteAllText("Cars.json", CarJson);

// Read Json
var jsonCars = JsonSerializer.Deserialize<List<Car>>(CarJson);

foreach (var car in jsonCars)
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