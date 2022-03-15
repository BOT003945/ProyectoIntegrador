using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace PetServiceBlazor.Data.Auth;

public class AuthStateProviderFalse : AuthenticationStateProvider{
    public async override Task<AuthenticationState>GetAuthenticationStateAsync()
    {
        await Task.Delay(3000);
        var identity = new ClaimsIdentity();
        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
    }
}