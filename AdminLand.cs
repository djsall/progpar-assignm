using System;
using static System.Console;
namespace Beadando
{
	public class AdminLand
	{
		LoginHandler loginH = new LoginHandler();
		public AdminLand()
		{
			WriteLine("Üdvözlöm az adminisztrációs kezelőfelületen!");
			int menuOption = 3;
			do
			{
				WriteLine("1 - Bejelentkezés");
				WriteLine("2 - Regisztráció");
				WriteLine("0 - Kilépés");
			} while (menuOption < 0 && menuOption > 2);

		}
		void adminLogin()
		{
			bool result;
			do
			{
				result = loginH.login();
			} while (!result);
			Clear();
			WriteLine("Sikeres bejelentkezés!");
		}
	}
}
