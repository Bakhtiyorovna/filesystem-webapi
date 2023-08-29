using FileSystem.Service.Common.Helpers;
using FileSystem.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FileSystem.Service.Services.Files;

public class FileService:IFileService
{
    private readonly string FILES = "files";
    private readonly string ROOTPATH;
    private readonly string _filesPath;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<List<string>> GetAllAsync()
    {
        string _filesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

        var imagePaths = Directory.GetFiles(_filesPath, "*.*")
                        .Select(imagePath => imagePath.Replace(_filesPath, "wwwroot"))
                        .ToList();

        return await Task.FromResult(imagePaths);
    }

    public async Task<bool> DeleteFileAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });

            return true;
        }
        else return false;
    }

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        string newfileName = MediaHelper.MakeFileName(file.FileName);
        string subpath = Path.Combine(FILES);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await file.CopyToAsync(stream);
        stream.Close();

        return subpath;

        //if (file == null || file.Length == 0)
        //    return 0;
        //else
        //{
        //    string fileName = Path.GetFileName(file.FileName);
        //    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "files", fileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return 1;
        //}
    }
}
