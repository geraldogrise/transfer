using BR.ITAU.TRANSFER.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva;

namespace BR.ITAU.TRANSFER.Infra.Data.Mappings
{

    public class CurvaMap : MappingCore<Curva>
    {
        public override void Map(EntityTypeBuilder<Curva> builder)
        {
            builder.ToTable("DB2CAS.TBIMCRV0");
            builder.HasKey(x => x.CodigoCurva);
			builder.Property(x => x.CodigoCurva).HasColumnName(@"COD_CURV").IsRequired().HasColumnType("int");
			builder.Property(x => x.NomeCurva).HasColumnName(@"NOM_CURV").IsRequired().HasColumnType("char(80)").HasMaxLength(80);
            base.Map(builder);
        }
    }
}