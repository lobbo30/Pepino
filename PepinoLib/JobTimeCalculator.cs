using System;
using System.Collections.Generic;
using System.Linq;

namespace PepinoLib
{
    public class JobTimeCalculator
    {
        public static int GetTotalProcessTime(ICollection<Job> jobSequence)
        {
            return jobSequence.Sum(j => j.ProcessTime);
        }

        public static int GetTotalFlowTime(ICollection<Job> jobSequence)
        {
            if (jobSequence == null)
            {
                throw new ArgumentException();
            }
            int total = 0;
            for (int i = 0; i < jobSequence.Count; i++)
            {
                total += jobSequence.Take(i + 1).Sum(j => j.ProcessTime);
            }
            return total;
        }
    }
}