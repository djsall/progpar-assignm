using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Beadando_Forms {

	static internal class DB {
		private static SQLiteConnection connection;
		public const string DatabasePath = "dataBase.sqlite";

		static DB() {
			connection = new SQLiteConnection("Data Source=" + DatabasePath + "; version=3;");
			if (!File.Exists(DatabasePath)) {
				SQLiteConnection.CreateFile(DatabasePath);
				connection.Open();
				string[] createTablesCommand = {  "create table 'Varosok' ( 'Megye' VARCHAR, 'IrszVarKer' VARCHAR )",
																					"create table 'Mozi' ( 'ID' INTEGER PRIMARY KEY, 'Megye' VARCHAR, 'IrszVarKer' VARCHAR, 'Utca' VARCHAR, 'H_szam' VARCHAR, 'Nev' VARCHAR, 'Tulaj_Nev' VARCHAR, 'Datum' VARCHAR )",
																					"create table 'Tulaj' ( 'Felhasznalo' VARCHAR, 'Jelszo' VARCHAR )",
																					"create table 'Kapcsolat' ( 'Mozi_ID' INTEGER PRIMARY KEY, 'Filmek_Vetitesi_het' VARCHAR )",
																					"create table 'Vetitesek' ( 'Vetitesi_datum' VARCHAR, 'Vetitesi_ido' VARCHAR, 'F_cim' VARCHAR )",
																					"create table 'Filmek' ( 'F_Cim' VARCHAR, 'Mufaj' VARCHAR, 'Hossz' INTEGER, 'Korhatar' INTEGER, 'Vetitesi_het' INTEGER )",
																					"create table 'Foszereplo' ('Szineszek' VARCHAR, 'F_Cim' VARCHAR)",
																					"insert into 'Tulaj' ('Felhasznalo', 'Jelszo') values ('Zoli', 'jelszo')",
																					"insert into 'Mozi' ('ID', 'Megye', 'IrszVarKer', 'Utca', 'H_szam', 'Nev', 'Tulaj_Nev', 'Datum') values ('0', 'Bács-Kiskun', '6000 Kecskemét', 'Szent János', '11/a', 'Zoli mozija', 'Zoli', '"+DateTime.Now+"')"};

				foreach (string item in createTablesCommand) {
					SQLiteCommand prepDb = new SQLiteCommand(item, connection);
					prepDb.ExecuteNonQuery();
				}
				connection.Close();
			}
		}

		public static void createCinema(string county, string city, string street, string cinemaName, string maintainerName, string houseNumber, DateTime creationTime) {
			//mozit menti el, ha nem létezik még
			int count = 0;
			connection.Open();
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT NEV FROM 'Mozi' WHERE 'Mozi'.'Nev'='" + cinemaName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read()) count++;
			}

			if (count == 0) {
				string command = "insert into 'Mozi' ('Megye', 'IrszVarKer', 'Utca', 'H_szam', 'Nev', 'Tulaj_Nev', 'Datum') values ('" + county + "', '" + city + "','" + street + "', '" + houseNumber + "', '" + cinemaName + "', '" + maintainerName + "', '" + creationTime + "')";
				SQLiteCommand insert = new SQLiteCommand(command, connection);
				insert.ExecuteNonQuery();
			} else
				MessageBox.Show("Már létezik " + cinemaName + " nevű mozi az adatbázisban!");

			connection.Close();
		}
		public static bool selectUser(string username) {
			connection.Open();
			int count = 0;

			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT * FROM 'Tulaj' WHERE 'Tulaj'.'Felhasznalo'='" + username + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read()) count++;
			};

			if (count == 0) {
				connection.Close();
				return true;
			} else {
				connection.Close();
				return false;
			}
		}

		public static bool registerAdmin(string username, string password) {
			if (selectUser(username)) {
				connection.Open();

				string command = "insert into 'Tulaj' ('Felhasznalo', 'Jelszo') values ('" + username + "', '" + password + "')";
				SQLiteCommand insert = new SQLiteCommand(command, connection);
				insert.ExecuteNonQuery();

				connection.Close();

				return true;

			} else
				MessageBox.Show("Ez a név már foglalt.\nPróbáljon meg belépni, vagy vegye fel a kapcsolatot az adminisztrátorral.");
				return false;
		}

		public static bool Login(string username, string password) {
			//adatbázisból kihozza hogy van e password és username kombó ami megfelelő
			connection.Open();
			int count = 0;

			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT * FROM 'Tulaj' WHERE 'Tulaj'.'Felhasznalo'='" + username + "' AND 'Tulaj'.'Jelszo'='" + password + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read()) count++;
			};

			if (count == 1) {
				connection.Close();
				return true;
			} else {
				connection.Close();
				return false;
			}
		}

		public static void pushToDb(movie mt) {
			//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
			bool isRightWeek = true;
			if (isRightWeek) {
				Console.WriteLine(mt);
				//adatbázisba mehet
			} else
				MessageBox.Show("Nem a megfelelő hétre töltötte fel az adatokat.");
		}

		public static List<string> retrieveCinemaNamesByOwner(string ownerName) {
			List<string> result = new List<string>();
			result.Insert(0, ""); //ez a sor is kell, különben nem működik a gui, nehogy ki akard szedni

			connection.Open();
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT NEV FROM 'Mozi' WHERE 'Mozi'.'Tulaj_Nev'='" + ownerName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read())
					result.Add(Convert.ToString(r[0]));
			}
			connection.Close();
			return result;
		}

		public static List<string> retrieveCinemaNamesByLocation(string location) {
			//a helység alapján keresi meg az összes létező mozit abban a helységben, majd listába foglalja
			List<string> result = new List<string>();
			result.Insert(0, ""); // itt is szükséges a gui miatt a 0. indexen az üres sor

			connection.Open();
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT NEV FROM 'Mozi' WHERE 'Mozi'.'IrszVarKer'='" + location + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read())
					result.Add(Convert.ToString(r[0]));
			}
			connection.Close();
			return result;
		}

		public static List<string> retrieveMovieNamesByCinemaName(string cinemaName) {
			//filmcímeket pakol listába a mozi neve alapján a keresés az aktuális héten játszott filmekre
			//itt hagytam példának és tesztelésnek az alábbi listát
			List<string> result = new List<string>() { "Film címe, műfaja/műfajai, 2019-11-06, 13:35" };
			result.Insert(0, ""); // itt is szükséges a gui miatt a 0. indexen az üres sor

			return result;
		}

		public static List<string> retrieveMoviesByGenres(string genre) {
			//Movies-ban van egy genre lista, abból választ. Ez alapján ment az adatbázisba is a program.
			//A kiválaszott genre alapján kér egy listát a filmekről, a városról és a vetítés dátumáról és idejéről kombózva, ahogy a példán látható
			List<string> result = new List<string>() { "A Film címe, Debrecen, 2019-11-06, 13:35" };
			result.Insert(0, ""); // itt is szükséges a gui miatt a 0. indexen az üres sor

			result.Sort(); //kell, mert abc sorrendet kér a feladat
			return result;
		}

		public static movie searchForMovie(movie mov) {
			//minden megadott paraméterekből(genres, vetítési idő és dátum, kiválasztott mozi neve) összerak egy teljes movie struktúrát és azt adja vissza.
			movie result = new movie {
				title = mov.title,
				genres = mov.genres,
				ScreeningDate = mov.ScreeningDate,
				ScreeningTime = mov.ScreeningTime,
				selectedCinemaName = mov.selectedCinemaName,

				playtime = 120,
				ageRestriction = 14,
				starring = "Angelina NoLife",
				producer = "Cristopher Nolan"
			};

			return result;
		}

		public static movie searchForMovie2(movie mov, string location) {
			//megadott paraméterekből(cím, dátum, óra) és a vetítés helyszínéből visszaadja kiegészítve a movie struktúrát
			movie result = new movie {
				ScreeningDate = mov.ScreeningDate,
				ScreeningTime = mov.ScreeningTime,
				title = mov.title,

				genres = new string[] { "Akció", "Vígjáték " },
				ageRestriction = 14,
				playtime = 120,
				selectedCinemaName = "Homono Mozi és Bár",
				starring = "Nicholas Ketrec",
				producer = "Cristopher Nolan"
			};
			return result;
		}



		public static void saveMovies(int week, string[] movies, string selectedCinemaName) {
			MovieHandler mov = new MovieHandler();

			foreach (var item in movies) {
				string[] line = item.Split('\t');
				string[] genreProc = line[0].Split('/');

				movie mT = new movie {
					genres = new string[genreProc.Length],
					starring = line[1],
					producer = line[3],
					title = line[4],
					ScreeningDate = line[5],
					ScreeningTime = line[6],
					week = week,
					selectedCinemaName = selectedCinemaName
				};

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