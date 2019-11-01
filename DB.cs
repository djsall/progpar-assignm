using System.Windows.Forms;

namespace Beadando_Forms {
	class DB {
		public void createAdmin(string county, string city, string street, string cinemaName, string maintainerName, int houseNumber){
			
		}
		public void pushToDb(int week, string genres, string starring, int playtime, string producer, string title, string ScreeningDate, string ScreeningTime, int ageRestriction){
		//DATABASE ENTRY-POINT
		//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
		}
		public void saveMovies(int week, string[] movies){
			foreach (var item in movies) {
				string[] line = item.Split('\t');
				string genres = line[0],
							 starring = line[1], 
							 producer = line[3], 
							 title = line[4], 
							 ScreeningDate = line[5], 
							 ScreeningTime = line[6];

				int playtime, ageRestriction;
				bool playtimeCheck = int.TryParse(line[2], out playtime),
						 ageRestrictionCheck = int.TryParse(line[7], out ageRestriction);
				if (playtimeCheck && ageRestrictionCheck) 
					pushToDb(week, genres, starring, playtime, producer, title, ScreeningDate, ScreeningTime, ageRestriction);
				else 
					MessageBox.Show("Számérték helyén más található a feldolgozandó fájlban. Kérem javítsa!");
			}
		}
	}
}
