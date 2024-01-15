using Cars;

var cars = ProcessCars("fuel.csv");
var manufacturers = ProcessManufacturers("manufacturers.csv");

#region Query Syntax
var query =
        from car in cars
        group car by car.Manufacturer into carGroup
        select new
        {
            Name = carGroup.Key,
            Max = carGroup.Max(c => c.Combined),
            Min = carGroup.Min(c => c.Combined),
            Avg = carGroup.Average(c => c.Combined)
        }
        into result
        orderby result.Max descending
        select result;
#endregion

#region Extension Method Syntax
var query2 =
        cars.GroupBy(c => c.Manufacturer)
        .Select(g =>
        {
            var results = g.Aggregate(new CarStatistics(),
                (acc, c) => acc.Accumulate(c),
                acc => acc.Compute());
            return new
            {
                Name = g.Key,
                Avg = results.Average,
                Min = results.Min,
                Max = results.Max
            };
        })
        .OrderByDescending(r => r.Max);
#endregion

foreach (var result in query2)
{
    Console.WriteLine($"{result.Name}");
    Console.WriteLine($"\t Max: {result.Max}");
    Console.WriteLine($"\t Min: {result.Min}");
    Console.WriteLine($"\t Avg: {result.Avg}");
}

#region Methods

List<Car> ProcessCars(string path)
{
    return File.ReadAllLines(path)
               .Skip(1)
               .Where(l => l.Length > 1)
               .Select(Car.ParseFromCsv)
               .ToList();
}

List<Manufacturer> ProcessManufacturers(string path)
{
    var query =
           File.ReadAllLines(path)
               .Where(l => l.Length > 1)
               .Select(l =>
               {
                   var columns = l.Split(',');
                   return new Manufacturer
                   {
                       Name = columns[0],
                       Headquarters = columns[1],
                       Year = int.Parse(columns[2])
                   };
               });
    return query.ToList();
}

#endregion