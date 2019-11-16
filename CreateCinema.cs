using System;
using System.Windows.Forms;
using System.IO;

namespace Beadando_Forms {
	public partial class CreateCinema : Form {
		string username = "";
		public CreateCinema() {
			InitializeComponent();

			LocationsHandler locations = new LocationsHandler();

			CountyDropDown.DataSource = locations.counties;
			CityDropDown.DataSource = locations.cities;

			CreateCinemaButton.Enabled = false;
			CountyDropDown.Enabled = false;
			CityDropDown.Enabled = false;
			CinemaDropDown.Enabled = false;
			StreetDropDown.Enabled = false;
			HouseNumberDropDown.Enabled = false;
			CinemaNameTextBox.Enabled = false;

			FormClosing += onClose;
		}

		private void button1_Click(object sender, EventArgs e) {
			string county, city, street, cinemaName, maintainerName, houseNumber;

            if (string.IsNullOrWhiteSpace(CinemaNameTextBox.Text))
            {
                MessageBox.Show("Kérem nevezze el a mozit!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

			county = CountyDropDown.SelectedValue.ToString();
			city = CityDropDown.SelectedValue.ToString();
			street = StreetDropDown.Text;
			houseNumber = HouseNumberDropDown.Text;
			cinemaName = CinemaNameTextBox.Text;
			maintainerName = username;
			DateTime creationTime = DateTime.Now;

			DB.createCinema(county, city, street, cinemaName, maintainerName, houseNumber, creationTime);

			CinemaDropDown.DataSource = DB.retrieveCinemaNamesByOwner(username);

		}

		private void button2_Click(object sender, EventArgs e) {
			Startup myForm = (Startup)Application.OpenForms["Startup"];
			this.Close();
			myForm.Show();
		}
		private void onClose(object sender, EventArgs e){
			Startup myForm = (Startup)Application.OpenForms["Startup"];
			myForm.Show();
		}

		private void button3_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.ShowDialog();
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;

			string path = openFileDialog1.FileName;
			string[] fileContents = File.ReadAllLines(path);

			bool success = int.TryParse(fileContents[0], out int week);
			if (!success) MessageBox.Show("A fájl nem a hét számával kezdődik!\nEllenőrizze a megadott fájlt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);

			string[] tempFileContents = { "" };
			for (int i = 1; i < fileContents.Length; i++) {
				tempFileContents[i - 1] = fileContents[i];
			}
			DB.saveMovies(week, tempFileContents, CinemaDropDown.SelectedItem.ToString());
		}

		private void button5_Click(object sender, EventArgs e) {
			string uname = UsernameTextBox.Text;
			string password = textBox5.Text;

			bool login = DB.Login(uname, password);
			if (login){
				username = uname;

				textBox5.Enabled = false;
				UsernameTextBox.Enabled = false;
				LoginButton.Enabled = false;
				RegisterButton.Enabled = false;

				CreateCinemaButton.Enabled = true;
				CountyDropDown.Enabled = true;
				CityDropDown.Enabled = true;
				CinemaDropDown.Enabled = true;
				StreetDropDown.Enabled = true;
				HouseNumberDropDown.Enabled = true;
				CinemaNameTextBox.Enabled = true;

				CinemaDropDown.DataSource = DB.retrieveCinemaNamesByOwner(username);

			} else
				MessageBox.Show("Sikertelen Bejelentkezés!\nEllenőrizze a felhasználónevét és jelszavát,\n vagy regisztráljon!", "Hiba",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}

		private void button4_Click(object sender, EventArgs e) {
			AdminRegister register = new AdminRegister();
			register.Show();
		}		
		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			if (CinemaDropDown.SelectedItem.ToString() == "") {
				CreateCinemaButton.Enabled = true;
				CountyDropDown.Enabled = true;
				CityDropDown.Enabled = true;
				StreetDropDown.Enabled = true;
				HouseNumberDropDown.Enabled = true;
				CinemaNameTextBox.Enabled = true;
				ImportButton.Enabled = false;
			} else{
				CreateCinemaButton.Enabled = false;
				CountyDropDown.Enabled = false;
				CityDropDown.Enabled = false;
				StreetDropDown.Enabled = false;
				HouseNumberDropDown.Enabled = false;
				CinemaNameTextBox.Enabled = false;
				ImportButton.Enabled = true;
			}
		}

		private void button6_Click(object sender, EventArgs e) {
			if(CinemaDropDown.Text != "")
				DB.deleteCinema(CinemaDropDown.Text);
		}
	}
}
