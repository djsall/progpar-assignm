using System;
using System.Collections.Generic;
using System.Text;

namespace Beadando {
	class DB {
		//visszaadja hogy benne van e az adatbázisban a felhasználó
		public bool containsUser(string username, string password){
			throw new NotImplementedException("nincs még adatbázis faszfej");
		}
		//megnézi a negyedik mezőt (3. index) a sorban, hogy igaz e.
		public bool isUserAdmin(string username){
			throw new NotImplementedException("nincs még adatbázis faszfej");

		}
		//igaz ha sikeres a beszúrás
		public bool insert(string s){
			throw new NotImplementedException("nincs még adatbázis faszfej");
		}
		//igaz ha sikeres a törlés
		public bool remove(string s){
			throw new NotImplementedException("nincs még adatbázis faszfej");
		}
		//lehet hogy nem lesz praktikus a külön insert és insert user ha rendes adatbázist használunk, nem fájlt.
		public bool insertNewUser(string username, string password, bool isAdmin){
			string data = string.Format("{0}\t{1}\t{2}\t{3}\n", username, password, DateTime.Now.ToString(), isAdmin.ToString());
			return insert(data);
		}
	}
}
