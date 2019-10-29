using System;
using static System.Console;
namespace Beadando
{
	public class AdminLand
	{
		LoginHandler loginH = new LoginHandler();
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
		void showMenu()
		{
			WriteLine("Üdvözlöm az adminisztrációs kezelőfelületen!");
			int menuOption = 3;
			do
			{
				WriteLine("1 - Bejelentkezés");
				WriteLine("2 - Regisztráció");
				WriteLine("0 - Kilépés");
			} while (menuOption < 0 && menuOption > 2);
			switch (menuOption)
			{
				case 2:
					loginH.addAdministrator();
					createCinema();
					break;
				case 1:
					loginH.login();
					break;
				case 0:
					break;
				default:
					break; ;
			}
		}
		void createCinema()
		{
			Clear();
			WriteLine("Sikeres regisztráció!");
			WriteLine("Mozi létrehozása: ");
			Cinema testCinema = new Cinema();
		}
	}
}
