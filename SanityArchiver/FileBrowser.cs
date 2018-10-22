using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SanityArchiver
{
    public class FileBrowser
    {
        private ListView listView;
        private List<DirectoryInfo> directories = new List<DirectoryInfo>();
        private List<FileInfo> files = new List<FileInfo>();
        private string currentPath;
        private Compress compressor;

        public FileBrowser(ListView listView, string path)
        {
            this.listView = listView;
            this.compressor = new Compress();
            listView.MouseDoubleClick += doubleClicked;
            currentPath = path;
            fillListView(path);
        }

        public string getPath()
        {
            return this.currentPath;
        }

        

        public ListView ListView
        {
            get
            {
                return this.listView;
            }
        }

        public void refresh()
        {
            fillListView(currentPath);
        }

        private DirectoryInfo getDirectoryFromItem(ListViewItem item)
        {
            foreach (DirectoryInfo dir in directories)
            {
                if (dir.Name == item.Text)
                {
                    return dir;
                }
            }
            return null;
        }

        private FileInfo getFileFromItem(ListViewItem item)
        {
            foreach (FileInfo file in files)
            {
                if (file.Name == item.Text)
                {
                    return file;
                }
            }
            return null;
        }

        public void delete()
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                DirectoryInfo dir = getDirectoryFromItem(item);
                FileInfo file = getFileFromItem(item);
                if (dir != null)
                {
                    dir.Delete();
                }
                else if (file != null) {
                    file.Delete();
                }
            }
            refresh();
        }

        bool isFile(ListViewItem item)
        {
            foreach(FileInfo file in files)
            {
                if (file.Name == item.Text)
                {
                    return true;
                }
            }
            return false;
        }
       

        public void copy(string destination, string name)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                if (isFile(item))
                {
                    FileInfo file = getFileFromItem(item);
                    if (file != null)
                    {
                        try
                        {
                            if (name == null)
                            {
                                name = file.Name;
                            }
                            file.CopyTo(destination + "\\" + name);
                        }
                        catch
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    DirectoryInfo dir = getDirectoryFromItem(item);
                    if (dir != null)
                    {
                        recursiveCopy(dir, destination);
                    }
                }
                
            }
        }

        private void recursiveCopy(DirectoryInfo dir, string path)
        {
            Directory.CreateDirectory(path + "\\" + dir.Name);
            foreach(DirectoryInfo d in dir.GetDirectories())
            {
               
                recursiveCopy(d, path + "\\" + d.Name);
                
            }
            foreach(FileInfo f in dir.GetFiles())
            {
                try
                {
                    f.CopyTo(path + "\\" + f.Name);
                }
                catch
                {
                    throw;
                }
                
            }
        }

        public void delete(string destination)
        {
            foreach(ListViewItem item in listView.SelectedItems)
            {
                FileInfo file = getFileFromItem(item);
                file.Delete();
            }
        }

        public void copy(string destination)
        {
            copy(destination, null);
        }

        public void compress(string destination)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                //Console.WriteLine(item.Text);
                compressor.CompressFile(getPathFromName(item.Text), destination);

            }
            refresh();
        }

        public void deCompress(string destination)
        {
            foreach (ListViewItem item in listView.SelectedItems)
            {
                compressor.DecompressFile(getPathFromName(item.Text), destination);
            }
            refresh();
           
        }

        public string getPathFromName(string name)
        {
            foreach (FileInfo file in files)
            {
                if (file.Name == name)
                {
                    return file.FullName;
                }
            }
            return null;
        }

        private DirectoryInfo[] getDirectories(string path)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(path);
                return di.GetDirectories();
            }
            catch
            {
                MessageBox.Show("Error");
                return new DirectoryInfo[0];
            }
            
            
        }


        private FileInfo[] getFiles(string path)
        {
            try {
                DirectoryInfo di = new DirectoryInfo(path);
                return di.GetFiles();
            }
            catch
            {
                return new FileInfo[0];
            }
            
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

        public void enCrypt(string destination, string key)
        {
            
            foreach(ListViewItem item in listView.SelectedItems)
            {
                FileInfo file = getFileFromItem(item);
                string inputFile = file.FullName;
                string outName = file.FullName.Remove(file.FullName.Length - file.Extension.Length) + ".crypt";
                //MessageBox.Show(outName);
                string outputFile = destination + "\\" + getFileFromItem(item).Name;
                crypt(inputFile, outputFile, key);
            }                       
        }

        public void deCrypt(string destination, string key)
        {
            foreach(ListViewItem item in listView.SelectedItems)
            {
                FileInfo file = getFileFromItem(item);
                string inputFile = file.FullName;
                string outName = file.FullName.Remove(file.FullName.Length - file.Extension.Length) + ".crypt";
                //MessageBox.Show(outName);
                string outputFile = destination + "\\" + getFileFromItem(item).Name;
                deCrypt(inputFile, outputFile, key);
            }
        }

        private void crypt(string inputFile, string outputFile, string cryptKey)
        {
            try
            {
                string password = cryptKey;
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch (CryptographicException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Encryption failed!", "Error");
            }
        }

        private void deCrypt(string inputFile, string outputFile, string cryptKey)
        {

            {
                string password = @cryptKey; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
        }
    }
}
