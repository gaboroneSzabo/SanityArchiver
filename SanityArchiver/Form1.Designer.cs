namespace SanityArchiver
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.leftTable = new System.Windows.Forms.ListView();
            this.asd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.attr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rightTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.leftComboBox = new System.Windows.Forms.ComboBox();
            this.rightComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(363, 88);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 8;
            this.button10.Text = "copy";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(363, 186);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 9;
            this.button11.Text = "compress";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // leftTable
            // 
            this.leftTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.asd,
            this.size,
            this.date,
            this.attr});
            this.leftTable.GridLines = true;
            this.leftTable.Location = new System.Drawing.Point(12, 88);
            this.leftTable.Name = "leftTable";
            this.leftTable.Size = new System.Drawing.Size(301, 313);
            this.leftTable.TabIndex = 10;
            this.leftTable.UseCompatibleStateImageBehavior = false;
            this.leftTable.View = System.Windows.Forms.View.Details;
            // 
            // asd
            // 
            this.asd.Text = "Name";
            this.asd.Width = 79;
            // 
            // size
            // 
            this.size.Text = "Size";
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // attr
            // 
            this.attr.Text = "Attributes";
            // 
            // rightTable
            // 
            this.rightTable.AccessibleName = "rightTable";
            this.rightTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.rightTable.GridLines = true;
            this.rightTable.Location = new System.Drawing.Point(487, 88);
            this.rightTable.Name = "rightTable";
            this.rightTable.Size = new System.Drawing.Size(301, 313);
            this.rightTable.TabIndex = 11;
            this.rightTable.UseCompatibleStateImageBehavior = false;
            this.rightTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Size";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Date";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Attributes";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(363, 280);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 12;
            this.button12.Text = "crypt";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(363, 328);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 13;
            this.button13.Text = "uncrypt";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // leftComboBox
            // 
            this.leftComboBox.FormattingEnabled = true;
            this.leftComboBox.Location = new System.Drawing.Point(96, 37);
            this.leftComboBox.Name = "leftComboBox";
            this.leftComboBox.Size = new System.Drawing.Size(45, 21);
            this.leftComboBox.TabIndex = 14;
            // 
            // rightComboBox
            // 
            this.rightComboBox.FormattingEnabled = true;
            this.rightComboBox.Location = new System.Drawing.Point(571, 37);
            this.rightComboBox.Name = "rightComboBox";
            this.rightComboBox.Size = new System.Drawing.Size(42, 21);
            this.rightComboBox.TabIndex = 15;
            this.rightComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "selected Drive:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "selected Drive:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(363, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(363, 231);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "uncompress";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightComboBox);
            this.Controls.Add(this.leftComboBox);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.rightTable);
            this.Controls.Add(this.leftTable);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Name = "Form1";
            this.Text = "File Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.ListView leftTable;
        private System.Windows.Forms.ColumnHeader asd;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader attr;
        private System.Windows.Forms.ListView rightTable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.ComboBox leftComboBox;
        private System.Windows.Forms.ComboBox rightComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

