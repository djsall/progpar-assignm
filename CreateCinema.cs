using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Beadando_Forms {
	public partial class CreateCinema : Form {
		string username;
		DB db = new DB();
		public CreateCinema() {
			InitializeComponent();
			List<string> counties = new List<string>() { "Bács-Kiskun", "Baranya", "Békés", "Borsod-Abaúj-Zemplén", "Csongrád", "Fejér", "Győr-Moson-Sopron", "Hajdú-Bihar", "Heves", "Jász-Nagykun-Szolnok", "Komárom-Esztergom", "Nógrád", "Pest", "Somogy", "Szabolcs-Szatmár-Bereg", "Tolna", "Vas", "Veszprém", "Zala" };
			comboBox1.DataSource = counties;
			List<string> cities = new List<string>(File.ReadAllLines("irszVarKer.txt"));
			comboBox2.DataSource = cities;
		}

		private void button1_Click(object sender, EventArgs e) {
			string county, city, street, cinemaName, maintainerName, houseNumber;

			county = comboBox1.SelectedValue.ToString();
			city = comboBox2.SelectedValue.ToString();
			street = textBox1.Text;
			houseNumber = textBox2.Text;
			cinemaName = textBox3.Text;
			maintainerName = textBox4.Text;
			DateTime creationTime = DateTime.Now;

			db.createCinema(county, city, street, cinemaName, maintainerName, houseNumber, creationTime);
		}

		private void button2_Click(object sender, EventArgs e) {
			Startup myForm = (Startup)Application.OpenForms["Startup"];
			this.Close();
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
			if (!success) MessageBox.Show("A fájl nem a hét számával kezdődik!\nEllenőrizze a megadott fájlt!");

			string[] tempFileContents = { "" };
			for (int i = 1; i < fileContents.Length; i++) {
				tempFileContents[i - 1] = fileContents[i];
			}
			db.saveMovies(week, tempFileContents, comboBox3.SelectedItem.ToString());
		}

		private void button5_Click(object sender, EventArgs e) {
			string uname = textBox6.Text;
			string password = textBox5.Text;

			bool login = db.Login(uname, password);
			if (login){
				MessageBox.Show("Sikeres Bejelentkezés!");

				username = uname;

				textBox5.Enabled = false;
				textBox6.Enabled = false;
				button5.Enabled = false;
				button4.Enabled = false;

				comboBox3.DataSource = db.retrieveCinemaNames(username);

			} else
				MessageBox.Show("Sikertelen Bejelentkezés!\nEllenőrizze a felhasználónevét és jelszavát,\n vagy regisztráljon!");
		}

		private void button4_Click(object sender, EventArgs e) {
			AdminRegister register = new AdminRegister();
			this.Hide();
			register.Show();
		}

		private void textBox5_TextChanged(object sender, EventArgs e) {
			textBox2.UseSystemPasswordChar = true;

		}

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
			if (comboBox3.SelectedItem.ToString() == "") {
				button1.Enabled = true;
			} else{
				button1.Enabled = false;
				comboBox1.Enabled = false;
				comboBox2.Enabled = false;
				textBox1.Enabled = false;
				textBox2.Enabled = false;
				textBox3.Enabled = false;
				textBox4.Enabled = false;

			}

		}
	}
}
