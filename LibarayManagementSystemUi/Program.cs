using LibraryManagementSystemUi.Services;
using LibraryManagementSystemUi;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7250") });
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<MemberService>();
builder.Services.AddScoped<BookService>();


await builder.Build().RunAsync();
