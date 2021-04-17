using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Classes
{
    public class RandomDateTime
    {
        DateTime start;
        Random gen;
        int range;

        public RandomDateTime(int year, int month, int day)
        {
            start = new DateTime(year, month, day);
            gen = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }
}
