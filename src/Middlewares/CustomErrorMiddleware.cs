
using BackendTeamwork.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            /*
                exceptions to handle: 
                1- DbUpdateException
                2- DbUpdateConcurrencyException
                3- InvalidDataException
                4- EntityNotFoundException
                5- UnauthorizedAccessException
                */
            catch (CustomErrorException e)
            {
                // throw and test
                context.Response.StatusCode = e.StatusCode;
                context.Response.ContentType = "text/plain";
                Console.WriteLine($"Error Log: {e.Message}");

            }

            catch (DbUpdateException e)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Something went wrong in the database ...");
                //await context.Response.WriteAsJsonAsync("JSON format"); // dont need to specify contentType
                Console.WriteLine($"Error Log: {e.Message}");

            }
            // generic exceptioin
            catch (Exception e)
            {
                Console.WriteLine($"Something went wrong.. {e.Message}");
            }
        }
    }
}