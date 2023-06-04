using HerbalCalculator;

List<Herb> herbs = File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, "Kosten en Kruidenlijst.csv")).Select(h => Herb.FromCsv(h)).ToList();
Calculator calculator = new Calculator(2.5);
calculator.Calculate(herbs);
herbs = herbs.OrderByDescending(h => h.Cost).ToList();
Console.WriteLine("-------------------------------------------------");
foreach (Herb herb in herbs)
{
    Console.WriteLine(herb.ToString());
    Console.WriteLine("-------------------------------------------------");
}

Console.ReadLine();