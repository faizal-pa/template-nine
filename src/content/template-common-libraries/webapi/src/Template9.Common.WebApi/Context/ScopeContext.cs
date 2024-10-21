using Microsoft.AspNetCore.Http;
using Template9.Common.Abstractions;

namespace Template9.Common.WebApi.Context;

public class ScopeContext : IScopeContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ScopeContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
}
