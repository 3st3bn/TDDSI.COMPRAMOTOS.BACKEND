using Microsoft.Extensions.DependencyInjection;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.DomainService;

namespace TDDSI.COMPRAMOTOS.BACKEND.Application.Extensions;
public static class DomainServiceDependencyInjection {
    public static IServiceCollection AddDomainService( this IServiceCollection service ) {
        var _services = AppDomain.CurrentDomain.GetAssemblies()
            .Where( assembly => {
                return assembly.FullName is not null && assembly.FullName.Contains( "TDDSI.COMPRAMOTOS.BACKEND.Domain", StringComparison.InvariantCulture );
            } )
            .SelectMany( assemby => assemby.GetTypes() )
            .Where( type => type.CustomAttributes.Any( customAttribute => customAttribute.AttributeType == typeof( DomainServiceAttribute ) ) );

        foreach (var _service in _services) {
            service.AddScoped( _service );
        }

        return service;
    }
}
