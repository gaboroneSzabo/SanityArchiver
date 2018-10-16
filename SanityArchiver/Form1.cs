using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace SanityArchiver
{
    public partial class Form1 : Form
    {
        FileBrowser left;
        FileBrowser right;

        public Form1()
        {
            InitializeComponent();

            foreach(DriveInfo drive in DriveInfo.GetDrives())
            {
                leftComboBox.Items.Add(drive.Name);
                rightComboBox.Items.Add(drive.Name);
            }

            leftComboBox.SelectionChangeCommitted += comboBoxChanged;
            rightComboBox.SelectionChangeCommitted += comboBoxChanged;
            
            
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
    }
}
