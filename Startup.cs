using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	public partial class Startup : Form {
		public Startup() {
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) {

		}

		private void button1_Click(object sender, EventArgs e) {
			Administrator admin = new Administrator();
			admin.Show();
			this.Hide();
		}
	}
}
