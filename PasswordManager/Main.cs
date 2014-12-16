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
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace PasswordManager
{
    public partial class Main : Form
    {
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox upperChk;
        private System.Windows.Forms.CheckBox lowerChk;
        private System.Windows.Forms.CheckBox specialChk;
        private System.Windows.Forms.CheckBox numbersChk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown passLen;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn acc;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer1;

        public static int charsets;
        public static int passLength;

        Properties.Settings settings = Properties.Settings.Default;

        public Main()
        {
            init();
            loadSettings();
            loadData();
        }

        private void init()
        {
            
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.upperChk = new System.Windows.Forms.CheckBox();
            this.lowerChk = new System.Windows.Forms.CheckBox();
            this.specialChk = new System.Windows.Forms.CheckBox();
            this.numbersChk = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passLen = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.acc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passLen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChangePass
            // 
            this.btnChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePass.Location = new System.Drawing.Point(78, 19);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(116, 44);
            this.btnChangePass.TabIndex = 2;
            this.btnChangePass.Text = "Change master password";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(6, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 44);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.passLen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password generator";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.upperChk);
            this.groupBox3.Controls.Add(this.lowerChk);
            this.groupBox3.Controls.Add(this.specialChk);
            this.groupBox3.Controls.Add(this.numbersChk);
            this.groupBox3.Location = new System.Drawing.Point(6, 75);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 122);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Charsets";
            // 
            // upperChk
            // 
            this.upperChk.AutoSize = true;
            this.upperChk.Location = new System.Drawing.Point(6, 19);
            this.upperChk.Name = "upperChk";
            this.upperChk.Size = new System.Drawing.Size(54, 20);
            this.upperChk.TabIndex = 3;
            this.upperChk.Text = "A - Z";
            this.upperChk.UseVisualStyleBackColor = true;
            this.upperChk.CheckedChanged += new System.EventHandler(this.upperChk_CheckedChanged);
            // 
            // lowerChk
            // 
            this.lowerChk.AutoSize = true;
            this.lowerChk.Location = new System.Drawing.Point(6, 42);
            this.lowerChk.Name = "lowerChk";
            this.lowerChk.Size = new System.Drawing.Size(51, 20);
            this.lowerChk.TabIndex = 7;
            this.lowerChk.Text = "a - z";
            this.lowerChk.UseVisualStyleBackColor = true;
            this.lowerChk.CheckedChanged += new System.EventHandler(this.lowerChk_CheckedChanged);
            // 
            // specialChk
            // 
            this.specialChk.AutoSize = true;
            this.specialChk.Location = new System.Drawing.Point(6, 88);
            this.specialChk.Name = "specialChk";
            this.specialChk.Size = new System.Drawing.Size(152, 20);
            this.specialChk.TabIndex = 5;
            this.specialChk.Text = "Special (e.g. #@!\"$£)";
            this.specialChk.UseVisualStyleBackColor = true;
            this.specialChk.CheckedChanged += new System.EventHandler(this.specialChk_CheckedChanged);
            // 
            // numbersChk
            // 
            this.numbersChk.AutoSize = true;
            this.numbersChk.Location = new System.Drawing.Point(6, 65);
            this.numbersChk.Name = "numbersChk";
            this.numbersChk.Size = new System.Drawing.Size(51, 20);
            this.numbersChk.TabIndex = 6;
            this.numbersChk.Text = "0 - 9";
            this.numbersChk.UseVisualStyleBackColor = true;
            this.numbersChk.CheckedChanged += new System.EventHandler(this.numbersChk_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Password length";
            // 
            // passLen
            // 
            this.passLen.Location = new System.Drawing.Point(119, 35);
            this.passLen.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.passLen.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.passLen.Name = "passLen";
            this.passLen.Size = new System.Drawing.Size(56, 22);
            this.passLen.TabIndex = 11;
            this.passLen.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.passLen.ValueChanged += new System.EventHandler(this.passLen_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.acc,
            this.user,
            this.pass});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Size = new System.Drawing.Size(438, 277);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // 
            // acc
            // 
            this.acc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.acc.HeaderText = "Account";
            this.acc.MinimumWidth = 120;
            this.acc.Name = "acc";
            this.acc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.acc.Width = 120;
            // 
            // user
            // 
            this.user.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.user.HeaderText = "Username";
            this.user.MinimumWidth = 150;
            this.user.Name = "user";
            this.user.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.user.Width = 150;
            // 
            // pass
            // 
            this.pass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pass.HeaderText = "Password";
            this.pass.MinimumWidth = 150;
            this.pass.Name = "pass";
            this.pass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.pass.Width = 150;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 296);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accounts";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnChangePass);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(204, 296);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel1MinSize = 450;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Panel2MinSize = 210;
            this.splitContainer1.Size = new System.Drawing.Size(665, 302);
            this.splitContainer1.SplitterDistance = 450;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            this.splitContainer1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 302);
            this.Controls.Add(this.splitContainer1);
            this.Icon = new Icon("lock.ico");
            this.MinimumSize = new System.Drawing.Size(680, 340);
            this.Name = "Main";
            this.Text = "Password Manager";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passLen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);        
    }

        private void loadSettings()
        {
           passLength = settings.length;
            passLen.Value = passLength; //set pass length changer value
            /*
             * Each call to checked increases charset value
             * so we need to load original value into charsets
             * after checking boxes
             */
            checkBoxes(settings.charsets);
            charsets = settings.charsets;
        }

        private void loadData()
        {
            if (File.Exists("acc.pwm") && new FileInfo("acc.pwm").Length != 0)
            {
				int i = 0;
                string[] accounts = Crypto.decrypt().Replace("\0", "").Split(new string[] { ":::" }, StringSplitOptions.None);
                dataGridView1.Rows.Clear();
                for (int a = 0; a < accounts.Length; a += 3)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = accounts[a];
                    dataGridView1.Rows[i].Cells[1].Value = accounts[a + 1];
                    dataGridView1.Rows[i].Cells[2].Value = accounts[a + 2];
					i++;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addAcc add = new addAcc();
            add.ShowDialog();
            loadData();
            int w = dataGridView1.Columns[0].Width + dataGridView1.Columns[1].Width + dataGridView1.Columns[2].Width;
            splitContainer1.SplitterDistance = w;
            dataGridView1.Focus();
        }

        private void upperChk_CheckedChanged(object sender, EventArgs e)
        {
            if (upperChk.Checked == true) charsets += 1;
            else charsets -= 1;
            settings.charsets = charsets;
            settings.Save();
        }

        private void lowerChk_CheckedChanged(object sender, EventArgs e)
        {
            if (lowerChk.Checked == true) charsets += 2;
            else charsets -= 2;
            settings.charsets = charsets;
            settings.Save();
        }

        private void numbersChk_CheckedChanged(object sender, EventArgs e)
        {
            if (numbersChk.Checked == true) charsets += 4;
            else charsets -= 4;
            settings.charsets = charsets;
            settings.Save();
        }

        private void specialChk_CheckedChanged(object sender, EventArgs e)
        {
            if (specialChk.Checked == true) charsets += 8;
            else charsets -= 8;
            settings.charsets = charsets;
            settings.Save();
        }

        private void passLen_ValueChanged(object sender, EventArgs e)
        {
            passLength = (int)passLen.Value; //set global variable
            settings.length = passLength; //set persistent settings
            settings.Save();
        }

        private void checkBoxes(int charsets)
        {
            switch (charsets)
            {
                case 1:
                    upperChk.Checked = true;
                    break;
                case 2:
                    lowerChk.Checked = true;
                    break;
                case 3:
                    upperChk.Checked = true;
                    lowerChk.Checked = true;
                    break;
                case 4:
                    numbersChk.Checked = true;
                    break;
                case 5:
                    upperChk.Checked = true;
                    numbersChk.Checked = true;
                    break;
                case 6:
                    lowerChk.Checked = true;
                    numbersChk.Checked = true;
                    break;
                case 7:
                    upperChk.Checked = true;
                    lowerChk.Checked = true;
                    numbersChk.Checked = true;
                    break;
                case 8:
                    specialChk.Checked = true;
                    break;
                case 9:
                    upperChk.Checked = true;
                    specialChk.Checked = true;
                    break;
                case 10:
                    lowerChk.Checked = true;
                    specialChk.Checked = true;
                    break;
                case 11:
                    upperChk.Checked = true;
                    lowerChk.Checked = true;
                    specialChk.Checked = true;
                    break;
                case 12:
                    numbersChk.Checked = true;
                    specialChk.Checked = true;
                    break;
                case 13:
                    upperChk.Checked = true;
                    numbersChk.Checked = true;
                    specialChk.Checked = true;
                    break;
                case 14:
                    lowerChk.Checked = true;
                    numbersChk.Checked = true;
                    specialChk.Checked = true;
                    break;
                case 15:
                    upperChk.Checked = true;
                    lowerChk.Checked = true;
                    numbersChk.Checked = true;
                    specialChk.Checked = true;
                    break;
            }
        }

        private void del()
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            string acc = dataGridView1.Rows[row].Cells[0].Value.ToString();
            DialogResult res = MessageBox.Show("Are you sure you want to delete the account '" + acc + "'?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                string[] accounts = Crypto.decrypt().Replace("\0", "").Split(new string[] { ":::" }, StringSplitOptions.None);
                string newAcc = "";
                for (int i = 0; i < accounts.Length; i += 3)
                {
                    if (i != row * 3)
                    {//avoid putting account to delete in new account file
                        if (i == 0 || newAcc.Length == 0) //if first account, don't put separator at start
                            newAcc += (accounts[i] + ":::" + accounts[i + 1] + ":::" + accounts[i + 2]);
                        else newAcc += (":::" + accounts[i] + ":::" + accounts[i + 1] + ":::" + accounts[i + 2]);
                    }
                }

                if (accounts.Length == 3)
                {//if last account is being deleted, simply write blank file and remove row
                    File.WriteAllText("acc.pwm", string.Empty);                  
                    dataGridView1.Rows.Remove(dataGridView1.Rows[row]);
                }
                else
                {//write remaining data and refresh
                    Crypto.encrypt(newAcc);
                    loadData();
                }
                
            }
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            ChangePass chP = new ChangePass();
            chP.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                del();
        }
    }
}
