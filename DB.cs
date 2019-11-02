using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Beadando_Forms {

	internal class DB {

		public void createCinema(string county, string city, string street, string cinemaName, string maintainerName, string houseNumber, DateTime creationTime) {
			//mozit menti el, ha nem létezik még
			bool existsAlready = false; //ennek figyelembe kéne vennie a címet és a mozi nevét is
			if (!existsAlready) {
				//mehet az adatbázisba
			} else
				MessageBox.Show("Már létezik ez a mozi az adatbázisban!");
		}

		public bool Login(string username, string password) {
			//adatbázisból kiszopkodja hogy van e password és username kombó ami megfelelő
			bool success = false;

			if (username == "Zoli") success = true; // tesztelni van

			if (success)
				return true;
			else
				return false;
		}

		public void pushToDb(movie mt) {
			//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
			bool isRightWeek = true;
			if (isRightWeek) {
				Console.WriteLine(mt);
				//adatbázisba mehet
			} else
				MessageBox.Show("Nem a megfelelő hétre töltötte fel az adatokat.");
		}

		public bool selectUser(string username) {
			//megnézi hogy van e az adatbázisban ilyen felhasználónév
			return false;
		}

		public List<string> retrieveCinemaNamesByOwner(string ownerName) {
			//a tulajdonos nevét veszi át, majd megkeresi a hozzá tartozó mozikat
			List<string> zoliMozijai = new List<string>() { "Zoli mozija", "Forró naci mozi" };
			zoliMozijai.Insert(0, "");

			return zoliMozijai;

			/*List<string> results = new List<string>();
			*results.Insert(0, ""); //ez a sor is kell, különben nem működik a gui, nehogy ki akard szedni
			return results;*/
		}
		public List<string> retrieveCinemaNamesByLocation(string location) {
			//a helység alapján keresi meg az összes létező mozit abban a helységben, majd listába foglalja
			//a location string minden esetben az irszVarKer.txt fájlból fog származni
			List<string> zoliMozijai = new List<string>() { "", "Zoli mozija", "Forró naci mozi" };
			return zoliMozijai;
		}
		public List<string> retrieveMovieNamesByLocationAndCinemaName(string cinemaName){
		//filmcímeket pakol listába a mozi neve alapján a keresés az aktuális héten játszott filmekre
		//itt hagytam példának és tesztelésnek az alábbi listát
			List<string> movies = new List<string>() { "", "Film címe, műfaja/műfajai, 2019-11-06, 13:35" };
			return movies;
		}
		public List<string> retrieveMoviesByGenres(string genre){
			//Movies-ban van egy genre lista, abból választ. Ez alapján ment az adatbázisba is a program. 
			//A kiválaszott genre alapján kér egy listát a filmekről, a városról és a vetítés dátumáról és idejéről kombózva, ahogy a példán látható
			List<string> result = new List<string>() { "", "A Film címe, Debrecen, 2019-11-06, 13:35" };


			result.Sort(); //kell, mert abc sorrendet kér a feladat
			return result;
		}
		public movie searchForMovie(movie mov){
			//minden megadott paraméterekből(genres, vetítési idő és dátum, kiválasztott mozi neve) összerak egy teljes movie struktúrát és azt adja vissza.
			movie result = new movie {
				title = mov.title,
				genres = mov.genres,
				ScreeningDate = mov.ScreeningDate,
				ScreeningTime = mov.ScreeningTime,
				selectedCinemaName = mov.selectedCinemaName,

				playtime = 120,
				ageRestriction = 14,
				starring = "Angelina Fuckface",
				producer = "Cristopher Nolan"
			};

			return result;
		}
		public movie searchForMovie2(movie mov, string location){
			//megadott paraméterekből(cím, dátum, óra) és a vetítés helyszínéből visszaadja kiegészítve a movie struktúrát
			movie result = new movie {
				ScreeningDate = mov.ScreeningDate,
				ScreeningTime = mov.ScreeningTime,
				title = mov.title,

				genres = new string[] { "Akció", "Vígjáték "},
				ageRestriction = 14,
				playtime = 120,
				selectedCinemaName = "Melegbár",
				starring = "Nicholas Ketrec",
				producer = "Cristopher Nolan"
			};
			return result;
		}

		public bool registerAdmin(string username, string password) {
			if (selectUser(username)) {
				MessageBox.Show("Ez a név már foglalt.\nPróbáljon meg belépni, vagy vegye fel a kapcsolatot az adminisztrátorral.");
				return false;
			} else
				return true;
		}

		public void saveMovies(int week, string[] movies, string selectedCinemaName) {
			MovieHandler mov = new MovieHandler();
			movie mT  = new movie();
			
			foreach (var item in movies) {

				string[] line = item.Split('\t');
				string[] genreProc = line[0].Split('/');
				mT.genres = new string[genreProc.Length];
				mT.starring = line[1];
				mT.producer = line[3];
				mT.title = line[4];
				mT.ScreeningDate = line[5];
				mT.ScreeningTime = line[6];
				mT.week = week;
				mT.selectedCinemaName = selectedCinemaName;

				for (int i = 0; i < genreProc.Length; i++) 
					if (mov.movieTypes.Contains(genreProc[i].ToLower()))
						mT.genres[i] = genreProc[i];
										
				bool playtimeCheck = int.TryParse(line[2], out mT.playtime),
						 ageRestrictionCheck = int.TryParse(line[7], out mT.ageRestriction);

				if (playtimeCheck && ageRestrictionCheck)
					pushToDb(mT);
				else
					MessageBox.Show("Számérték helyén más található a feldolgozandó fájlban. Kérem javítsa!");
			}
		}
	}
}