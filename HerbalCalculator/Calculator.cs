using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerbalCalculator
{
    public class Calculator
    {
        private double _averageCost;
        private int _totalFound;
        private double _totalWeight;
        public Calculator(double averageCost = 10, int totalFound = 1000)
        {
            _averageCost = averageCost;
            _totalFound = totalFound;
        }

        public void Calculate(List<Herb> herbList)
        {
            _totalWeight = herbList.Sum(h => h.Quantity);
            // Sort based on Weight
            var calcList = herbList.OrderByDescending(h => h.Total).ToList();
            double totalCost = _averageCost * _totalFound;
            double totalAdjustedWeight = 0;
            Herb basic = calcList[0];
            double basicPercentage = basic.Total / _totalWeight;

            // Find the total adjusted weight by calculating the value in comparison to the cheapest
            foreach (var h in calcList) 
            {
                double percentage = h.Total / _totalWeight;
                h.AdjustedWeight = basicPercentage / percentage;
                h.Found = _totalFound * percentage;
                h.TotalAdjustedWeight = h.Found * h.AdjustedWeight;
                totalAdjustedWeight += h.TotalAdjustedWeight;
            }

            // Determine the cost of a single unit based on the weight
            double costPerBasicUnit = totalCost / totalAdjustedWeight;
            double finalCost = 0;
            foreach(var h in calcList)
            {
                h.Cost = Math.Round(costPerBasicUnit * h.AdjustedWeight, 1);
                finalCost += h.Cost * h.Found;
            }

            Console.WriteLine(finalCost / _totalFound);
        }
    }
}
