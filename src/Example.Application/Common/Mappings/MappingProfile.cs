namespace Example.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var methodInfo = type.GetMethod(nameof(IMapFrom<object>.Mapping))
                ?? type.GetInterface("IMapFrom`1")!.GetMethod(nameof(IMapFrom<object>.Mapping));

            methodInfo?.Invoke(null, new object[] { this });
        }
    }
}