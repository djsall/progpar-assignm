using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Forms {
	class LocationsHandler {
		public List<string> counties = new List<string>() { "Bács-Kiskun", "Baranya", "Békés", "Borsod-Abaúj-Zemplén", "Csongrád", "Fejér", "Győr-Moson-Sopron", "Hajdú-Bihar", "Heves", "Jász-Nagykun-Szolnok", "Komárom-Esztergom", "Nógrád", "Pest", "Somogy", "Szabolcs-Szatmár-Bereg", "Tolna", "Vas", "Veszprém", "Zala" };
		public List<string> cities = new List<string>(File.ReadAllLines("irszVarKer.txt"));

		public int weekOfTheYear() {
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
			Calendar cal = dfi.Calendar;
			string weekOfYear = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();
			return int.Parse(weekOfYear);
		}

        public int weekOfTheYear(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            string weekOfYear = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();
            return int.Parse(weekOfYear);
        }

    }
}
