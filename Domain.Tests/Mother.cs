using System.Collections.Generic;

namespace Domain.Tests
{
    public class Mother
    {
        public IList<Measurement> Get4Measurements()
        {
            return new List<Measurement>
            {
                new Measurement { HighValue = 10.0, LowValue = 1.0 },
                new Measurement { HighValue = 5.0, LowValue = 2.0 },
                new Measurement { HighValue = 2.0, LowValue = 1.0 },
                new Measurement { HighValue = 10.0, LowValue = 4.0 },
            };
        }

        public IList<Measurement> CreateMeasurementListOfSize(int size)
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
