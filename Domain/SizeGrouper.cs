using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class SizeGrouper : IGrouper
    {
        private int groupSize;

        public SizeGrouper(int groupSize)
        {
            this.groupSize = groupSize;
        }

        public IEnumerable<IEnumerable<Measurement>> Group(IList<Measurement> measurements)
        {
            int total = 0;
            while (total < measurements.Count)
            {
                yield return measurements.Skip(total).Take(groupSize).ToList();
                total += groupSize;
            }
        }
    }
}
