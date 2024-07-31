using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages(); // Add this line to register Razor Pages services
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 102400000;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapRazorPages(); // Ensure Razor Pages routing is set up
app.MapFallbackToPage("/_Host");

app.Run();
