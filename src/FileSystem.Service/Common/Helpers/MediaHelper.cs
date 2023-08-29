namespace FileSystem.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeFileName(string filename)
    {
        FileInfo fileInfo = new FileInfo(filename);
        string extension = fileInfo.Extension;
        string name = "File_" + Guid.NewGuid() + extension;
        return name;
    }

    //public static string[] GetImageExtensions()
    //{
    //    return new string[]
    //    {
    //        //".jpg", ".jpeg", ".png", ".gif", ".bmp", ".heic"
    //    };
    //}
}
