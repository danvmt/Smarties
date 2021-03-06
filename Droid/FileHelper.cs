﻿using System;
using System.IO;
using Smarties.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Smarties.Droid
{
    public class FileHelper : IFileHelper
    {
        public void DeleteFile(string filename)
        {
            string path = GetLocalFilePath(filename);
            File.Delete(path);
        }

        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}
