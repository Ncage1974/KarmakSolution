using Xunit;
using Xunit.Sdk;

namespace CandidateTesting
{
    public class SeatDistanceCalculatorTests
    {
        [Theory]
        [InlineData(0,15,7)]
        [InlineData(5,14,4)]
        public void GetSpaceBetweenSeatsCalcCorrectlyWhenHasABeginAndEndSeat(int begin, int end, int correctAnswer)
        {
            ISeatDistanceCalculator seatCalculator = new SeatDistanceCalculator();

            Assert.Equal(seatCalculator.GetSpaceBetweenSeats(begin,end),correctAnswer);
        }

        [Fact]
        public void GetSpaceBetweenSeatsCalcCorrectlyWhenHasABeginButNoEndSeat()
        {
            ISeatDistanceCalculator seatCalculator = new SeatDistanceCalculator();

            Assert.Equal(seatCalculator.GetSpaceBetweenSeats(3,new int?()),22);
        }


        [Fact]
        public void GetSpaceBetweenSeatsCalcCorrectlyWhenHasAEndnButNoBeginSeat()
        {
            ISeatDistanceCalculator seatCalculator = new SeatDistanceCalculator();

            Assert.Equal(seatCalculator.GetSpaceBetweenSeats(new int?(),23), 23);
        }


    }
}