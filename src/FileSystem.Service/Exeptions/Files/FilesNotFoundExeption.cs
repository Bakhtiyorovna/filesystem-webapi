using FileSystem.Application.Exeptions;

namespace HeavyService.Application.Exeptions.Files;

public class FilesNotFoundExeption : BadRequestExeption
{
    public FilesNotFoundExeption()
    {
        this.TitleMessage = "SUBPATH is null";
    }
}