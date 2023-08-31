using FileSystem.Application.Exeptions;
using System.Runtime.CompilerServices;

namespace FileSystem.Service.Exeptions.Files;

public class RootpathNotFoundExeption : NotFoundExeption
{
    public RootpathNotFoundExeption()
    {
        TitleMessage = "ROOTPATH is null";
    }
}
