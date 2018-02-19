using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class SizeGrouperTests
    {
        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(4, 2, 2)]
        public void ShouldProduceGroupOfSizeIfListOfOneIsGroupedBy(int dataSize, int sizeOfEachGroup, int numberOfGroups)
        {
            var measurements = CreateMeasurementListOfSize(dataSize);

            var grouper = new SizeGrouper(sizeOfEachGroup);
            var groupedResults = grouper.Group(measurements);

            Assert.Equal(numberOfGroups, groupedResults.Count);
            Assert.True(groupedResults.All(g => g.Count == sizeOfEachGroup));
        }

        private IList<Measurement> CreateMeasurementListOfSize(int size)
        {
            var result = new List<Measurement>();
            for (int i = 0; i < size; i++)
            {
                result.Add(new Measurement { HighValue = 10, LowValue = -1 });
            }
            return result;
        }
    }
}
