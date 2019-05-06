using System;
using System.Collections.Generic;
using System.Linq;

namespace CandidateTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var seats = Enumerable.Repeat(false, 26).ToList();

            var firstRandomSeatNumber = (new Random()).Next(25);
            seats[firstRandomSeatNumber] = true;
            Console.WriteLine($"Candidate {1} is being put in seat {firstRandomSeatNumber} ");

            for (int candidate = 2; candidate < 11; candidate++)
            {
                var seat = GetSeatFarthestFromOthers(seats);
                seats[seat] = true;
                Console.WriteLine($"Candidate {candidate} is being put in seat {seat} ");
            }

            Console.ReadLine();

        }

        static int GetSeatFarthestFromOthers(List<bool> seats)
        {
            int? seatNumber = new int?();
            int greatestSpace = 0;
            int? lastSeatTaken = new int?();
            var index = 0;
            var seatCalc = GetSeatDistanceCalculator();

            foreach (var seat in seats)
            {
                if (seat)
                {
                    var currentSpace = seatCalc.GetSpaceBetweenSeats(lastSeatTaken.HasValue ? lastSeatTaken : new int?(), index);

                    if (currentSpace > greatestSpace)
                    {
                        greatestSpace = currentSpace;
                        seatNumber = index - greatestSpace;
                    }

                    lastSeatTaken = index;
                }

                index++;
            }

            if (lastSeatTaken.Value < 25)
            {
                var currentSpace = seatCalc.GetSpaceBetweenSeats(lastSeatTaken, new int?());
                if (currentSpace > greatestSpace)
                {
                    greatestSpace = currentSpace;
                    seatNumber = lastSeatTaken.Value + greatestSpace;
                }
            }
   
        return seatNumber.Value;
        }

        static ISeatDistanceCalculator GetSeatDistanceCalculator()
        {
            return new SeatDistanceCalculator();
        }
    
    }
    
}
