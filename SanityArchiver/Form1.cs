using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        List<DirectoryInfo> directories = new List<DirectoryInfo>();
        List<FileInfo> files = new List<FileInfo>();
        Label selected;
        public Form1()
        {
            InitializeComponent();
            addLabels("C:\\");
        }

        private void addLabels(String path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            directories.Clear();
            files.Clear();
            leftPanel.Controls.Clear();

            foreach (DirectoryInfo directory in di.GetDirectories())
            {
               
                directories.Add(directory);
                Label dirLabel = new Label();
                dirLabel.Click += dirClicked;
                dirLabel.Text = directory.Name;

                leftPanel.Controls.Add(dirLabel);

            }

            foreach (FileInfo file in di.GetFiles())
            {

                files.Add(file);
                Label fileLabel = new Label();
                fileLabel.Text = file.Name + file.Extension;

                leftPanel.Controls.Add(fileLabel);


            }
        }

        private void dirClicked(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            
            if(label.ForeColor == Color.Blue)
            {
                DirectoryInfo dir = findDirectoryByName(label.Text);
                addLabels(dir.FullName);
            }
            else
            {
                if (selected != null)
                {
                    selected.ForeColor = default(Color);
                }
                
                selected = label;

                label.ForeColor = Color.Blue;
            }
        }

        private DirectoryInfo findDirectoryByName(string name)
        {
            foreach(DirectoryInfo directory in directories)
            {
                if (directory.Name == name)
                {
                    return directory;
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            
        }

        private void rightPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
