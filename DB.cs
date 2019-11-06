using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data.Sql;
using System.Data;
using System.IO;

namespace Beadando_Forms {
	static internal class DB {
		static SQLiteConnection connection;
		public const string DatabasePath = "data.db";

		static DB() {
			//if (!File.Exists(DatabasePath)) {
				SQLiteConnection.CreateFile(DatabasePath);
				connection = new SQLiteConnection("Data Source=" + DatabasePath, true);
				connection.Open();
				string[] createTablesCommand = { "create table 'Mozik'.'Varosok' ( 'Megye' VARCHAR, 'IrszVarKer' VARCHAR )",
																			 	 "create table 'Mozik'.'Mozi' ( 'ID' INTEGER PRIMARY KEY, 'IrszVarKer' VARCHAR, 'Utca' VARCHAR, 'H_szam' VARCHAR )",
																				 "create table 'Mozik'.'Tulaj' ( 'Felhasznalo' VARCHAR, 'Jelszo' VARCHAR )",
																				 "create table 'Mozik'.'Kapcsolat' ( 'Mozi_ID' INTEGER PRIMARY KEY, 'Filmek_Vetitesi_het' VARCHAR, 'Tulaj_Felhasznalo' VARCHAR )",
																				 "create table 'Mozik'.'Vetitesek' ( 'Vetitesi_datum' VARCHAR, 'Vetitesi_ido' VARCHAR, 'F_cim' VARCHAR )",
																				 "create table 'Mozik'.'Filmek' ( 'F_Cim' VARCHAR', 'Mufaj' VARCHAR, 'Hossz' INTEGER, 'Korhatar' INTEGER, 'Vetitesi_het' INTEGER )",
																				 "create table 'Mozik'.'Foszereplo' ('Szineszek' VARCHAR, 'F_Cim' VARCHAR)"};

				foreach (string item in createTablesCommand) {
					SQLiteCommand prepDb = new SQLiteCommand(item, connection);
					prepDb.ExecuteNonQuery();
				}																 
				//Console.WriteLine(connection.FileName);
			//return;
		//}
		//connection = new SQLiteConnection("Data Source=" + DatabasePath, true);
		//connection.Open();
		//Console.WriteLine(connection.FileName);
		}

		public static void createCinema(string county, string city, string street, string cinemaName, string maintainerName, string houseNumber, DateTime creationTime) {
			//mozit menti el, ha nem létezik még
			bool existsAlready = false; //ennek figyelembe kéne vennie a címet és a mozi nevét is

			//SQLiteCommand command = new SQLiteCommand(connection);

			if (!existsAlready) {
				//mehet az adatbázisba
			} else
				MessageBox.Show("Már létezik ez a mozi az adatbázisban!");
		}

		public static bool Login(string username, string password) {
			//adatbázisból kihozza hogy van e password és username kombó ami megfelelő
			bool success = false;

			if (username == "Zoli") success = true; // tesztelni van

			if (success)
				return true;
			else
				return false;
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

		public static bool selectUser(string username) {
			//megnézi hogy van e az adatbázisban ilyen felhasználónév
			return false;
		}

		public static List<string> retrieveCinemaNamesByOwner(string ownerName) {
			//a tulajdonos nevét veszi át, majd megkeresi a hozzá tartozó mozikat
			List<string> zoliMozijai = new List<string>() { "Zoli mozija", "Maci mozi" };
			zoliMozijai.Insert(0, "");

			return zoliMozijai;

			/*List<string> result = new List<string>();
			*result.Insert(0, ""); //ez a sor is kell, különben nem működik a gui, nehogy ki akard szedni
			return result;*/
		}
		public static List<string> retrieveCinemaNamesByLocation(string location) {
			//a helység alapján keresi meg az összes létező mozit abban a helységben, majd listába foglalja
			//a location string minden esetben az irszVarKer.txt fájlból fog származni és a többi adatbázisba beszúrás is, szóval mindig lesz egyezés ha van megfelelő elem
			List<string> zoliMozijai = new List<string>() { "Zoli mozija", "Maci mozi" };
			zoliMozijai.Insert(0, ""); // itt is szükséges a gui miatt a 0. indexen az üres sor
			return zoliMozijai;
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

		public static bool registerAdmin(string username, string password) {
			if (selectUser(username)) {
				MessageBox.Show("Ez a név már foglalt.\nPróbáljon meg belépni, vagy vegye fel a kapcsolatot az adminisztrátorral.");
				return false;
			} else
				return true;
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