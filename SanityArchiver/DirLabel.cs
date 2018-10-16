using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver
{
    public class DirLabel : System.Windows.Forms.Label
    {
        private DirectoryInfo dir;

        public DirectoryInfo Directory { get; set; }

        public DirLabel(DirectoryInfo dir)
        {
            this.dir = dir;
        }
    }
}
