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
	}
}
