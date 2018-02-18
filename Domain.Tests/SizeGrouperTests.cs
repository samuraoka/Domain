using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Domain.Tests
{
    public class SizeGrouperTests
    {
        [Fact]
        public void ShouldProduceGroupOfSizeOneIfListOfOneIsGroupedByOne()
        {
            var measurements = new List<Measurement> {
                new Measurement { HighValue = 10, LowValue = -1 },
            };

            var grouper = new SizeGrouper(1);
            var groupedResults = grouper.Group(measurements);

            Assert.Equal(1, groupedResults.Count);
        }

        [Fact]
        public void ShouldProduceGroupOfSizeTwoIfListOfTwoIsGroupedByOne()
        {
            var measurements = new List<Measurement> {
                new Measurement { HighValue = 10, LowValue = -1 },
                new Measurement { HighValue = 10, LowValue = -1 },
            };

            var grouper = new SizeGrouper(1);
            var groupedResults = grouper.Group(measurements);

            Assert.Equal(2, groupedResults.Count);
        }

        [Fact]
        public void ShouldProduceGroupOfSizeTwoIfListOfFourIsGroupedByTwo()
        {
            var measurements = new List<Measurement> {
                new Measurement { HighValue = 10, LowValue = -1 },
                new Measurement { HighValue = 10, LowValue = -1 },
                new Measurement { HighValue = 10, LowValue = -1 },
                new Measurement { HighValue = 10, LowValue = -1 },
            };

            var grouper = new SizeGrouper(2);
            var groupedResults = grouper.Group(measurements);

            Assert.Equal(2, groupedResults.Count);
            Assert.True(groupedResults.All(g => g.Count == 2));
        }
    }
}
