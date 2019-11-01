using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace Beadando_Forms {
	public partial class CreateCinema : Form {
		DB db = new DB();
		public CreateCinema() {
			InitializeComponent();
			List<string> counties = new List<string>() { "Bács-Kiskun", "Baranya", "Békés", "Borsod-Abaúj-Zemplén", "Csongrád", "Fejér", "Győr-Moson-Sopron", "Hajdú-Bihar", "Heves", "Jász-Nagykun-Szolnok", "Komárom-Esztergom", "Nógrád", "Pest", "Somogy", "Szabolcs-Szatmár-Bereg", "Tolna", "Vas", "Veszprém", "Zala" };
			comboBox1.DataSource = counties;
			List<string> cities = new List<string>(File.ReadAllLines("irszVarKer.txt"));
			comboBox2.DataSource = cities;
		}

		private void button1_Click(object sender, EventArgs e) {
			string county, city, street, cinemaName, maintainerName;
			int houseNumber;
			county = comboBox1.SelectedValue.ToString();
			city = comboBox2.SelectedValue.ToString();
			street = textBox1.Text;
			houseNumber = int.Parse(textBox2.Text);
			cinemaName = textBox3.Text;
			maintainerName = textBox4.Text;
			db.createAdmin(county, city, street, cinemaName, maintainerName, houseNumber);
		}

		private void button2_Click(object sender, EventArgs e) {
			Administrator admin = new Administrator();
			admin.Show();
			this.Hide();
		}

		private void button3_Click(object sender, EventArgs e) {
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.ShowDialog();
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;

			string path = openFileDialog1.FileName;
			string[] fileContents = File.ReadAllLines(path);

			int week;
			bool success = int.TryParse(fileContents[0], out week);
			if (!success) MessageBox.Show("A fájl nem a hét számával kezdődik!\nEllenőrizze a megadott fájlt! :)");
			string[] tempFileContents = { "" };
			for (int i = 1; i < fileContents.Length; i++) {
				tempFileContents[i - 1] = fileContents[i];
			}
			db.saveMovies(week, tempFileContents);
		}
	}
}
