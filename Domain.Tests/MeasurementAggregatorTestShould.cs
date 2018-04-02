using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class MeasurementAggregatorTestShould : IClassFixture<Mother>
    {
        private readonly MeasurementAggregator aggregator;

        public MeasurementAggregatorTestShould(Mother mother)
        {
            aggregator = new MeasurementAggregator(mother.Get4Measurements());
        }

        [Theory]
        [InlineData(4, 1)]
        public void ProduceSingleResultWhenGroupingByFour(int groupSize, int expectedNumberOfGroups)
        {
            var result = aggregator.Aggregate(new SizeGrouper(groupSize), new AveragingCalculator());
            Assert.Equal(expectedNumberOfGroups, result.Count());
        }
    }
}
