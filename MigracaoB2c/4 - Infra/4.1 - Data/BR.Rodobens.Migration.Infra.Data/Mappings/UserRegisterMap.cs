using BR.Rodobens.Migration.Domain.Aggregates.Users.UserRegister;
using BR.Rodobens.Migration.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.Rodobens.Migration.Infra.Data.Mappings
{
    public class UserRegisterMap : MappingCore<UserRegister>
    {
        public override void Map(EntityTypeBuilder<UserRegister> builder)
        {
            builder.ToTable("m2n_cadastros");
            builder.HasKey(x => x.UserRegisterId);
            builder.Property(x => x.UserRegisterId).HasColumnName(@"cad_id").IsRequired().HasColumnType("int").HasMaxLength(11);
            builder.Property(x => x.Login).HasColumnName(@"cad_usuario").IsRequired().IsUnicode(false).HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(x => x.PartnerTypeId).HasColumnName(@"cad_idtipo").IsRequired().HasColumnType("int").HasMaxLength(6);
            builder.HasOne(x => x.PartnerType).WithMany(y => y.UserRegisterList).HasForeignKey(x => x.PartnerTypeId);
            base.Map(builder);
        }
    }
}
