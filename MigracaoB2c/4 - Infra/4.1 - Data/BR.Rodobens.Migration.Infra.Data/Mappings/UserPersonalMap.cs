using BR.Rodobens.Migration.Domain.Aggregates.Users.UserPersonal;
using BR.Rodobens.Migration.Infra.Data.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BR.Rodobens.Migration.Infra.Data.Mappings
{
    public class UserPersonalMap : MappingCore<UserPersonal>
    {
        public override void Map(EntityTypeBuilder<UserPersonal> builder)
        {
            builder.ToTable("m2n_cadastros_pessoais");
            builder.HasKey(x => x.UserPersonalId);
            builder.Property(x => x.UserPersonalId).HasColumnName(@"pes_id").IsRequired().HasColumnType("int").HasMaxLength(11);
            builder.Property(x => x.Name).HasColumnName(@"pes_nome").IsUnicode(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.Email).HasColumnName(@"pes_email").IsRequired().IsUnicode(false).HasColumnType("varchar(255)").HasMaxLength(255);
            builder.Property(x => x.Cpf).HasColumnName(@"pes_cpf").IsUnicode(false).HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(x => x.Cnpj).HasColumnName(@"pes_cnpj").IsUnicode(false).HasColumnType("varchar(18)").HasMaxLength(18);
            builder.Property(x => x.UserRegisterId).HasColumnName(@"pes_idcadastro").IsRequired().HasColumnType("int").HasMaxLength(11);
            builder.HasOne(x => x.UserRegister).WithMany(y => y.UserPersonalList).HasForeignKey(x => x.UserRegisterId);
            builder.Property(x => x.Processado).HasColumnName(@"pes_migrado").IsRequired().HasColumnType("bit");
            base.Map(builder);
        }
    }
}
