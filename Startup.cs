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
			comboBox1.Enabled = false;
			if (comboBox3.Text != "") 
				comboBox1.Enabled = true;
			}

		private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) {
			string genre = comboBox4.SelectedItem.ToString();
			comboBox5.DataSource = db.retrieveMoviesByGenres(genre);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
			textBox1.ReadOnly = true;

			if(comboBox1.Text != "" && comboBox3.Text != ""){
				//Film címe, műfaja, 2019-11-06, 13:35
				string[] searchValues = comboBox1.Text.Split(',');

				for(int i = 0; i < searchValues.Length; i++)
					searchValues[i] = searchValues[i].Replace(" ", "");

				movie mov = new movie();

				mov.title = searchValues[0];
				mov.genres = searchValues[1].Split('/');
				mov.ScreeningDate = searchValues[2];
				mov.ScreeningTime = searchValues[3];
				mov.selectedCinemaName = comboBox3.Text;

				movie result = db.searchForMovie(mov);

				textBox1.Text = result.ToString();
			}
		}

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e) {
			//A Film címe, Debrecen, 2019-11-06, 13:35
		}
	}
}
