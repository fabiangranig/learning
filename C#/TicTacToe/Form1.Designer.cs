namespace TicTacToe
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.Feld11 = new System.Windows.Forms.Button();
            this.Feld12 = new System.Windows.Forms.Button();
            this.Feld13 = new System.Windows.Forms.Button();
            this.Feld21 = new System.Windows.Forms.Button();
            this.Feld22 = new System.Windows.Forms.Button();
            this.Feld23 = new System.Windows.Forms.Button();
            this.Feld31 = new System.Windows.Forms.Button();
            this.Feld32 = new System.Windows.Forms.Button();
            this.Feld33 = new System.Windows.Forms.Button();
            this.Draw_Siege = new System.Windows.Forms.Label();
            this.X_Siege = new System.Windows.Forms.Label();
            this.O_Siege = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Feld11
            // 
            this.Feld11.Location = new System.Drawing.Point(12, 23);
            this.Feld11.Name = "Feld11";
            this.Feld11.Size = new System.Drawing.Size(100, 100);
            this.Feld11.TabIndex = 0;
            this.Feld11.UseVisualStyleBackColor = true;
            this.Feld11.Click += new System.EventHandler(this.button_click);
            // 
            // Feld12
            // 
            this.Feld12.Location = new System.Drawing.Point(131, 23);
            this.Feld12.Name = "Feld12";
            this.Feld12.Size = new System.Drawing.Size(100, 100);
            this.Feld12.TabIndex = 1;
            this.Feld12.UseVisualStyleBackColor = true;
            this.Feld12.Click += new System.EventHandler(this.button_click);
            // 
            // Feld13
            // 
            this.Feld13.Location = new System.Drawing.Point(248, 23);
            this.Feld13.Name = "Feld13";
            this.Feld13.Size = new System.Drawing.Size(100, 100);
            this.Feld13.TabIndex = 2;
            this.Feld13.UseVisualStyleBackColor = true;
            this.Feld13.Click += new System.EventHandler(this.button_click);
            // 
            // Feld21
            // 
            this.Feld21.Location = new System.Drawing.Point(12, 147);
            this.Feld21.Name = "Feld21";
            this.Feld21.Size = new System.Drawing.Size(100, 100);
            this.Feld21.TabIndex = 3;
            this.Feld21.UseVisualStyleBackColor = true;
            this.Feld21.Click += new System.EventHandler(this.button_click);
            // 
            // Feld22
            // 
            this.Feld22.Location = new System.Drawing.Point(130, 147);
            this.Feld22.Name = "Feld22";
            this.Feld22.Size = new System.Drawing.Size(100, 100);
            this.Feld22.TabIndex = 4;
            this.Feld22.UseVisualStyleBackColor = true;
            this.Feld22.Click += new System.EventHandler(this.button_click);
            // 
            // Feld23
            // 
            this.Feld23.Location = new System.Drawing.Point(248, 147);
            this.Feld23.Name = "Feld23";
            this.Feld23.Size = new System.Drawing.Size(100, 100);
            this.Feld23.TabIndex = 5;
            this.Feld23.UseVisualStyleBackColor = true;
            this.Feld23.Click += new System.EventHandler(this.button_click);
            // 
            // Feld31
            // 
            this.Feld31.Location = new System.Drawing.Point(12, 270);
            this.Feld31.Name = "Feld31";
            this.Feld31.Size = new System.Drawing.Size(100, 100);
            this.Feld31.TabIndex = 6;
            this.Feld31.UseVisualStyleBackColor = true;
            this.Feld31.Click += new System.EventHandler(this.button_click);
            // 
            // Feld32
            // 
            this.Feld32.Location = new System.Drawing.Point(130, 270);
            this.Feld32.Name = "Feld32";
            this.Feld32.Size = new System.Drawing.Size(100, 100);
            this.Feld32.TabIndex = 7;
            this.Feld32.UseVisualStyleBackColor = true;
            this.Feld32.Click += new System.EventHandler(this.button_click);
            // 
            // Feld33
            // 
            this.Feld33.Location = new System.Drawing.Point(248, 270);
            this.Feld33.Name = "Feld33";
            this.Feld33.Size = new System.Drawing.Size(100, 100);
            this.Feld33.TabIndex = 8;
            this.Feld33.UseVisualStyleBackColor = true;
            this.Feld33.Click += new System.EventHandler(this.button_click);
            // 
            // Draw_Siege
            // 
            this.Draw_Siege.Location = new System.Drawing.Point(418, 82);
            this.Draw_Siege.Name = "Draw_Siege";
            this.Draw_Siege.Size = new System.Drawing.Size(200, 20);
            this.Draw_Siege.TabIndex = 9;
            this.Draw_Siege.Text = "Draw:  0";
            // 
            // X_Siege
            // 
            this.X_Siege.Location = new System.Drawing.Point(418, 23);
            this.X_Siege.Name = "X_Siege";
            this.X_Siege.Size = new System.Drawing.Size(200, 20);
            this.X_Siege.TabIndex = 10;
            this.X_Siege.Text = "Spieler X:  0";
            this.X_Siege.Click += new System.EventHandler(this.label2_Click);
            // 
            // O_Siege
            // 
            this.O_Siege.Location = new System.Drawing.Point(418, 53);
            this.O_Siege.Name = "O_Siege";
            this.O_Siege.Size = new System.Drawing.Size(200, 20);
            this.O_Siege.TabIndex = 11;
            this.O_Siege.Text = "Spieler O:  0 ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 75);
            this.button1.TabIndex = 12;
            this.button1.Text = "Neues Spiel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.neuesSpiel);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Location = new System.Drawing.Point(421, 295);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(180, 75);
            this.Reset_Button.TabIndex = 13;
            this.Reset_Button.Text = "Zurücksetzen";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Zuruecksetzen);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.O_Siege);
            this.Controls.Add(this.X_Siege);
            this.Controls.Add(this.Draw_Siege);
            this.Controls.Add(this.Feld33);
            this.Controls.Add(this.Feld32);
            this.Controls.Add(this.Feld31);
            this.Controls.Add(this.Feld23);
            this.Controls.Add(this.Feld22);
            this.Controls.Add(this.Feld21);
            this.Controls.Add(this.Feld13);
            this.Controls.Add(this.Feld12);
            this.Controls.Add(this.Feld11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Feld11;
        private System.Windows.Forms.Button Feld12;
        private System.Windows.Forms.Button Feld13;
        private System.Windows.Forms.Button Feld21;
        private System.Windows.Forms.Button Feld22;
        private System.Windows.Forms.Button Feld23;
        private System.Windows.Forms.Button Feld31;
        private System.Windows.Forms.Button Feld32;
        private System.Windows.Forms.Button Feld33;
        private System.Windows.Forms.Label Draw_Siege;
        private System.Windows.Forms.Label X_Siege;
        private System.Windows.Forms.Label O_Siege;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Reset_Button;
    }
}

