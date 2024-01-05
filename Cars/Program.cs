using Cars;

var cars = ProcessFile("fuel.csv");

var query =
    from car in cars
    where car.Manufacturer == "BMW" && car.Year == 2016
    orderby car.Combined descending, car.Name ascending
    select car;
//select new
//{
//    car.Manufacturer,
//    car.Name,
//    car.Combined
//};

//var query = cars
//    .Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
//    .OrderByDescending(c => c.Combined)
//    .ThenBy(c => c.Name)
//    .Select(c => new
//    {
//        c.Manufacturer,
//        c.Name,
//        c.Combined
//    });

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