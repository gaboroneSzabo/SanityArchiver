using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanityArchiver
{
    public class Compress
    {
        public void CompressFile(string path, string destination)
        {
            FileStream sourceFile = File.OpenRead(path);
            string fileName = path.Split('\\').Last();
            FileStream destinationFile = File.Create(destination + " \\" + fileName + ".gz");

            byte[] buffer = new byte[sourceFile.Length];
            sourceFile.Read(buffer, 0, buffer.Length);

            using (GZipStream output = new GZipStream(destinationFile,
                CompressionMode.Compress))
            {
                Console.WriteLine("Compressing {0} to {1}.", sourceFile.Name,
                    destinationFile.Name, false);

                output.Write(buffer, 0, buffer.Length);
            }

            // Close the files.
            sourceFile.Close();
            destinationFile.Close();
        }

        public void DecompressFile(string path, string destination)
        {
            FileStream sourceFile = File.OpenRead(path);
 
            string fileName = path.Remove(path.Length - 3).Split('\\').Last();
            FileStream destinationFile = File.Create(destination + "\\" + fileName);

            using (GZipStream output = new GZipStream(sourceFile,
                CompressionMode.Decompress))
            {

                output.CopyTo(destinationFile);
            }

            // Close the files.
            sourceFile.Close();
            destinationFile.Close();
        }

    }
}
