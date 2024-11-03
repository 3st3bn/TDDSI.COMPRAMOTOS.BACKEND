using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.Primitives;
using TDDSI.COMPRAMOTOS.BACKEND.Domain.WeatherForecastsHistories;

namespace TDDSI.COMPRAMOTOS.BACKEND.Infrastructure.PostgreSql.Configurations;
internal class WeatherForecastsHistoryConfigurations
    : IEntityTypeConfiguration<WeatherForecastsHistory> {
    public void Configure( EntityTypeBuilder<WeatherForecastsHistory> builder ) {
        builder.ToTable( "WeatherForecastsHistories" );
        builder.HasKey( property => property.Id );
        builder.Property( property => property.Proccess );
        builder.Property( property => property.Enabled );
        builder.Property( property => property.CreatedDate );
        builder.Property( property => property.CreatedByUser );
        builder.Property( property => property.LastModifiedDate );
        builder.Property( property => property.LastModifiedByUser );
    }
}
