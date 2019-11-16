using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	public partial class AdminRegister : Form {
		public AdminRegister() {
			InitializeComponent();
        }

		private void button2_Click(object sender, EventArgs e) {
			string username = textBox1.Text,
						 password = textBox2.Text,
						 cPassword = textBox3.Text;

            if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
            {
                MessageBox.Show("A felhasználónév nem álhat csak szóköz karakterekből, valamint legalább 3 karakter hosszúnak kell lennie.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 5)
            {
                MessageBox.Show("A Jelszó nem álhat csak szóköz karakterekből, valamint legalább 5 karakter hosszúnak kell lennie.", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password == cPassword){ 
				if (DB.registerAdmin(username, password))
					MessageBox.Show("Sikeres regisztráció!\nLépjen vissza, majd lépjen be és töltse fel a mozija adatait!", "Sikeres regisztráció!", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}else
				MessageBox.Show("A megadott jelszavak nem egyeznek meg.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
