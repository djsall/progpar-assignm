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

		public void pushToDb(string selectedCinemaName, int week, string genres, string starring, int playtime, string producer, string title, string ScreeningDate, string ScreeningTime, int ageRestriction) {
			//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
			bool isRightWeek = true;
			if (isRightWeek) {
				Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}", selectedCinemaName, week, genres, starring, playtime, producer, title, ScreeningDate, ScreeningTime, ageRestriction);
				//adatbázisba mehet
			} else
				MessageBox.Show("Nem a megfelelő hétre töltötte fel az adatokat.");
		}

		public bool selectUser(string username) {
			//megnézi hogy van e az adatbázisban ilyen felhasználónév
			return false;
		}

		public List<string> retrieveCinemaNames(string ownerName) {
			//a tulajdonos nevét veszi át, majd megkeresi a hozzá tartozó mozikat
			List<string> zoliMozijai = new List<string>() { "Zoli mozija", "Forró naci mozi" };
			zoliMozijai.Insert(0, "");

			return zoliMozijai;

			/*List<string> results = new List<string>();
			*results.Insert(0, ""); //ez a sor is kell, különben nem működik a gui, nehogy ki akard szedni
			return results;*/
		}

		public bool registerAdmin(string username, string password) {
			if (selectUser(username)) {
				MessageBox.Show("Ez a név már foglalt.\nPróbáljon meg belépni, vagy vegye fel a kapcsolatot az adminisztrátorral.");
				return false;
			} else
				return true;
		}

		public void saveMovies(int week, string[] movies, string selectedCinemaName) {
			Movie mov = new Movie();
			foreach (var item in movies) {
				string[] line = item.Split('\t');

				movie mT = new movie();

				mT.genres = "";
				mT.starring = line[1];
				mT.producer = line[3];
				mT.title = line[4];
				mT.ScreeningDate = line[5];
				mT.ScreeningTime = line[6];
				mT.week = week;
				mT.selectedCinemaName = selectedCinemaName;

				string[] genreProc = line[0].Split(',');

				foreach (var currGenre in genreProc) 
					if (mov.movieTypes.Contains(line[0].ToLower()))
						mT.genres += currGenre;
						
				bool playtimeCheck = int.TryParse(line[2], out mT.playtime),
						 ageRestrictionCheck = int.TryParse(line[7], out mT.ageRestriction);

				if (playtimeCheck && ageRestrictionCheck)
					pushToDb(mT.selectedCinemaName, mT.week, mT.genres, mT.starring, mT.playtime, mT.producer, mT.title, mT.ScreeningDate, mT.ScreeningTime, mT.ageRestriction);
				else
					MessageBox.Show("Számérték helyén más található a feldolgozandó fájlban. Kérem javítsa!");
			}
		}
	}
}