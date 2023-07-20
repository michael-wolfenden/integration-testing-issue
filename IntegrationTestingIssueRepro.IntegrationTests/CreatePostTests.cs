using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace IntegrationTestingIssueRepro.IntegrationTests;

public class CreatePostTests
{
    [Fact]
    public async Task CanCreateAPostViaWebApplicationFactoryHttpClient()
    {
        await using var factory = new WebApplicationFactory<Program>();

        var response = await factory.CreateClient().PostAsJsonAsync(
            "/",
            new CreatePostRequest("some message"));

        var responseContents = await response.Content.ReadAsStringAsync();
        Assert.Equal("Received some message", responseContents);
        
        var requestContents = await response.RequestMessage.Content.ReadAsStringAsync();
        Assert.Equal("""{"message":"some message"}""", requestContents);
    }
    
    [Fact]
    public async Task CanCreateAPostViaHttpClient()
    {
        var response = await new HttpClient().PostAsJsonAsync(
            "http://localhost:5000/",
            new CreatePostRequest("some message"));

        var responseContents = await response.Content.ReadAsStringAsync();
        Assert.Equal("Received some message", responseContents);

        var requestContents = await response.RequestMessage.Content.ReadAsStringAsync();
        Assert.Equal("""{"message":"some message"}""", requestContents);
    }
}
