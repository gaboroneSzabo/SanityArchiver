using System.Collections.Generic;
using System.IO;
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
            FileBrowser left = new FileBrowser(leftTable, "C:\\");
            FileBrowser right = new FileBrowser(rightTable, "C:\\");
        }
    }
}
