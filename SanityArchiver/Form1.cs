using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        FileBrowser left;
        FileBrowser right;
        Compress compress;

        string selected = "left";


        public Form1()
        {
            InitializeComponent();
            boundDriveLetters();
            compress = new Compress();

            leftComboBox.SelectionChangeCommitted += comboBoxChanged;
            rightComboBox.SelectionChangeCommitted += comboBoxChanged;

            leftTable.SelectedIndexChanged += slectedChangeLeft;
            rightTable.SelectedIndexChanged += slectedChangeRight;


        }

        private void slectedChangeLeft(object sender, EventArgs e)
        {
            this.selected = "left";

        }

        private void slectedChangeRight(object sender, EventArgs e)
        {
            this.selected = "right";
        }

        private FileBrowser getActive()
        {
            if (selected == "left")
            {
                return left;
            }
            else
            {
                return right;
            }
        }

        private void boundDriveLetters()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                leftComboBox.Items.Add(drive.Name);
                rightComboBox.Items.Add(drive.Name);
            }
        }

        private void comboBoxChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Equals(leftComboBox))
            {
                left = new FileBrowser(leftTable, comboBox.SelectedItem.ToString());
            }
            else
            {
                right = new FileBrowser(rightTable, comboBox.SelectedItem.ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }

        private void button11_Click(object sender, System.EventArgs e)
        {
            FileBrowser browser = getActive();
            browser.compress();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileBrowser browser = getActive();
            browser.delete();
        }
    }
}
