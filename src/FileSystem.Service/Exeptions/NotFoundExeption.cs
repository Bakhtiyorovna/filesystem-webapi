using FileSystem.Application.Exeptions;
using System.Net;

namespace FileSystem.Application.Exeptions;

public class NotFoundExeption : ClientExeption
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
    public override string TitleMessage { get; protected set; } = string.Empty;
}