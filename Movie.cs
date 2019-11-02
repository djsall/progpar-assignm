using System.Collections.Generic;

namespace Beadando_Forms {

	internal struct movie{ 
		public string[] genres;

		public string starring,
									producer,
									title,
									ScreeningDate,
									ScreeningTime,
									selectedCinemaName;

		public int playtime,
							 ageRestriction,
							 week;

		public override string ToString() {
			string output = "";
			output += genres[0];

			for (int i = 0; i < genres.Length; i++) 
				if (0 < i && i < genres.Length) output += "/"+genres[i];

			output += ", Főszereplő(k): "+starring + ", Rendező: " + producer + ", Cím: " + title + ", Vetítés: " + ScreeningDate + " " + ScreeningTime + " - A " + selectedCinemaName + " moziban, Játékidő:" + playtime + " prec, Korhatár: " + ageRestriction + " éves kor";

			return output;
		}
	};

	internal class MovieHandler {

		public List<string> movieTypes = new List<string>() {
		"akció",
		"animáció",
		"bűnügyi",
		"családi",
		"dokumentum",
		"életrajz",
		"fantasy",
		"dráma",
		"vígjáték",
		"háborús",
		"horror",
		"kaland",
		"katasztrófa",
		"kém",
		"misztikus",
		"politikai",
		"romantikus",
		"rövid",
		"sci-fi",
		"thriller",
		"történelmi",
		"western"
		};
	}
}