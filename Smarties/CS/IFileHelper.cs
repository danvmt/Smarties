using System;
namespace Smarties
{
    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
        void DeleteFile(string filename);
    }
}
