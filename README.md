# Steps to reproduce 

- Start the `IntegrationTestingIssueRepro.Api` project so the host is listening at `http://localhost:5000/`
- Run the `IntegrationTestingIssueRepro.IntegrationTests` integration tests.
- The test which uses the real `HttpClient` passes while the test using the `HttpClient` created from the `WebApplicationFactory` fails.

# Expectation

The `HttpReponse`'s `RequestMessage.Content` to not be empty.

# Investigation

I suspect the issue is due to these lines of code as skipping the `if` branch and executing the `else` branch causes the tests to pass.

https://github.com/dotnet/aspnetcore/blob/4161f16141a984ff7e4faaebe0ebe8623a3a178f/src/Hosting/TestHost/src/ClientHandler.cs#L88C0-L100C18
