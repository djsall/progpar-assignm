using System;

namespace Beadando {
	class DB {
		//igaz ha az adatbázisban van ilyen felhasználó
		public bool containsUser(string username, string password){
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
			string data = string.Format("{0}\t{1}\t{2}\n", username, password, isAdmin.ToString());
			return insert(data);
		}
	}
}
