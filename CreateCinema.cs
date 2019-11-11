using System;
using System.Windows.Forms;
using System.IO;

namespace Beadando_Forms {
	public partial class CreateCinema : Form {
		string username = "";
		public CreateCinema() {
			InitializeComponent();

			LocationsHandler locations = new LocationsHandler();

			comboBox1.DataSource = locations.counties;
			comboBox2.DataSource = locations.cities;

			button1.Enabled = false;
			comboBox1.Enabled = false;
			comboBox2.Enabled = false;
			comboBox3.Enabled = false;
			textBox1.Enabled = false;
			textBox2.Enabled = false;
			textBox3.Enabled = false;

			FormClosing += onClose;
		}

		private void button1_Click(object sender, EventArgs e) {
			string county, city, street, cinemaName, maintainerName, houseNumber;

			county = comboBox1.SelectedValue.ToString();
			city = comboBox2.SelectedValue.ToString();
			street = textBox1.Text;
			houseNumber = textBox2.Text;
			cinemaName = textBox3.Text;
			maintainerName = username;
			DateTime creationTime = DateTime.Now;

			DB.createCinema(county, city, street, cinemaName, maintainerName, houseNumber, creationTime);

			comboBox3.DataSource = DB.retrieveCinemaNamesByOwner(username);

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
			DB.saveMovies(week, tempFileContents, comboBox3.SelectedItem.ToString());
		}

		private void button5_Click(object sender, EventArgs e) {
			string uname = textBox6.Text;
			string password = textBox5.Text;

			bool login = DB.Login(uname, password);
			if (login){
				username = uname;

				textBox5.Enabled = false;
				textBox6.Enabled = false;
				button5.Enabled = false;
				button4.Enabled = false;

				button1.Enabled = true;
				comboBox1.Enabled = true;
				comboBox2.Enabled = true;
				comboBox3.Enabled = true;
				textBox1.Enabled = true;
				textBox2.Enabled = true;
				textBox3.Enabled = true;

				comboBox3.DataSource = DB.retrieveCinemaNamesByOwner(username);

			} else
				MessageBox.Show("Sikertelen Bejelentkezés!\nEllenőrizze a felhasználónevét és jelszavát,\n vagy regisztráljon!", "Hiba",MessageBoxButtons.OK,MessageBoxIcon.Error);
		}

		private void button4_Click(object sender, EventArgs e) {
			AdminRegister register = new AdminRegister();
			register.Show();
		}		
		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			if (comboBox3.SelectedItem.ToString() == "") {
				button1.Enabled = true;
				comboBox1.Enabled = true;
				comboBox2.Enabled = true;
				textBox1.Enabled = true;
				textBox2.Enabled = true;
				textBox3.Enabled = true;
				button3.Enabled = false;
			} else{
				button1.Enabled = false;
				comboBox1.Enabled = false;
				comboBox2.Enabled = false;
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				button3.Enabled = true;
			}
		}

		private void button6_Click(object sender, EventArgs e) {

		}
	}
}
