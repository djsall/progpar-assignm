using System;
using System.Windows.Forms;

namespace Beadando_Forms {

	public partial class Startup : Form {
		private DB db = new DB();

		public Startup() {
			InitializeComponent();

			LocationsHandler locations = new LocationsHandler();
			MovieHandler movie = new MovieHandler();

			comboBox2.DataSource = locations.cities;
			comboBox4.DataSource = movie.movieTypes;
		}

		private void Form1_Load(object sender, EventArgs e) {
		}

		private void button1_Click(object sender, EventArgs e) {
			CreateCinema create = new CreateCinema();
			this.Hide();
			create.Show();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) {
			string selectedLocation = comboBox2.SelectedItem.ToString();
			comboBox3.DataSource = db.retrieveCinemaNamesByLocation(selectedLocation);
		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			string cinemaName = comboBox2.SelectedItem.ToString();
			comboBox1.DataSource = db.retrieveMovieNamesByLocationAndCinemaName(cinemaName);
			comboBox1.Enabled = false;
			if (comboBox3.Text != "")
				comboBox1.Enabled = true;
			if (comboBox3.Text != "") {
				comboBox5.Enabled = false;
				comboBox4.Enabled = false;
			} else {
				comboBox5.Enabled = true;
				comboBox4.Enabled = true;
			}
		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
			string genre = comboBox4.SelectedItem.ToString();
			comboBox5.DataSource = db.retrieveMoviesByGenres(genre);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			textBox1.ReadOnly = true;

			if (comboBox1.Text != "" && comboBox3.Text != "") {
				//Film címe, műfaja, 2019-11-06, 13:35

				string[] searchValues = comboBox1.Text.Replace(", ", ",").Split(',');

				movie mov = new movie {
					title = searchValues[0],
					genres = searchValues[1].Split('/'),
					ScreeningDate = searchValues[2],
					ScreeningTime = searchValues[3],
					selectedCinemaName = comboBox3.Text
				};

				movie result = db.searchForMovie(mov);

				textBox1.Text = result.ToString();
			}
		}

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) {
			//A Film címe, Debrecen, 2019-11-06, 13:35
			if (comboBox4.Text != "" && comboBox5.Text != "") {
				comboBox3.Enabled = false;
				string[] searchValues = comboBox5.Text.Replace(", ", ",").Split(',');

				movie mov = new movie {
					title = searchValues[0],
					ScreeningDate = searchValues[2],
					ScreeningTime = searchValues[3]
				};
				movie result = db.searchForMovie2(mov, searchValues[1]);
				textBox1.Text = result.ToString();
			} else
				comboBox3.Enabled = true;
		}
	}
}