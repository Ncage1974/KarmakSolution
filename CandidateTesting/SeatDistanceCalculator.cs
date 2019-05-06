using System;

namespace CandidateTesting
{
    public class SeatDistanceCalculator : ISeatDistanceCalculator
    {
        int ISeatDistanceCalculator.GetSpaceBetweenSeats(int? begin, int? end)
        {
            if (begin.HasValue && end.HasValue)
            {
                return (int)Math.Floor((decimal)(end.Value - begin.Value) / 2);
            }
            else if (!begin.HasValue)
            {
                return end.Value;
            }
            else
            {
                return 25 - begin.Value;
            }
        }
    }
}