using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace AutomaticStation
{
   public static class TimeAccelerator
    {
       
        public static TimeSpan AccelerateTime(DateTime start) // emulate the acceleration time "times" times
        {
            int times = 10000;
            TimeSpan span = new TimeSpan();
           // Int32.TryParse(ConfigurationManager.AppSettings["times"], out times);
            if (start != null)
            {
               span = DateTime.Now.Subtract(start);
               var now = start.AddSeconds(span.TotalSeconds * times);
                span = now - start;
                Console.WriteLine("Duration Accelerated {1} times: {0}", span.ToString(), times);
                return span;
            }
           
            return span;
        }
    }
}