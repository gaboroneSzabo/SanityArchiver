using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public class Dialog : Form
    {
        private Button overwrite;
        private Label label1;
        private Button cancel;
        private Button rename;
        private TextBox textBox1;
        private FileBrowser browser;
        private string type;
        private string path;

        public Dialog()
        {

            InitializeComponent();

        }

        public Dialog(FileBrowser browser, string type, string path)
        {
            

            this.browser = browser;
            this.type = type;
            this.path = path;
            InitializeComponent();
            

        }

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.overwrite = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.Button();
            this.rename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(172, 134);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
           
            // 
            // overwrite
            // 
            this.overwrite.Location = new System.Drawing.Point(38, 131);
            this.overwrite.Name = "overwrite";
            this.overwrite.Size = new System.Drawing.Size(75, 23);
            this.overwrite.TabIndex = 1;
            this.overwrite.Text = "overwrite";
            this.overwrite.UseVisualStyleBackColor = true;
            this.overwrite.Click += new System.EventHandler(this.ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "file already exists";
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(38, 170);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // rename
            // 
            this.rename.Location = new System.Drawing.Point(172, 170);
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(75, 23);
            this.rename.TabIndex = 4;
            this.rename.Text = "rename file";
            this.rename.UseVisualStyleBackColor = true;
            this.rename.Click += new System.EventHandler(this.rename_Click);
            // 
            // Dialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.rename);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.overwrite);
            this.Controls.Add(this.textBox1);
            this.Name = "Dialog";
            this.Load += new System.EventHandler(this.Dialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
            this.ShowDialog();

        }

        private void Dialog_Load(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rename_Click(object sender, EventArgs e)
        {
            this.Close();
            string newName = textBox1.Text;
            try
            {
                browser.copy(browser.getPath(), newName);
            }
            catch
            {
                //new Dialog(browser, "copy", path);
            }
            
        }
    }
}
