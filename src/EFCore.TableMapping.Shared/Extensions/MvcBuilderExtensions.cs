namespace EFCore.TableMapping.Shared.Extensions;

public static class MvcBuilderExtensions
{
    public static IMvcBuilder AddSharedApplicationPart(this IMvcBuilder builder)
    {
        builder.AddApplicationPart(typeof(MvcBuilderExtensions).Assembly);

        return builder;
    }
}
