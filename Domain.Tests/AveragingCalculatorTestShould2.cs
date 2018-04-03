using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class AveragingCalculatorTestShould2
    {
        public static IEnumerable<object[]> GetMeasurements()
        {
            yield return new object[] { 42.0, 42.0, 42.0, 36.0, 36.0, 36.0 };
            yield return new object[] { 20.0, 10.0, 15.0, 20.0, 10.0, 15.0 };
            yield return new object[] { 12.0, 10.0, 11.0, 5.0, 3.0, 4.0 };
        }

        private IList<Measurement> MakeMeasurements(double high1, double high2, double low1, double low2)
        {
            return new List<Measurement>
            {
                new Measurement { HighValue = high1, LowValue = low1 },
                new Measurement { HighValue = high2, LowValue = low2 },
            };
        }

        [Theory]
        [MemberData(nameof(GetMeasurements))]
        public void CalculateCorrectHighAverage(double high1, double high2, double highAvg,
            double low1, double low2, double lowAvg)
        {
            // Arrange
            var averageCalculator = new AveragingCalculator();
            var measurements = MakeMeasurements(high1, high2, low1, low2);

            // Act
            var result = averageCalculator.Aggregate(measurements);

            // Assert
            Assert.Equal(highAvg, result.HighValue);
        }

        [Theory]
        [MemberData(nameof(GetMeasurements))]
        public void CalculateCorrectLowAverage(double high1, double high2, double highAvg,
            double low1, double low2, double lowAvg)
        {
            // Arrange
            var averageCalculator = new AveragingCalculator();
            var measurements = MakeMeasurements(high1, high2, low1, low2);

            // Act
            var result = averageCalculator.Aggregate(measurements);

            // Assert
            Assert.Equal(lowAvg, result.LowValue);
        }
    }
}
