using System.Threading;
namespace Beadando
{
	class Cinema
	{
		string maintainerName, cinemaName, countyName, cityNameAndDistrict, streetName;
		int houseNumber;
		public Cinema(string maintainerName, string cinemaName, string countyName, string cityNameAndDistrict, string streetName, int houseNumber)
		{
			this.maintainerName = maintainerName;
			this.cinemaName = cinemaName;
			this.countyName = countyName;
			this.cityNameAndDistrict = cityNameAndDistrict;
			this.streetName = streetName;
			this.houseNumber = houseNumber;
		}
	}
}
