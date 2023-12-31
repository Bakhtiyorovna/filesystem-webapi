﻿using System.Net;

namespace FileSystem.Application.Exeptions;

public class BadRequestExeption : ClientExeption
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
    public override string TitleMessage { get; protected set; } = String.Empty;
}