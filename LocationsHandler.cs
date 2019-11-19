using System;
using System.Collections.Generic;
using System.Globalization;

namespace Beadando_Forms {

	internal class LocationsHandler {

		public List<string> counties = new List<string>() { "Bács-Kiskun", "Baranya", "Békés", "Borsod-Abaúj-Zemplén", "Csongrád",
						"Fejér", "Győr-Moson-Sopron", "Hajdú-Bihar", "Heves", "Jász-Nagykun-Szolnok", "Komárom-Esztergom", "Nógrád", "Pest",
						"Somogy", "Szabolcs-Szatmár-Bereg", "Tolna", "Vas", "Veszprém", "Zala" };

		public List<string> cities = new List<string>(Properties.Resources.Address_List.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries));
		/// <summary>
		/// Returns the current week of the year as an integer.
		/// </summary>
		public int weekOfTheYear() {
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
			Calendar cal = dfi.Calendar;
			string weekOfYear = cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();
			return int.Parse(weekOfYear);
		}
		/// <summary>
		/// Returns the number of the week from the DateTime input.
		/// </summary>
		public int weekOfTheYear(DateTime date) {
			DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
			Calendar cal = dfi.Calendar;
			string weekOfYear = cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek).ToString();
			return int.Parse(weekOfYear);
		}
	}
}