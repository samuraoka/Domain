using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class AveragingCalculatorTestShould : IClassFixture<Mother>
    {
        private readonly AveragingCalculator averageCalculator;
        private readonly IList<Measurement> measurements;
        private readonly Measurement result;

        public AveragingCalculatorTestShould(Mother mother)
        {
            // Arrange
            averageCalculator = new AveragingCalculator();
            measurements = mother.Get4Measurements();

            // Act
            result = averageCalculator.Aggregate(measurements);
        }

        [Fact]
        public void CalculateCorrectHighAverage()
        {
            // Arrange
            var expectedAverage = AverageHigh(measurements);

            // Assert
            Assert.Equal(expectedAverage, result.HighValue);
        }

        [Fact]
        public void CalculateCorrectLowAverage()
        {
            // Arrange
            var expectedAverage = AverageLow(measurements);

            // Assert
            Assert.Equal(expectedAverage, result.LowValue);
        }

        private object AverageLow(IList<Measurement> measurements)
        {
            return measurements.Sum(m => m.LowValue) / measurements.Count;
        }

        private double AverageHigh(IList<Measurement> measurements)
        {
            return measurements.Sum(m => m.HighValue) / measurements.Count;
        }
    }
}
