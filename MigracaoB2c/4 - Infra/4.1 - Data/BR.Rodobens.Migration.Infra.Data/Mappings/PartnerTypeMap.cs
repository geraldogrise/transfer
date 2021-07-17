using BR.Rodobens.Migration.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BR.Rodobens.Migration.Domain.Aggregates.Users.PartnerType;
using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;

namespace BR.Rodobens.Migration.Infra.Data.Mappings
{
    public class PartnerTypeMap : MappingCore<PartnerType>
    {
        public override void Map(EntityTypeBuilder<PartnerType> builder)
        {
            builder.ToTable("m2n_cadastros_parceiros_tipos");
            builder.HasKey(x => x.PartnerTypeId);
            builder.Property(x => x.PartnerTypeId).HasColumnName(@"pti_id").IsRequired().HasColumnType("int").HasMaxLength(11);
            builder.Property(x => x.Name).HasColumnName(@"pti_nome").IsRequired().IsUnicode(false).HasColumnType("varchar(45)").HasMaxLength(45);
            builder.Property(x => x.Category).HasColumnName(@"pti_categoria").IsRequired().HasColumnType("varchar(3)").HasMaxLength(3);
            base.Map(builder);
        }
    }
}
