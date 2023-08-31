using System.Net;

namespace FileSystem.Application.Exeptions;

public abstract class ClientExeption : Exception
{
    public abstract HttpStatusCode StatusCode { get; }
    public abstract string TitleMessage { get; protected set; }
}