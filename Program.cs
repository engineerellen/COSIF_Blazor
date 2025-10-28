using Microsoft.AspNetCore.Components.Server.Circuits;

var builder = WebApplication.CreateBuilder(args);

// ... existing registrations
    
// Preferred: enable detailed circuit errors for development
builder.Services.AddServerSideBlazor()
       .AddCircuitOptions(options =>
       {
           options.DetailedErrors = true;
       });

var app = builder.Build();

// ... app.UseRouting(), endpoints, etc.

app.Run();