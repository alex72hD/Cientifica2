using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cientifica.WEB;
using Cientifica.WEB.Repositories;
using SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7000/") });
builder.Services.AddSweetAlert2();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();   

await builder.Build().RunAsync();
