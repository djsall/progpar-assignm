using static System.Console;
using System.Text.RegularExpressions;
namespace Beadando {
	class Administrator {
		DB db = new DB();
		public void addAdministrator() {
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
			db.insertNewUser(username, password);
		}
		//azért bool, hogy ha sikeres a bejelentkezés, onnantól adminland-ba dobhassuk egyből, ne kelljen minden lépéshez újra bejelentkezni
		//majd implementálja az aki nem szenved alváshiányban jelenleg
		public bool login(){
			string username, password;
			do {
				WriteLine("Adja meg a felhasználónevét! ");
				username = ReadLine();
				WriteLine("Adja meg a jelszavát! ");
				password = ReadLine();
			} while (!isAlphaNum(username) && !db.containsUser(username, password));
			WriteLine("Sikeres bejelentkezés!");
			return true;
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
