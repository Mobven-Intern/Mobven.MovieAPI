﻿using System.Net;

namespace MovieAPI;

public class BaseException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
