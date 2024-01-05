using Cars;

var cars = ProcessFile("fuel.csv");

var query = cars.OrderByDescending(c => c.Combined);
//.ThenBy(c => c.Name);

//var query =
//    from car in cars
//    orderby car.Combined descending, car.Name ascending
//    select car;

foreach (var car in query.Take(10))
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