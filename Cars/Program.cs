using Cars;

var cars = ProcessFile("fuel.csv");

var query =
    from car in cars
    where car.Manufacturer == "BMW" && car.Year == 2016
    orderby car.Combined descending, car.Name ascending
    select car;

var query2 =
    cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
    .OrderByDescending(c => c.Combined)
    .ThenBy(c => c.Name)
    .Select(c => c);

foreach (var car in query2.Take(10))
{
    Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combined}");
}

#region FIRST
// First
var top = cars
   .Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
   .OrderByDescending(c => c.Combined)
   .ThenBy(c => c.Name)
   .Select(c => c)
   .First();
//.First(c => c.Manufacturer == "BMW" && c.Year == 2016);
//.FirstOrDefault(c => c.Manufacturer == "abc" && c.Year == 2016);

Console.WriteLine($"\nFirst Car: {top?.Name ?? "No Car found"}");
#endregion

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