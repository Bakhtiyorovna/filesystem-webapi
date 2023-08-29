using Microsoft.AspNetCore.Http;

namespace FileSystem.Service.Dtos;

public class FileCreateDto
{
    public IFormFile file { get; set; } = default!;
}
