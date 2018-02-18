using System;
using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class FooTests
    {
        [Fact]
        public void Foo()
        {
            var measurements = new List<Measurement> {
                new Measurement { HighValue = 10, LowValue = -1 },
            };

            var grouper = new SizeGrouper(1);
            var groupedResults = grouper.Group(measurements);

            Assert.Equal(1, groupedResults.Count);
        }
    }

    internal class SizeGrouper
    {
        private int v;

        public SizeGrouper(int v)
        {
            this.v = v;
        }

        internal IList<IList<Measurement>> Group(List<Measurement> measurements)
        {
            throw new NotImplementedException();
        }
    }
}
