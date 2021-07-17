using BR.Rodobens.Migration.Domain.Aggregates.Core;
using BR.Rodobens.Migration.Infra.Data.Core.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BR.Rodobens.Migration.Infra.Data.Core
{
    public class MappingCore<T> : EntityTypeConfiguration<T> where T : EntityCore<T>
    {
        public override void Map(EntityTypeBuilder<T> builder)
        {
            builder.Ignore(x => x.CascadeMode);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}
