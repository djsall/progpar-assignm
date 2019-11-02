using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	public partial class Startup : Form {
		DB db = new DB();
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
		}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
			string genre = comboBox4.SelectedItem.ToString();
			comboBox5.DataSource = db.retrieveMoviesByGenres(genre);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}
