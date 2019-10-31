using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		private void button1_Click(object sender, EventArgs e) {
			Administrator admin = new Administrator();
			admin.Show();
			this.Close();
		}
	}
}
