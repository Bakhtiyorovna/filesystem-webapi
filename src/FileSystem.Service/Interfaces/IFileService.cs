using Microsoft.AspNetCore.Http;

namespace FileSystem.Service.Interfaces;

public interface IFileService
{
    public Task<List<string>> GetAllAsync();
    public Task<bool> DeleteFileAsync(string subpath);
    public Task<string> UploadImageAsync(IFormFile file);
}
