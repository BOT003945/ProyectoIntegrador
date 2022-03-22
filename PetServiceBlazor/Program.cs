using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PetServiceBlazor.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<ValidateTokenHandler>();
//builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProviderFalse>();
// builder.Services.AddSingleton<ValidateTokenHandler>();

var clientHandler = new HttpClientHandler();
clientHandler.ServerCertificateCustomValidationCallback =
    (message, cert, chain, errors) => true;
var http = new HttpClient(clientHandler){
    BaseAddress = new Uri("http://localhost:5195")
};

builder.Services.AddSingleton(http);
//builder.Services.AddSingleton(app);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
