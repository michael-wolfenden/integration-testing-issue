var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/", (CreatePostRequest request) => $"Received {request.Message}");
app.Run();

public record CreatePostRequest(string Message);

public partial class Program { }