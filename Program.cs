using System;
using System.Windows.Forms;

namespace Beadando_Forms {
	static class Program {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Startup());
		}
	}
}
