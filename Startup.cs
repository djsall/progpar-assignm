using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	public partial class Startup : Form {
		
      public Startup() {
			InitializeComponent();

			LocationsHandler locations = new LocationsHandler();
			MovieHandler movie = new MovieHandler();

			CityDropDown.DataSource = locations.cities;
			GenreDropDown.DataSource = movie.movieTypes;
		}

		private void AdminButton_Click(object sender, EventArgs e) {
			CreateCinema create = new CreateCinema();
			this.Hide();
			create.Show();
		}

		private void CityDropDown_SelectedIndexChanged(object sender, EventArgs e) {
			string selectedLocation = CityDropDown.Text;
			CinemaDropDown.DataSource = DB.retrieveCinemaNamesByLocation(selectedLocation);
		}


		private void CinemaDropDown_SelectedIndexChanged(object sender, EventArgs e) {
			string cinemaName = CityDropDown.Text;
			MovieDropDown.DataSource = DB.retrieveMovieNamesByCinemaName(cinemaName);
			MovieDropDown.Enabled = false;
			if (CinemaDropDown.Text != "")
				MovieDropDown.Enabled = true;
			if (CinemaDropDown.Text != "") {
				MovieInfoDropDown.Enabled = false;
				GenreDropDown.Enabled = false;
			} else {
				MovieInfoDropDown.Enabled = true;
				GenreDropDown.Enabled = true;
			}
		}

		private void GenreDropDown_SelectedIndexChanged(object sender, EventArgs e) {
			string genre = GenreDropDown.SelectedItem.ToString();
			MovieInfoDropDown.DataSource = DB.retrieveMoviesByGenres(genre);
		}

		private void MovieDropDown_SelectedIndexChanged(object sender, EventArgs e) {
			MovieDetailsBox.ReadOnly = true;

			if (MovieDropDown.Text != "" && CinemaDropDown.Text != "") {
				//Film címe, műfaja, 2019-11-06, 13:35

				string[] searchValues = MovieDropDown.Text.Replace(", ", ",").Split(',');

				movie mov = new movie {
					title = searchValues[0],
					genres = searchValues[1].Split('/'),
					ScreeningDate = searchValues[2],
					ScreeningTime = searchValues[3],
					selectedCinemaName = CinemaDropDown.Text
				};

				movie result = DB.searchForMovie(mov);

				MovieDetailsBox.Text = result.ToString();
			}
		}

		private void MovieInfoDropDown_SelectedIndexChanged(object sender, EventArgs e) {
			//A Film címe, Debrecen, 2019-11-06, 13:35
			if (GenreDropDown.Text != "" && MovieInfoDropDown.Text != "") {
				CinemaDropDown.Enabled = false;
				string[] searchValues = MovieInfoDropDown.Text.Replace(", ", ",").Split(',');

				movie mov = new movie {
					title = searchValues[0],
					ScreeningDate = searchValues[2],
					ScreeningTime = searchValues[3]
				};
				movie result = DB.searchForMovie2(mov, searchValues[1]);
				MovieDetailsBox.Text = result.ToString();
			} else
				CinemaDropDown.Enabled = true;
		}
	}
}