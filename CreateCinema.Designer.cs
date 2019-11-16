namespace Beadando_Forms {
	partial class CreateCinema {
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
            this.label1 = new System.Windows.Forms.Label();
            this.CountyDropDown = new System.Windows.Forms.ComboBox();
            this.CityDropDown = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.HouseNumberDropDown = new System.Windows.Forms.TextBox();
            this.CinemaNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.StreetDropDown = new System.Windows.Forms.TextBox();
            this.CreateCinemaButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.CinemaDropDown = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.UsernameTextBox = new System.Windows.Forms.TextBox();
            this.DeleteCinemaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Megye";
            // 
            // CountyDropDown
            // 
            this.CountyDropDown.FormattingEnabled = true;
            this.CountyDropDown.Location = new System.Drawing.Point(233, 25);
            this.CountyDropDown.Name = "CountyDropDown";
            this.CountyDropDown.Size = new System.Drawing.Size(121, 21);
            this.CountyDropDown.TabIndex = 2;
            // 
            // CityDropDown
            // 
            this.CityDropDown.FormattingEnabled = true;
            this.CityDropDown.Location = new System.Drawing.Point(360, 25);
            this.CityDropDown.Name = "CityDropDown";
            this.CityDropDown.Size = new System.Drawing.Size(205, 21);
            this.CityDropDown.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Város";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Utca";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(698, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Házszám";
            // 
            // HouseNumberDropDown
            // 
            this.HouseNumberDropDown.Location = new System.Drawing.Point(701, 25);
            this.HouseNumberDropDown.Name = "HouseNumberDropDown";
            this.HouseNumberDropDown.Size = new System.Drawing.Size(51, 20);
            this.HouseNumberDropDown.TabIndex = 8;
            // 
            // CinemaNameTextBox
            // 
            this.CinemaNameTextBox.Location = new System.Drawing.Point(233, 86);
            this.CinemaNameTextBox.Name = "CinemaNameTextBox";
            this.CinemaNameTextBox.Size = new System.Drawing.Size(226, 20);
            this.CinemaNameTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mozi Neve";
            // 
            // StreetDropDown
            // 
            this.StreetDropDown.Location = new System.Drawing.Point(571, 25);
            this.StreetDropDown.Name = "StreetDropDown";
            this.StreetDropDown.Size = new System.Drawing.Size(124, 20);
            this.StreetDropDown.TabIndex = 13;
            // 
            // CreateCinemaButton
            // 
            this.CreateCinemaButton.Location = new System.Drawing.Point(465, 84);
            this.CreateCinemaButton.Name = "CreateCinemaButton";
            this.CreateCinemaButton.Size = new System.Drawing.Size(100, 23);
            this.CreateCinemaButton.TabIndex = 14;
            this.CreateCinemaButton.Text = "Létrehozás";
            this.CreateCinemaButton.UseVisualStyleBackColor = true;
            this.CreateCinemaButton.Click += new System.EventHandler(this.CreateCinemaButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(12, 158);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(182, 23);
            this.BackButton.TabIndex = 15;
            this.BackButton.Text = "Vissza";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(465, 158);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(100, 23);
            this.ImportButton.TabIndex = 16;
            this.ImportButton.Text = "Műsor tallózása";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // CinemaDropDown
            // 
            this.CinemaDropDown.FormattingEnabled = true;
            this.CinemaDropDown.Location = new System.Drawing.Point(233, 160);
            this.CinemaDropDown.Name = "CinemaDropDown";
            this.CinemaDropDown.Size = new System.Drawing.Size(226, 21);
            this.CinemaDropDown.TabIndex = 17;
            this.CinemaDropDown.SelectedIndexChanged += new System.EventHandler(this.CinemaDropDown_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Mozi neve";
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(12, 129);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(182, 23);
            this.RegisterButton.TabIndex = 24;
            this.RegisterButton.Text = "Regisztráció!";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 100);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(182, 23);
            this.LoginButton.TabIndex = 23;
            this.LoginButton.Text = "Belépés!";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Jelszó";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Felhasználónév";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 73);
            this.textBox5.Name = "textBox5";
            this.textBox5.PasswordChar = '*';
            this.textBox5.Size = new System.Drawing.Size(182, 20);
            this.textBox5.TabIndex = 20;
            // 
            // UsernameTextBox
            // 
            this.UsernameTextBox.Location = new System.Drawing.Point(12, 25);
            this.UsernameTextBox.Name = "UsernameTextBox";
            this.UsernameTextBox.Size = new System.Drawing.Size(182, 20);
            this.UsernameTextBox.TabIndex = 19;
            // 
            // DeleteCinemaButton
            // 
            this.DeleteCinemaButton.Location = new System.Drawing.Point(571, 158);
            this.DeleteCinemaButton.Name = "DeleteCinemaButton";
            this.DeleteCinemaButton.Size = new System.Drawing.Size(100, 23);
            this.DeleteCinemaButton.TabIndex = 25;
            this.DeleteCinemaButton.Text = "Mozi törlése";
            this.DeleteCinemaButton.UseVisualStyleBackColor = true;
            this.DeleteCinemaButton.Click += new System.EventHandler(this.DeleteCinemaButton_Click);
            // 
            // CreateCinema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 195);
            this.Controls.Add(this.DeleteCinemaButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.UsernameTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CinemaDropDown);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CreateCinemaButton);
            this.Controls.Add(this.StreetDropDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CinemaNameTextBox);
            this.Controls.Add(this.HouseNumberDropDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CityDropDown);
            this.Controls.Add(this.CountyDropDown);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(776, 234);
            this.MinimumSize = new System.Drawing.Size(776, 234);
            this.Name = "CreateCinema";
            this.Text = "Mozi Létrehozása";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox CountyDropDown;
		private System.Windows.Forms.ComboBox CityDropDown;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox HouseNumberDropDown;
		private System.Windows.Forms.TextBox CinemaNameTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox StreetDropDown;
		private System.Windows.Forms.Button CreateCinemaButton;
		private System.Windows.Forms.Button BackButton;
		private System.Windows.Forms.Button ImportButton;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ComboBox CinemaDropDown;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button RegisterButton;
		private System.Windows.Forms.Button LoginButton;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox UsernameTextBox;
		private System.Windows.Forms.Button DeleteCinemaButton;
	}
}