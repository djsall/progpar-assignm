﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Beadando_Forms {
	public partial class CreateCinema : Form {
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
		}
	}
}
