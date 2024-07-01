using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace CVBASESWISS.Model
{
    public static class P_Directory
    {
        static string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static readonly string appFolder = Path.Combine(folder, "CVBase");
        static string filename = "CVBase.cfg";
        public readonly static string file = Path.Combine(appFolder, filename);

        public static string CheckRepository()
        {
            if (!Directory.Exists(appFolder)) Directory.CreateDirectory(appFolder);
            //return new AppConfig() { Folder = appFolder, Filename = filename};
            if (System.IO.Directory.GetFiles(appFolder, filename).Length == 0)
            {
                System.IO.File.Create(file).Close();
            }
            
            return System.IO.File.ReadLines(file).FirstOrDefault();
        }
    }
}
