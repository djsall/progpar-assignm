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
	public partial class Administrator : Form {
		public bool isLoggedIn = false;
		
		public Administrator() {

			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e) {

			CreateCinema create = new CreateCinema();
			create.Show();
			this.Hide();
		}

		private void button2_Click(object sender, EventArgs e) {
			AdminRegister register = new AdminRegister();
			register.Show();
			this.Hide();
		}

		private void textBox1_TextChanged(object sender, EventArgs e) {
			textBox2.UseSystemPasswordChar = true;
		}

		private void button3_Click(object sender, EventArgs e) {
			Startup start = new Startup();
			start.Show();
			this.Hide();
		}
	}
}
