﻿using FileSystem.Service.Common.Helpers;
using FileSystem.Service.Exeptions.Files;
using FileSystem.Service.Interfaces;
using FileSystem.Service.ViewModel;
using HeavyService.Application.Exeptions.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FileSystem.Service.Services.Files;

public class FileService : IFileService
{
    private readonly string FILES = "files";
    private readonly string ROOTPATH;

    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }

    public async Task<List<FileViewModel>> GetAllAsync()
    {
        string _filesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files");

        List<FileViewModel> list = new List<FileViewModel>();

        var imagePaths = Directory.GetFiles(_filesPath, "*.*")
                        .Select(imagePath => Path.GetFileName(imagePath));
       


        foreach (var item in imagePaths)
        { 
            FileViewModel fileViewModel = new FileViewModel();
            fileViewModel.fileName = item;
            list.Add(fileViewModel);

        }


        return await Task.FromResult(list);
    }

    public async Task<bool> DeleteFileAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, "files\\"+subpath);
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

    //public async Task<string> UploadImageAsync(IFormFile file)
    //{
    //    if (FILES == null)
    //    {
    //        throw new FilesNotFoundExeption();
    //    }

    //    if (ROOTPATH == null)
    //    {
    //        throw new RootpathNotFoundExeption();
    //    }

    //    string newfileName = MediaHelper.MakeFileName(file.Name);
    //    string subpath = Path.Combine(FILES,newfileName);
    //    string path = Path.Combine(ROOTPATH, subpath);

    //    var stream = new FileStream(path, FileMode.Create);
    //    await file.CopyToAsync(stream);
    //    stream.Close();

    //    return subpath;

    //}

    public async Task<string> UploadImageAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new ArgumentException("Invalid file");
        }

        if (FILES == null)
        {
            throw new FilesNotFoundExeption();
        }

        if (ROOTPATH == null)
        {
            throw new RootpathNotFoundExeption();
        }

        string originalFileName = file.FileName;
        string fileExtension = Path.GetExtension(originalFileName); // Get the file extension

        string newFileName = MediaHelper.MakeFileName(originalFileName) + fileExtension;
        string subpath = Path.Combine(FILES, newFileName);
        string path = Path.Combine(ROOTPATH, subpath);

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return subpath;
    }


    public async Task<Stream> GetFileStreamAsync(string fileName)
    {
        string filePath = Path.Combine(ROOTPATH, FILES, fileName);

        if (File.Exists(filePath))
        {
            return new FileStream(filePath, FileMode.Open, FileAccess.Read);
        }

        return null; // Return null if the file doesn't exist
    }
}
