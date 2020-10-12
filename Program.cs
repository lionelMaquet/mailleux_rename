using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace mailleux_rename
{
    class Program
    {
        static void Main(string[] args)
        {
            string mainPath = args[0];
            string[] subdirectories = Directory.GetDirectories(mainPath);
            string prepend = args[1];

            foreach (string directory in subdirectories)
            {
                var dir = new DirectoryInfo(directory);
                var dirName = dir.Name;
                string[] files = Directory.GetFiles(directory);
                Console.WriteLine(dirName);
                foreach (string filename in files)
                {

                    var fileInfo = new FileInfo(filename);
                    var filenameShort = fileInfo.Name;
                    

                    string oldFileName = filename;

                    //picto
                    if (filename.EndsWith("p.jpg"))
                    {
                        string newFileName = $"{directory}\\{prepend}-{dirName}-picto.jpg";
                        System.IO.File.Move(oldFileName, newFileName);
                    }

                    else 
                    {
                        string newFileName = $"{directory}\\{prepend}-{dirName}-photo-0{filenameShort}";
                        System.IO.File.Move(oldFileName, newFileName);
                    }
                }
            }
        }
    }
}
