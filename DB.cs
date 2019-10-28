using System;
using System.Collections.Generic;
using System.Text;

namespace Beadando {
	class DB {
		public bool containsUser(string u, string p){
			throw new NotImplementedException("nincs még adatbázis faszfej");
			//visszaadja hogy benne van e az adatbázisban a felhasználó
		}
		public bool insert(string s){
			throw new NotImplementedException("nincs még adatbázis faszfej");
			//igaz ha sikeres a beszúrás
		}
		public bool remove(string s){
			throw new NotImplementedException("nincs még adatbázis faszfej");
			//igaz ha sikeres a törlés
		}
		public bool insertNewUser(string u, string p){
			//lehet hogy nem lesz praktikus a külön insert és insert user ha rendes adatbázist használunk, nem fájlt.
			string data = string.Format("{0}\t{1}\t{2}\n", u, p, DateTime.Now.ToString());
			return insert(data);
		}
	}
}
