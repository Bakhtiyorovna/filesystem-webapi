using FileSystem.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileSystem.WebApi.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService _fileService)
        {
            this._fileService = _fileService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> FileGetAllAsync() 
            => Ok(await _fileService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> FileCreateAsync(IFormFile file)
            => Ok(await _fileService.UploadImageAsync(file));

        [HttpDelete]
        public async Task<IActionResult> FileDeleteAsync(string filePath)
            => Ok(await _fileService.DeleteFileAsync(filePath));


        [HttpGet("fileName")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            try
            {
                var fileStream = await _fileService.GetFileStreamAsync(fileName);

                if (fileStream == null)
                {
                    return NotFound(); // Return 404 if the file doesn't exist
                }

                return File(fileStream, "application/octet-stream"); // Return the file as a stream
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return StatusCode(500, "An error occurred while retrieving the file.");
            }
        }
    }
}
