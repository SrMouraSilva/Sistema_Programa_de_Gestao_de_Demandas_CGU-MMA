using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGD.Application.Util
{
    public static class TimeSpanUtil
    {
        public static string FormatarParaHoras(double valorEmDouble)
        {
            var tsTempo = TimeSpan.FromHours((double)valorEmDouble);
            string minutes = tsTempo.Minutes < 10 ? "0" + tsTempo.Minutes : tsTempo.Minutes.ToString();
            return $"{Math.Floor(tsTempo.TotalHours)}:{minutes}";
        }
    }
}
