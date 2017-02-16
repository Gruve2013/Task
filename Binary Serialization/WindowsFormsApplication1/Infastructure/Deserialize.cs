using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace BinarySerialization
{
   public static class Deserialize
    {
      
        public static void CreateFolder(string root, Folder folder)
        {
            DirectoryInfo mainFolder = new DirectoryInfo(root + @"\" + folder.Name);
            mainFolder.Create();
            CreateFiles(mainFolder, folder.Files);
            CreateSubFolders(mainFolder,folder.SubFolders);
        }
        public static void CreateFiles(DirectoryInfo root, File[] files)
        {
            foreach (File file in files)
            {
                System.IO.File.WriteAllBytes(root.FullName + @"\" + file.Name, file.Data);
            }
        }

        public static void CreateSubFolders(DirectoryInfo dir, Folder[] folders)
        {
            foreach (Folder folder in folders)
            {
                DirectoryInfo subFoulder = dir.CreateSubdirectory(folder.Name);
                CreateFiles(subFoulder, folder.Files);
                CreateSubFolders(subFoulder, folder.SubFolders);
            }
        }
    }
}
