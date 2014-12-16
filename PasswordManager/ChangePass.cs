/*
This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
	*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PasswordManager
{
    public partial class ChangePass : Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox currentPass;
        private System.Windows.Forms.TextBox newPass1;
        private System.Windows.Forms.TextBox newPass2;
        private System.Windows.Forms.Button btnSave;

        public ChangePass()
        {
            init();
        }

        private void init()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.currentPass = new System.Windows.Forms.TextBox();
            this.newPass1 = new System.Windows.Forms.TextBox();
            this.newPass2 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "New password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confirm new password";
            // 
            // currentPass
            // 
            this.currentPass.Location = new System.Drawing.Point(15, 26);
            this.currentPass.Name = "currentPass";
            this.currentPass.Size = new System.Drawing.Size(192, 20);
            this.currentPass.TabIndex = 3;
            this.currentPass.UseSystemPasswordChar = true;
            // 
            // newPass1
            // 
            this.newPass1.Location = new System.Drawing.Point(16, 84);
            this.newPass1.Name = "newPass1";
            this.newPass1.Size = new System.Drawing.Size(191, 20);
            this.newPass1.TabIndex = 4;
            this.newPass1.UseSystemPasswordChar = true;
            // 
            // newPass2
            // 
            this.newPass2.Location = new System.Drawing.Point(16, 140);
            this.newPass2.Name = "newPass2";
            this.newPass2.Size = new System.Drawing.Size(191, 20);
            this.newPass2.TabIndex = 5;
            this.newPass2.UseSystemPasswordChar = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(72, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 223);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.newPass2);
            this.Controls.Add(this.newPass1);
            this.Controls.Add(this.currentPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = new Icon("lock.ico");
            this.Name = "ChangePass";
            this.Text = "Change password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentPass.Text.Equals(string.Empty) || newPass1.Text.Equals(string.Empty) || newPass2.Text.Equals(string.Empty))
                MessageBox.Show("Fields cannot be empty", "Error");
            else if (newPass1.Text != newPass2.Text)
                MessageBox.Show("Passwords do not match", "Error");
            else if (Crypto.hash(currentPass.Text) != Properties.Settings.Default.pass)
                MessageBox.Show("Incorrect password", "Error");
            else
            {
                //use currentPass to decrypt
                //encrypt with new pass
                if (File.Exists("acc.pwm"))
                {
                    string info = Crypto.decrypt();
                    Properties.Settings.Default.pass = Crypto.hash(newPass1.Text);
                    Properties.Settings.Default.Save();
                    Crypto.encrypt(info);
                }
                else
                {
                    Properties.Settings.Default.pass = Crypto.hash(newPass1.Text);
                    Properties.Settings.Default.Save();
                }
                MessageBox.Show("All done!\nPassword Manager will now restart.");
                Application.Restart();

            }
        }
    }
}
