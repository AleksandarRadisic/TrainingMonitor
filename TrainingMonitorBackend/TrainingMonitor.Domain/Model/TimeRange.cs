using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingMonitor.Domain.Model
{
    public class TimeRange
    {
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }

        public TimeRange(DateTime start, DateTime end)
        {
            if (start > end)
            {
                Start = end;
                End = start;
            }
            else
            {
                Start = start;
                End = end;
            }
        }
    }
}
