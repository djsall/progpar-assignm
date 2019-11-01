using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Beadando_Forms {
	class DB {
		public void createCinema(string county, string city, string street, string cinemaName, string maintainerName, string houseNumber, DateTime creationTime){
			//mozit menti el, ha nem létezik még
			bool existsAlready = false; //ennek figyelembe kéne vennie a címet és a mozi nevét is
			if (!existsAlready) {
				//mehet az adatbázisba
			} else
				MessageBox.Show("Már létezik ez a mozi az adatbázisban!");
		}
		public bool Login(string username, string password){
			//adatbázisból kiszopkodja hogy van e password és username kombó ami megfelelő
			bool success = false;

			if (username == "Zoli") success = true; // tesztelni van

			if (success)
				return true;
			else
				return false;
		}
		public void pushToDb(string selectedCinemaName, int week, string genres, string starring, int playtime, string producer, string title, string ScreeningDate, string ScreeningTime, int ageRestriction){
			//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
			bool isRightWeek = true;
			if (isRightWeek) {
				//adatbázisba mehet
			} else
				MessageBox.Show("Nem a megfelelő hétre töltötte fel az adatokat.");
		}
		public bool selectUser(string username){
			//megnézi hogy van e az adatbázisban ilyen felhasználónév
			return false;
		}
		public List<string> retrieveCinemaNames(string ownerName){
			//a tulajdonos nevét veszi át, majd megkeresi a hozzá tartozó mozikat
			List<string> zoliMozijai = new List<string>() { "Zoli mozija", "Forró naci mozi" };
			zoliMozijai.Insert(0,"");

			return zoliMozijai;

			/*List<string> results = new List<string>(); 
			*results.Insert(0, ""); ez a sor is kell, különben nem működik a gui, nehogy ki akard szedni
			return results;*/
		}
		public bool registerAdmin(string username, string password){
			if (selectUser(username)) {
				MessageBox.Show("Ez a név már foglalt.\nPróbáljon meg belépni, vagy vegye fel a kapcsolatot az adminisztrátorral.");
				return false;
			} else
				return true;
		}
		public void saveMovies(int week, string[] movies, string selectedCinemaName){
			foreach (var item in movies) {

				string[] line = item.Split('\t');

				string genres = line[0],
							 starring = line[1], 
							 producer = line[3], 
							 title = line[4], 
							 ScreeningDate = line[5], 
							 ScreeningTime = line[6];

				bool playtimeCheck = int.TryParse(line[2], out int playtime),
						 ageRestrictionCheck = int.TryParse(line[7], out int ageRestriction);

				if (playtimeCheck && ageRestrictionCheck) 
					pushToDb(selectedCinemaName, week, genres, starring, playtime, producer, title, ScreeningDate, ScreeningTime, ageRestriction);
				else 
					MessageBox.Show("Számérték helyén más található a feldolgozandó fájlban. Kérem javítsa!");
			}
		}
	}
}
