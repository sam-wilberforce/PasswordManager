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
using System.Security.Cryptography;

namespace PasswordManager
{
    public partial class Login : Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox myPass;
        private System.Windows.Forms.TextBox pass1;
        private System.Windows.Forms.TextBox pass2;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Button btnLogin;

        Properties.Settings settings = Properties.Settings.Default;

        public Login()
        {
            init();
            checkForNewUser();
        }
        private void init()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.myPass = new System.Windows.Forms.TextBox();
            this.pass1 = new System.Windows.Forms.TextBox();
            this.pass2 = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Confirm password";
            // 
            // myPass
            // 
            this.myPass.Location = new System.Drawing.Point(12, 154);
            this.myPass.Name = "myPass";
            this.myPass.Size = new System.Drawing.Size(188, 20);
            this.myPass.TabIndex = 2;
            this.myPass.UseSystemPasswordChar = true;
            this.myPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.myPass_KeyDown);
            // 
            // pass1
            // 
            this.pass1.Location = new System.Drawing.Point(15, 25);
            this.pass1.Name = "pass1";
            this.pass1.Size = new System.Drawing.Size(188, 20);
            this.pass1.TabIndex = 3;
            this.pass1.UseSystemPasswordChar = true;
            // 
            // pass2
            // 
            this.pass2.Location = new System.Drawing.Point(15, 81);
            this.pass2.Name = "pass2";
            this.pass2.Size = new System.Drawing.Size(188, 20);
            this.pass2.TabIndex = 4;
            this.pass2.UseSystemPasswordChar = true;
            this.pass2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pass2_KeyDown);
            // 
            // btnDone
            // 
            this.btnDone.Location = new System.Drawing.Point(68, 116);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 5;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(68, 189);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 227);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.pass2);
            this.Controls.Add(this.pass1);
            this.Controls.Add(this.myPass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = new Icon("lock.ico");
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void checkForNewUser()
        {
            bool newUser = settings.firstTime;
            if (newUser)
            {
                myPass.Visible = false;
                btnLogin.Visible = false;
                this.Height = 200;
                MessageBox.Show("Hi, welcome to Password Generator!" +
                    "\nYou'll need to create a password now to access your accounts.\n"
                    + "Do not forget this, it cannot be recovered!");
                //original size 307,85
            }
            else
            {
                btnDone.Visible = false;
                btnLogin.Location = new Point(68, 45);
                label1.Visible = false;
                label2.Visible = false;
                pass1.Visible = false;
                pass2.Visible = false;
                myPass.Visible = true;
                myPass.Location = new Point(12, 12);
                this.Height = 120;
                //Application.OpenForms["Main"].Hide();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (pass1.Text.Equals("") || pass2.Text.Equals(""))
            {
                MessageBox.Show("Password cannot be empty", "Oops!");
            }
            else if (pass1.Text.Equals(pass2.Text))
            {
                MessageBox.Show("Awesome, you're good to go!");
                settings.firstTime = false;
                string salt = genPass.getPass(7, 20);//lower,upper,numbers
                settings.salt = salt;
                settings.pass = Crypto.hash(pass1.Text);
                settings.Save();
                Main m = new Main();
                m.Show();
                this.Hide();
            }
            else MessageBox.Show("Passwords do not match!", "Oops!");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Crypto.hash(myPass.Text).Equals(settings.pass))
            {
                new Main().Show();
                this.Hide();
            }
            else MessageBox.Show("Incorrect password", "Error");
        }

        private void myPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void pass2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDone.PerformClick();
            }
        }
    }
}