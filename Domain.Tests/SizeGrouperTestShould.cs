using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class SizeGrouperTestShould : IClassFixture<Mother>
    {
        private Mother mother;

        public SizeGrouperTestShould(Mother mother)
        {
            this.mother = mother;
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(2, 1, 2)]
        [InlineData(4, 2, 2)]
        public void ProduceGroupOfSizeIfListOfOneIsGroupedBy(int dataSize, int sizeOfEachGroup, int numberOfGroups)
        {
            var measurements = mother.CreateMeasurementListOfSize(dataSize);

            var grouper = new SizeGrouper(sizeOfEachGroup);
            var groupedResults = grouper.Group(measurements);

            Assert.Equal(numberOfGroups, groupedResults.Count());
            Assert.True(groupedResults.All(g => g.Count() == sizeOfEachGroup));
        }
    }
}
