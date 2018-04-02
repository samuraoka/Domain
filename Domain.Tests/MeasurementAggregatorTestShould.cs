using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class MeasurementAggregatorTestShould : IClassFixture<Mother>
    {
        private readonly MeasurementAggregator aggregator;

        public MeasurementAggregatorTestShould(Mother mother)
        {
            // Arrange
            aggregator = new MeasurementAggregator(mother.Get4Measurements());
        }

        [Theory]
        [InlineData(4, 1)]
        [InlineData(2, 2)]
        public void ProduceExpectedNumberOfResultWhenGroupingByGroupSize(int groupSize, int expectedNumberOfResults)
        {
            // Act
            var result = aggregator.Aggregate(new SizeGrouper(groupSize), new AveragingCalculator());

            // Assert
            Assert.Equal(expectedNumberOfResults, result.Count());
        }

        [Theory]
        [InlineData(2, 3)]
        public void CalculateAverageHighAndLowValues(int groupSize, int precision)
        {
            // Act
            var result = aggregator.Aggregate(new SizeGrouper(groupSize), new AveragingCalculator());

            // Assert
            var first = result.ElementAt(0);
            Assert.Equal(7.5, first.HighValue, precision);
            Assert.Equal(1.5, first.LowValue, precision);

            var second = result.ElementAt(1);
            Assert.Equal(6.0, second.HighValue, precision);
            Assert.Equal(2.5, second.LowValue, precision);
        }

        [Theory]
        [InlineData(4, 3)]
        public void CalculateModeHighAndLowValues(int groupSize, int precision)
        {
            // Act
            var result = aggregator.Aggregate(new SizeGrouper(groupSize), new ModalCalculator());

            // Assert
            var first = result.ElementAt(0);
            Assert.Equal(10.0, first.HighValue, precision);
            Assert.Equal(1.0, first.LowValue, precision);
        }
    }
}
