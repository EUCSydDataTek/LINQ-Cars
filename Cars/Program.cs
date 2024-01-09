using Cars;
using System.Xml;
using System.Xml.Serialization;

var cars = ProcessFile("fuel.csv");

XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));

string CarXml = default!;

using(StringWriter sw = new StringWriter())
{
    serializer.Serialize(sw, cars);
    CarXml = sw.ToString();
}

Console.Write(CarXml);
//serializer.Serialize(Console.Out,cars);

File.WriteAllText("Cars.xml",CarXml);

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