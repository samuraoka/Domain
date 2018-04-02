using System.Collections.Generic;

namespace Domain
{
    public class MeasurementAggregator
    {
        private readonly IList<Measurement> measurements;

        public MeasurementAggregator(IList<Measurement> measurements)
        {
            this.measurements = measurements;
        }

        public IEnumerable<Measurement> Aggregate(IGrouper grouper, IAveragingCalculator calculator)
        {
            var partitions = grouper.Group(measurements);
            foreach (var partition in partitions)
            {
                yield return calculator.Aggregate(partition);
            }
        }
    }
}
