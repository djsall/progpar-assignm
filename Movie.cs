using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Forms {
	struct movie {
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
	};
	class Movie {
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
