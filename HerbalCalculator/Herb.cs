namespace HerbalCalculator
{
    public class Herb
    {
        public int Id;
        public string Name;
        public int Quantity;
        public int Used;

        public double Total { get; private set; }

        public double Cost;

        public double AdjustedWeight;
        public double TotalAdjustedWeight;

        public double Found;
        public Herb(int id, string name, int quantity, int used)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Used = used;
            Total = quantity + used;
        }

        public static Herb FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Herb herb = new Herb(Convert.ToInt32(values[0]), values[1], Convert.ToInt32(values[2]), Convert.ToInt32(values[3]));
            return herb;
        }

        public override string ToString()
        {
            return $"{Id} | {Name}: {Total} | Buying one would cost: {Cost} Aspia.";
        }
    }
}
