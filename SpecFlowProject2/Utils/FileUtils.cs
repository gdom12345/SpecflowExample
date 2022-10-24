﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Utils
{
    internal class FileUtils
    {
        public static string getResourceFile(String resourcePath)
        {
            if (!resourcePath.StartsWith("\\"))
            {
                resourcePath = "\\" + resourcePath;
            }
      
            string fileData = File.ReadAllText(getResourcesFolder() + resourcePath);
            return fileData;
        }

        public static String getResourcesFolder()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string sourceDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            return sourceDirectory + "\\Resources";
        }

    }
}
