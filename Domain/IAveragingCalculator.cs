using System.Collections.Generic;

namespace Domain
{
    public interface IAveragingCalculator
    {
        Measurement Aggregate(IEnumerable<Measurement> measurements);
    }
}
