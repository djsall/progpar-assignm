namespace Beadando_Forms {
	partial class Startup {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.AdminButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CityDropDown = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CinemaDropDown = new System.Windows.Forms.ComboBox();
            this.MovieDropDown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GenreDropDown = new System.Windows.Forms.ComboBox();
            this.MovieInfoDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MovieDetailsBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AdminButton
            // 
            this.AdminButton.Location = new System.Drawing.Point(704, 170);
            this.AdminButton.Name = "AdminButton";
            this.AdminButton.Size = new System.Drawing.Size(84, 23);
            this.AdminButton.TabIndex = 0;
            this.AdminButton.Text = "Adminisztrátor";
            this.AdminButton.UseVisualStyleBackColor = true;
            this.AdminButton.Click += new System.EventHandler(this.AdminButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Város";
            // 
            // CityDropDown
            // 
            this.CityDropDown.FormattingEnabled = true;
            this.CityDropDown.Location = new System.Drawing.Point(12, 24);
            this.CityDropDown.Name = "CityDropDown";
            this.CityDropDown.Size = new System.Drawing.Size(175, 21);
            this.CityDropDown.TabIndex = 5;
            this.CityDropDown.SelectedIndexChanged += new System.EventHandler(this.CityDropDown_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(190, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Mozi neve";
            // 
            // CinemaDropDown
            // 
            this.CinemaDropDown.FormattingEnabled = true;
            this.CinemaDropDown.Location = new System.Drawing.Point(193, 24);
            this.CinemaDropDown.Name = "CinemaDropDown";
            this.CinemaDropDown.Size = new System.Drawing.Size(226, 21);
            this.CinemaDropDown.TabIndex = 19;
            this.CinemaDropDown.SelectedIndexChanged += new System.EventHandler(this.CinemaDropDown_SelectedIndexChanged);
            // 
            // MovieDropDown
            // 
            this.MovieDropDown.FormattingEnabled = true;
            this.MovieDropDown.Location = new System.Drawing.Point(425, 24);
            this.MovieDropDown.Name = "MovieDropDown";
            this.MovieDropDown.Size = new System.Drawing.Size(363, 21);
            this.MovieDropDown.TabIndex = 21;
            this.MovieDropDown.SelectedIndexChanged += new System.EventHandler(this.MovieDropDown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Filmek címe és időpontja:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Műfaj";
            // 
            // GenreDropDown
            // 
            this.GenreDropDown.FormattingEnabled = true;
            this.GenreDropDown.Location = new System.Drawing.Point(12, 101);
            this.GenreDropDown.Name = "GenreDropDown";
            this.GenreDropDown.Size = new System.Drawing.Size(175, 21);
            this.GenreDropDown.TabIndex = 23;
            this.GenreDropDown.SelectedIndexChanged += new System.EventHandler(this.GenreDropDown_SelectedIndexChanged);
            // 
            // MovieInfoDropDown
            // 
            this.MovieInfoDropDown.FormattingEnabled = true;
            this.MovieInfoDropDown.Location = new System.Drawing.Point(193, 101);
            this.MovieInfoDropDown.Name = "MovieInfoDropDown";
            this.MovieInfoDropDown.Size = new System.Drawing.Size(595, 21);
            this.MovieInfoDropDown.TabIndex = 25;
            this.MovieInfoDropDown.SelectedIndexChanged += new System.EventHandler(this.MovieInfoDropDown_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(190, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Filmek címe, város neve és időpontja:";
            // 
            // MovieDetailsBox
            // 
            this.MovieDetailsBox.Location = new System.Drawing.Point(9, 155);
            this.MovieDetailsBox.Multiline = true;
            this.MovieDetailsBox.Name = "MovieDetailsBox";
            this.MovieDetailsBox.Size = new System.Drawing.Size(689, 47);
            this.MovieDetailsBox.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Film részletei";
            // 
            // Startup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 214);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MovieDetailsBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MovieInfoDropDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GenreDropDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MovieDropDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CinemaDropDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CityDropDown);
            this.Controls.Add(this.AdminButton);
            this.MaximumSize = new System.Drawing.Size(809, 253);
            this.MinimumSize = new System.Drawing.Size(809, 253);
            this.Name = "Startup";
            this.Text = "Mozi-Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button AdminButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox CityDropDown;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox CinemaDropDown;
		private System.Windows.Forms.ComboBox MovieDropDown;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox GenreDropDown;
		private System.Windows.Forms.ComboBox MovieInfoDropDown;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox MovieDetailsBox;
		private System.Windows.Forms.Label label5;
	}
}

