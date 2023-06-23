using HerbalCalculator;

var filePath = "C:\\temp\\Kosten en Kruidenlijst.csv";
if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found. Please insert a file in the following format: {filePath}");
    return;
}

Console.WriteLine("Type in the average cost per found herb (Default to 2.5)");

double averageHerbCost = 2.5;

while (true)
{
    string field = Console.ReadLine();
    if(string.IsNullOrEmpty(field))
    {
        break;
    }

    var success = double.TryParse(field, out averageHerbCost);

    if (success)
    {
        break;
    }

    Console.WriteLine("value given is not a valid double, try again!");
}

List<Herb> herbs = File.ReadAllLines(filePath).Select(h => Herb.FromCsv(h)).ToList();
Calculator calculator = new(averageHerbCost);
calculator.Calculate(herbs);
herbs = herbs.OrderByDescending(h => h.Cost).ToList();
Console.WriteLine("-------------------------------------------------");
var fileName = $"C:\\temp\\costlist-{averageHerbCost}-aspia.txt";
using (StreamWriter newFile = new(File.Create(fileName)))
{
    newFile.WriteLine($"Cost of the average herb: {averageHerbCost}");
    foreach (Herb herb in herbs)
    {
        newFile.WriteLine(herb.ToString());
        Console.WriteLine(herb.ToString());
        Console.WriteLine("-------------------------------------------------");
    }
}

Console.WriteLine($"File Created at {fileName}");
Console.ReadLine();