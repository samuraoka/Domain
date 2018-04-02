using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class MeasurementAggregatorTestShould : IClassFixture<Mother>, IClassFixture<AveragingCalculator>
    {
        private readonly MeasurementAggregator aggregator;
        private readonly IAveragingCalculator calculator;

        public MeasurementAggregatorTestShould(Mother mother, AveragingCalculator calculator)
        {
            aggregator = new MeasurementAggregator(mother.Get4Measurements());
            this.calculator = calculator;
        }

        [Theory]
        [InlineData(4, 1)]
        [InlineData(2, 2)]
        public void ProduceExpectedNumberOfResultWhenGroupingByGroupSize(int groupSize, int expectedNumberOfResults)
        {
            var result = aggregator.Aggregate(new SizeGrouper(groupSize), calculator);
            Assert.Equal(expectedNumberOfResults, result.Count());
        }
    }
}
