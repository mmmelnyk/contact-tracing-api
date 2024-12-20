namespace Shared.Configuration;

public static class ServiceConstants
{
    public const string Name = "tracing";
    public const string RoutePrefix = Name + "/" + "v{version:apiVersion}/[controller]";
}