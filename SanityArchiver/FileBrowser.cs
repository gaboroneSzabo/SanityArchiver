using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SanityArchiver
{
    class FileBrowser
    {

        public FileBrowser(ListView listView, string path)
        {
            this.listView = listView;
            listView.MouseDoubleClick += doubleClicked;
            currentPath = path;
            fillListView(path);
        }

        private ListView listView;
        private List<DirectoryInfo> directories = new List<DirectoryInfo>();
        private List<FileInfo> files = new List<FileInfo>();
        private string currentPath;


        private DirectoryInfo[] getDirectories(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                return di.GetDirectories();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error");
                return new DirectoryInfo[0];
            }
            
            
        }


        private FileInfo[] getFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            return di.GetFiles();
        }

        private void fillListView(string path)
        {
          
            directories.Clear();
            files.Clear();
            listView.Items.Clear();
            listView.Items.Add("");
            foreach (DirectoryInfo dir in getDirectories(path))
            {
                directories.Add(dir);
                ListViewItem item = new ListViewItem(dir.Name);

                item.SubItems.Add("");
                item.SubItems.Add(dir.CreationTime.ToString());
                item.SubItems.Add(dir.Attributes.ToString());
                listView.Items.Add(item);
            }

            foreach (FileInfo file in getFiles(path))
            {
                files.Add(file);
                ListViewItem item = new ListViewItem(file.Name);

                item.SubItems.Add(file.Length.ToString());
                item.SubItems.Add(file.CreationTime.ToString());
                item.SubItems.Add(file.Attributes.ToString());
                listView.Items.Add(item);
            }

        }

        private string getParrentPath(string path)
        {
            string[] pathArray = currentPath.Split('\\');
            string result = "";
            for (int i = 0; i < pathArray.Length - 1; i++)
            {
                result += pathArray[i];
                if (i != pathArray.Length - 2 | i == 0)
                {
                    result += "\\";
                }
            }
            return result;
        }

        private void doubleClicked(object sender, EventArgs e)
        {
            try
            {
                Point mousePosition = ((ListView)sender).PointToClient(Control.MousePosition);
                ListViewHitTestInfo hit = ((ListView)sender).HitTest(mousePosition);
               
                if (hit.SubItem.Text == "")
                {

                    currentPath = getParrentPath(currentPath);
                    fillListView(currentPath);
                }
                foreach (DirectoryInfo dir in directories)
                {
                    if (dir.Name == hit.SubItem.Text)
                    {
                        fillListView(dir.FullName);
                        currentPath = dir.FullName;
                        break;
                    }
                }
            }
            catch
            {

            }

        }
    }
}
