using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace fileMovementProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string filePickUp = ConfigurationManager.AppSettings["filePickUp"];
                string fileDropoff = ConfigurationManager.AppSettings["fileDropoff"];
                
                List<String> MyFiles = Directory
                       .GetFiles(filePickUp, "*.*").ToList();

                foreach (string file in MyFiles)
                {
                    FileInfo mFile = new FileInfo(file);
                    // to remove name collisions
                    if (mFile.Name.Contains("Print") == true)
                    {
                        mFile.MoveTo(fileDropoff + "\\" + mFile.Name);
                        Console.WriteLine("File transferred");
                    }

                    }
                

               
            }
        }
    }
}
