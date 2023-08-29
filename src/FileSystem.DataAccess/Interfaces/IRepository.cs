using FileSystem.Domain.Entities;
using FileSystem.Domain.Entities.Files;

namespace FileSystem.DataAccess.Interfaces;

public interface IRepository
{
    public Task<int> IFileSaveAsync(FileEntity file);
}
