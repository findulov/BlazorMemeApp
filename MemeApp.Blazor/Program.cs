using MemeApp.Blazor;
using MemeApp.Blazor.Common.Services;
using MemeApp.Blazor.Common.State;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IMemeApiService, MemeApiService>(); 
builder.Services.AddScoped<StateContainer>();

await builder.Build().RunAsync();
