using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	public partial class AdminRegister : Form {
		public AdminRegister() {
			InitializeComponent();
		}

		private void textBox2_TextChanged(object sender, EventArgs e) {
			textBox2.UseSystemPasswordChar = true;

		}

		private void textBox3_TextChanged(object sender, EventArgs e) {
			textBox3.UseSystemPasswordChar = true;

		}

		private void button2_Click(object sender, EventArgs e) {
			string username = textBox1.Text,
						 password = textBox2.Text,
						 cPassword = textBox3.Text;
			if (password == cPassword){ 
				if (DB.registerAdmin(username, password))
					MessageBox.Show("Sikeres regisztráció!\nLépjen vissza, majd lépjen be és töltse fel a mozija adatait!", "Sikeres regisztráció!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}else
				MessageBox.Show("A megadott jelszavak nem egyeznek meg.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
