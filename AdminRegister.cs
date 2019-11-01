using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	public partial class AdminRegister : Form {
		DB db = new DB();
		public AdminRegister() {
			InitializeComponent();
		}

		private void textBox2_TextChanged(object sender, EventArgs e) {
			textBox2.UseSystemPasswordChar = true;

		}

		private void textBox3_TextChanged(object sender, EventArgs e) {
			textBox3.UseSystemPasswordChar = true;

		}

		private void button1_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e) {
			string username = textBox1.Text,
						 password = textBox2.Text,
						 cPassword = textBox3.Text;
			if (password == cPassword){ 
				if (db.registerAdmin(username, password))
					MessageBox.Show("Sikeres regisztráció!\nLépjen vissza, majd lépjen be és töltse fel a mozija adatait!");
			}else
				MessageBox.Show("A megadott jelszavak nem egyeznek meg.");
		}
	}
}
