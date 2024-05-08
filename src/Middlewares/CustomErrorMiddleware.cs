
using System.Data.Common;
using BackendTeamwork.Exceptions;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BackendTeamwork.Middlewares
{
    public class CustomErrorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

            }

            catch (CustomErrorException e)
            {
                context.Response.StatusCode = e.StatusCode;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.Message);
                Console.WriteLine("Custom Exception");
            }

            catch (DbUpdateException e)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.InnerException.Message);
                Console.WriteLine("Database Exception");

                // Logging
                //await File.AppendAllTextAsync("./Logs/DatabaseLogger.txt", $"{DateTime.Now} - {e.InnerException.Message} \n\n");
            }

            catch (Exception e)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(e.Message);
                Console.WriteLine(e);
            }
        }
    }
}