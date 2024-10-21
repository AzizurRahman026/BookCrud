using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using System.Text;

namespace BookCrudTest
{
    public class NameFormattingMiddleware
    {
        private readonly RequestDelegate _next;

        public NameFormattingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Process Request: Capitalize the first letter of 'name'
            if (context.Request.Method == HttpMethods.Post && context.Request.Path == "/name")
            {
                context.Request.EnableBuffering();
                var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
                context.Request.Body.Position = 0;

                if (!string.IsNullOrEmpty(body))
                {
                    var json = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
                    if (json != null && json.ContainsKey("name"))
                    {
                        json["name"] = char.ToUpper(json["name"][0]) + json["name"][1..];
                        var updatedBody = JsonSerializer.Serialize(json);
                        context.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(updatedBody));
                    }

                    Console.WriteLine("\n\nMiddleware...\n\n");
                }
                


                _next(context); // Call the next middleware or controller

                var responseText = await new StreamReader(___).ReadToEndAsync();

                if (!string.IsNullOrEmpty(...))
                {
                    ... = char.ToLower(...[0]) + ...[1..];
                }
                
                await context.Response.WriteAsync(responseText);
                // await context.Response.WriteAsync("hello");

            }

            await _next(context);
        }
    }
}
