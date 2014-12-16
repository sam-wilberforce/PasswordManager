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
    public partial class addAcc : Form
    {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox account;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnGen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox user;

        public addAcc()
        {
            init();
        }

        private void init()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.account = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnGen = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account Name";
            // 
            // account
            // 
            this.account.Location = new System.Drawing.Point(12, 30);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(137, 20);
            this.account.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(12, 145);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(269, 20);
            this.password.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(72, 34);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnGen
            // 
            this.btnGen.Location = new System.Drawing.Point(291, 142);
            this.btnGen.Name = "btnGen";
            this.btnGen.Size = new System.Drawing.Size(75, 24);
            this.btnGen.TabIndex = 4;
            this.btnGen.Text = "Generate..";
            this.btnGen.UseVisualStyleBackColor = true;
            this.btnGen.Click += new System.EventHandler(this.btnGen_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(12, 87);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(217, 20);
            this.user.TabIndex = 2;
            // 
            // addAcc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 244);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGen);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.account);
            this.Controls.Add(this.label1);
            this.Icon = new Icon("lock.ico");
            this.Name = "addAcc";
            this.Text = "Add account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //decrypt all data, append new account, encrypt + store new data
            if (password.Text.Equals(string.Empty) || account.Text.Equals(string.Empty) || user.Text.Equals(string.Empty))
                MessageBox.Show("Fields cannot be empty!");
            else
            {
                if (!account.Text.Contains(":::") && !user.Text.Contains(":::") && !password.Text.Contains(":::"))
                {
                    string info;
                    if (File.Exists("acc.pwm") && new FileInfo("acc.pwm").Length != 0)
                    {
                        info = Crypto.decrypt();
                        info += ":::" + account.Text + ":::" + user.Text + ":::" + password.Text;
                    }
                    else info = account.Text + ":::" + user.Text + ":::" + password.Text;
                    Crypto.encrypt(info);
                    MessageBox.Show("Added the account '" + account.Text + "'", "Success!");
                    account.Clear();
                    user.Clear();
                    password.Clear();
                    account.Focus();
                }
                else MessageBox.Show("Fields cannot use ':::'");
            }
        }

        private void btnGen_Click(object sender, EventArgs e)
        {
            if (Main.charsets == 0)
                MessageBox.Show("No character sets checked!");
            else
            {
                password.Clear();
                password.Text = genPass.getPass(Main.charsets, Main.passLength);
            }
        }
    }
}