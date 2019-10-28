using static System.Console;
namespace Beadando {
	class LoginHandler {
		DB db = new DB();
		public void addAdministrator() {
			string[] result = registration();
			db.insertNewUser(result[0], result[1], true);
		}
		public void addUser(){
			string[] result = registration();
			db.insertNewUser(result[0], result[1], false);
		}
		//sikeres bejelentkezés, vagy nem, majd eldönti
		public bool login(){
			bool isAdmin;
			string username, password;
			do {
				WriteLine("Adja meg a felhasználónevét! ");
				username = ReadLine();
				WriteLine("Adja meg a jelszavát! ");
				password = ReadLine();
			} while (!isAlphaNum(username) && !db.containsUser(username, password, out isAdmin));
			WriteLine("Sikeres bejelentkezés!");
			return true;
		}
		public string[] registration(){
			string username, password, passwordVerify;
			do {
				WriteLine("Adja meg a regisztrálni kívánt felhasználónevet! ");
				username = ReadLine();
			} while (!isAlphaNum(username));
			do {
				WriteLine("Adja meg a fiókhoz társítani kívánt jelszót! ");
				password = ReadLine();
			} while (!isAlphaNum(password));
			do {
				WriteLine("Erősítse meg a társítani kíánt jelszót! ");
				passwordVerify = ReadLine();
			} while (!isAlphaNum(passwordVerify) && password != passwordVerify);
			string[] result = new string[2];
			result[0] = username;
			result[1] = password;
			return result;
		}
		bool isAlphaNum(string s){
			if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
				return false;
			for (int i = 0; i < s.Length; i++) {
				if (!(char.IsLetterOrDigit(s[i])))
					return false;
			}
			return true;
		}
	}
}
