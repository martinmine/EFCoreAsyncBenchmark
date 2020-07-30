# About

This repository demonstrates the performance difference between the async and blocking API in EntityFramework Core under high load against Microsoft SQL Server.

# Setup

1. Create the test database using the T-SQL script `Datbase.sql` on your local machine.
2. Install [Artillery](https://artillery.io/) by running `npm install -g artillery`
3. Start the project: `dotnet run --project .\EFCoreAsyncBenchmark\EFCoreAsyncBenchmark.csproj` 
4. Run load test using async or blocking by running `artillery run .\LoadTests.Async.yml` or `artillery run .\LoadTests.Blocking.yml` The tests will show that with the async test, the response times will be 2x as high compared to the tests for blocking APIs (depending on the systems it can also be 1.5x as high). It can also be seen that the service will use significantly more CPU during the async test.