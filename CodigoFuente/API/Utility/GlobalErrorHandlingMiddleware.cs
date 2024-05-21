﻿using Microsoft.AspNetCore.Http;
using rsFoodtrucks.Exceptions;
//using rsFoodtrucks.Models;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using KeyNotFoundException = rsFoodtrucks.Exceptions.KeyNotFoundException;
using NotImplementedException = rsFoodtrucks.Exceptions.NotImplementedException;
using UnauthorizedAccessException = rsFoodtrucks.Exceptions.UnauthorizedAccessException;

namespace rsAPIElevador.Utility
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            
            var stackTrace = String.Empty;
            string message;

            var exceptionType = exception.GetType();
            if (exceptionType == typeof(BadRequestException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotFoundException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                status = HttpStatusCode.Unauthorized;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else if (exceptionType == typeof(ArgumentNullException))
            {
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }
            else
            {
                //status = HttpStatusCode.InternalServerError;
                status = HttpStatusCode.BadRequest;
                message = exception.Message;
                stackTrace = exception.StackTrace;
            }

            //ServiceResponse<PagedResponse<Object>> sr = new ServiceResponse<PagedResponse<Object>>(null);
            //sr.setError(message);
            //var exceptionResult = JsonSerializer.Serialize(sr);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            //return context.Response.WriteAsync(exceptionResult);
            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace, exception.InnerException });
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
