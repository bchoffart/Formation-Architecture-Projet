using System;
using System.Linq;
using System.Threading.Tasks;
using GestionHotel.Apis2.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomAuthorizationAttribute : Attribute, IAsyncAuthorizationFilter
{
    private readonly UserRole[] _roles;

    public CustomAuthorizationAttribute(params UserRole[] roles)
    {
        _roles = roles;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        string token = context.HttpContext.Request.Query["token"]!;
        if (Enum.TryParse<UserRole>(token, out var convertedRole) == false)
        {
            context.Result = new UnprocessableEntityResult();
            return;
        };
        if (_roles.Length == 0 || !_roles.ToList().Contains(convertedRole))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        await Task.CompletedTask;
        
    }
}