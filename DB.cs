using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Beadando_Forms {
	class DB {
		public void createCinema(string county, string city, string street, string cinemaName, string maintainerName, int houseNumber, DateTime creationTime){
			
		}
		public void pushToDb(string selectedCinemaName, int week, string genres, string starring, int playtime, string producer, string title, string ScreeningDate, string ScreeningTime, int ageRestriction){
		//DATABASE ENTRY-POINT
		//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
		}
		public List<string> retrieveCinemaNames(string ownerName){
			//a tulajdonos nevét veszi át, majd megkeresi a hozzá tartozó mozikat
			List<string> zoliMozijai = new List<string>() { "Zsoli mozija", "Forró naci mozi" };
			return zoliMozijai;
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
