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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("C:\\");
            
            foreach(DirectoryInfo directory in di.GetDirectories())
            {
                directories.Add(directory);
                Label dirLabel = new Label();
                dirLabel.Text = directory.Name;
                
                rightPanel.Controls.Add(dirLabel);
                
            }
            foreach(FileInfo file in di.GetFiles())
            {
                files.Add(file);
                Label fileLabel = new Label();
                fileLabel.Text = file.Name;
               
                rightPanel.Controls.Add(fileLabel);
               
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
   
        }

    }
}
