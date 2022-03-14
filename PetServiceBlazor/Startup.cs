using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using PetServiceBlazor.Data.Auth;

namespace PetServiceBlazor;
public class Startup{
    public void ConfigureServices(IServiceCollection services){
        services.AddAuthorizationCore();
        services.AddScoped<AuthenticationStateProvider, AuthStateProviderFalse>();
    }
    public void Configure(IComponentsApplicationBuilder app){
        app.AddComponent<App>("app");
    }
}
