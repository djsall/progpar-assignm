﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace Beadando_Forms {

	static internal class DB {
		private static LocationsHandler loc = new LocationsHandler();
		private static SQLiteConnection connection;
		public const string DatabasePath = "dataBase.sqlite";

		/// <summary>
		/// Populate the database with default entries if it doesn't exist yet.
		/// </summary>
		static DB() {
			connection = new SQLiteConnection("Data Source=" + DatabasePath + "; version=3;");
			if (!File.Exists(DatabasePath)) {
				SQLiteConnection.CreateFile(DatabasePath);
				connection.Open();

				string[] createTablesCommand = {
										"create table 'Mozi' ( 'ID' INTEGER PRIMARY KEY, 'Megye' VARCHAR, 'IrszVarKer' VARCHAR, 'Utca' VARCHAR, 'H_szam' VARCHAR, 'Nev' VARCHAR, 'Tulaj_Nev' VARCHAR, 'Letrehozasi_het' INT )",
										"create table 'Tulaj' ( 'Felhasznalo' VARCHAR, 'Jelszo' VARCHAR )",
										"create table 'Filmek' ( 'F_Cim' VARCHAR, 'Mufaj' VARCHAR, 'Hossz' INTEGER, 'Korhatar' INTEGER, 'Vetitesi_het' INTEGER, 'Mozi_ID' INTEGER, 'Vetitesi_Nap' VARCHAR, 'Vetitesi_Ido' VARCHAR, 'Rendezo' VARCHAR, 'Foszereplo' VARCHAR)",

										"insert into 'Tulaj' ('Felhasznalo', 'Jelszo') values ('Zoli', 'jelszo')",
										"insert into 'Mozi' ('ID', 'Megye', 'IrszVarKer', 'Utca', 'H_szam', 'Nev', 'Tulaj_Nev', 'Letrehozasi_het') values ('0', 'Bács-Kiskun', '6000 Kecskemét', 'Szent János', '11/a', 'Zoli mozija', 'Zoli', '" + loc.weekOfTheYear() + "')",
										"insert into 'Filmek' ('F_Cim', 'Mufaj', 'Hossz', 'Korhatar', 'Vetitesi_het', 'Mozi_ID', 'Vetitesi_Nap', 'Vetitesi_Ido', 'Rendezo', 'Foszereplo') values ('Suttogó', 'akció', '120', '12', '8', '0', '2020-08-20', '13:30', 'Nagy Zsiga', 'Brad Pitt')",
								};

				foreach (string item in createTablesCommand) {
					SQLiteCommand prepDb = new SQLiteCommand(item, connection);
					prepDb.ExecuteNonQuery();
				}

			} else
				connection.Open();
		}

		/// <summary>
		/// Creates a cinema based on the arguments. It checks if the name already exists.
		/// </summary>
		public static void createCinema(string county, string city, string street, string cinemaName, string maintainerName, string houseNumber, DateTime creationTime) {
			//mozit menti el, ha nem létezik még
			int count = 0;
			
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT NEV FROM 'Mozi' WHERE 'Mozi'.'Nev'='" + cinemaName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read()) count++;
			}

			LocationsHandler locH = new LocationsHandler();

			if (count == 0) {
				string command = "insert into 'Mozi' ('Megye', 'IrszVarKer', 'Utca', 'H_szam', 'Nev', 'Tulaj_Nev', 'Letrehozasi_het') values ('" + county + "', '" + city + "','" + street + "', '" + houseNumber + "', '" + cinemaName + "', '" + maintainerName + "', '" + locH.weekOfTheYear(creationTime) + "')";
				SQLiteCommand insert = new SQLiteCommand(command, connection);
				insert.ExecuteNonQuery();
			} else
				MessageBox.Show("Már létezik " + cinemaName + " nevű mozi az adatbázisban!");

			
		}

		/// <summary>
		/// Checks if an username is present in the database
		/// </summary>
		/// <returns>true if present, false if not present</returns>
		public static bool selectUser(string username) {
			
			int count = 0;

			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT * FROM 'Tulaj' WHERE 'Tulaj'.'Felhasznalo'='" + username + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read()) count++;
			};

			if (count == 0) {
				
				return true;
			} else {
				
				return false;
			}
		}

		/// <summary>
		/// Create an admin account. Checks if it already exists.
		/// </summary>
		/// <returns>True if success, false if not.</returns>
		public static bool registerAdmin(string username, string password) {
			if (selectUser(username)) {
				

				string command = "insert into 'Tulaj' ('Felhasznalo', 'Jelszo') values ('" + username + "', '" + password + "')";
				SQLiteCommand insert = new SQLiteCommand(command, connection);
				insert.ExecuteNonQuery();

				

				return true;
			} else
				MessageBox.Show("Ez a név már foglalt.\nPróbáljon meg belépni, vagy vegye fel a kapcsolatot az adminisztrátorral.");
			return false;
		}

		/// <summary>
		/// Returns true if the username and password combination is found in the database
		/// </summary>
		public static bool Login(string username, string password) {
			
			int count = 0;

			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT * FROM 'Tulaj' WHERE 'Tulaj'.'Felhasznalo'='" + username + "' AND 'Tulaj'.'Jelszo'='" + password + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read()) count++;
			};

			if (count == 1) {
				
				return true;
			} else {
				
				return false;
			}
		}

		/// <summary>
		/// Returns the names of cinema's owned by a specific person in a list format.
		/// </summary>
		public static List<string> retrieveCinemaNamesByOwner(string ownerName) {
			List<string> result = new List<string>();
			result.Insert(0, "");

			
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT NEV FROM 'Mozi' WHERE 'Mozi'.'Tulaj_Nev'='" + ownerName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read())
					result.Add(Convert.ToString(r[0]));
			}
			
			return result;
		}

		/// <summary>
		/// Returns the names of cinema's in a specific location (based on IrszVarKer's values) in a list format.
		/// </summary>
		public static List<string> retrieveCinemaNamesByLocation(string location) {
			List<string> result = new List<string>();
			result.Insert(0, "");

			
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT NEV FROM 'Mozi' WHERE 'Mozi'.'IrszVarKer'='" + location + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read())
					result.Add(Convert.ToString(r[0]));
			}
			
			return result;
		}

		/// <summary>
		/// Sends a movie struct into the database.
		/// </summary>
		public static void pushToDb(movie mt) {
			LocationsHandler loc = new LocationsHandler();

			int currWeek = loc.weekOfTheYear(),
							cinemaId = 0;

			bool isRightWeek = false;

			
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT 'Mozi'.'Letrehozasi_het' FROM 'Mozi' WHERE 'Mozi'.'Nev'='" + mt.selectedCinemaName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				if (r.Read()) {
					if (currWeek >= int.Parse(r.GetValue(0).ToString()))
						isRightWeek = true;
				} else MessageBox.Show("Anyukad");
			}
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT 'Mozi'.'ID' FROM 'Mozi' WHERE 'Mozi'.'Nev'='" + mt.selectedCinemaName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				if (r.Read())
					cinemaId = int.Parse(r.GetValue(0).ToString());
				else MessageBox.Show("anyukad2");
			}
			

			//ha a megfelelő hétbe jönnek az adatok, akkor mentsük el az adatbázisba az adatokat
			if (isRightWeek) {
				
				string commandString = "insert into 'Filmek' ('F_Cim', 'Mufaj', 'Hossz', 'Korhatar', 'Vetitesi_het', 'Mozi_ID', 'Vetitesi_Nap', 'Vetitesi_Ido', 'Rendezo', 'Foszereplo') values ('" + mt.title + "', '" + mt.genres + "', '" + mt.playtime + "', '" + mt.ageRestriction + "', '" + currWeek + "', '" + cinemaId + "', '" + mt.ScreeningDate + "', '" + mt.ScreeningTime + "', '" + mt.producer + "', '" + mt.starring + "')";
				SQLiteCommand command = new SQLiteCommand(commandString, connection);
				command.ExecuteNonQuery();

				
				MessageBox.Show("Sikeres feltöltés!");
			} else
				MessageBox.Show("Nem a megfelelő hétre töltötte fel az adatokat.");
		}

		/// <summary>
		/// Returns a list of movies played at a specific cinema
		/// </summary>
		public static List<string> retrieveMovieNamesByCinemaName(string cinemaName) {
			List<string> result = new List<string>();

			
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT F_Cim, Mufaj, Vetitesi_Nap, Vetitesi_Ido FROM 'Filmek' INNER JOIN 'Mozi' ON 'Filmek'.'Mozi_ID'='Mozi'.'ID' WHERE 'Mozi'.'Nev'='" + cinemaName + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read())
					result.Add(r[0].ToString() + ", " + r[1].ToString() + ", " + r[2].ToString() + ", " + r[3].ToString());
			}
			

			result.Insert(0, "");

			return result;
		}

		/// <summary>
		/// Returns a list of movies based on a given genre.
		/// </summary>
		public static List<string> retrieveMoviesByGenres(string genre) {
			List<string> result = new List<string>();

			
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT F_Cim, IrszVarKer, Vetitesi_Nap, Vetitesi_Ido FROM 'Filmek' INNER JOIN 'Mozi' ON 'Filmek'.'Mozi_ID'='Mozi'.'ID' WHERE 'Filmek'.'Mufaj'='" + genre + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();
				while (r.Read())
					result.Add(r[0].ToString() + ", " + r[1].ToString() + ", " + r[2].ToString() + ", " + r[3].ToString());
			}
			

			result.Insert(0, "");
			result.Sort();
			return result;
		}

		/// <summary>
		/// Fetches movie data based given data
		/// </summary>
		/// <returns>Movie struct</returns>
		public static movie searchForMovie(movie mov) {
			

			movie result = new movie {
				title = mov.title,
				genres = mov.genres,
				ScreeningDate = mov.ScreeningDate,
				ScreeningTime = mov.ScreeningTime,
				selectedCinemaName = mov.selectedCinemaName
			};
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT Hossz, Korhatar, Foszereplo, Rendezo FROM 'Filmek' "+
														  "INNER JOIN 'Mozi' ON 'Mozi'.'ID' = 'Filmek'.'Mozi_ID'"+
															"WHERE 'Filmek'.'F_Cim' = '" + mov.title + "'"+
															"AND 'Mozi'.'Nev' = '" + mov.selectedCinemaName + "'"+
															"AND 'Filmek'.'Vetitesi_nap' = '" + mov.ScreeningDate + "'"+
															"AND 'Filmek'.'Vetitesi_ido' = '" + mov.ScreeningTime + "'";

				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();

				if (r.Read()) {
					result.playtime = int.Parse(r[0].ToString());
					result.ageRestriction = int.Parse(r[1].ToString());
					result.starring = r[2].ToString();
					result.producer = r[3].ToString();
				} else
					result = default;
			}
			
			return result;
		}

		/// <summary>
		/// Fetches movie data based given data
		/// </summary>
		/// <returns>Movie struct</returns>
		public static movie searchForMovie2(movie mov, string location) {
			
			movie result = new movie {
				ScreeningDate = mov.ScreeningDate,
				ScreeningTime = mov.ScreeningTime,
				title = mov.title,
			};
			using (SQLiteCommand command = connection.CreateCommand()) {
				command.CommandText = "SELECT Mufaj, Korhatar, Hossz, Nev, Foszereplo, Rendezo FROM 'Filmek' INNER JOIN 'Mozi' ON 'Mozi'.'ID'='Filmek'.'Mozi_ID' WHERE 'Filmek'.'F_Cim'='" + mov.title + "' AND 'Filmek'.'Vetitesi_Nap'='" + mov.ScreeningDate + "' AND 'Mozi'.'IrszVarKer'='" + location + "'";
				command.CommandType = CommandType.Text;
				SQLiteDataReader r = command.ExecuteReader();

				if (r.Read()) {
					result.genres = r[0].ToString();
					result.ageRestriction = int.Parse(r[1].ToString());
					result.playtime = int.Parse(r[2].ToString());
					result.selectedCinemaName = r[3].ToString();
					result.starring = r[4].ToString();
					result.producer = r[5].ToString();
				} else
					result = default;
			}
			
			return result;
		}

		/// <summary>
		/// Splits up movies for saving to database
		/// </summary>
		public static void saveMovies(int week, string[] movies, string selectedCinemaName) {
			MovieHandler mov = new MovieHandler();

			foreach (var item in movies) {
				string[] line = item.Split('\t');

				movie mT = new movie {
					genres = line[0],
					starring = line[1],
					producer = line[3],
					title = line[4],
					ScreeningDate = line[5],
					ScreeningTime = line[6],
					week = week,
					selectedCinemaName = selectedCinemaName
				};

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