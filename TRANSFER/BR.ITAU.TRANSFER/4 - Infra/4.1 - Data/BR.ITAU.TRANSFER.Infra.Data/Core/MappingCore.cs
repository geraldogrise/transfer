using BR.ITAU.TRANSFER.API.Domain.Aggregates.Core;
using BR.ITAU.TRANSFER.Infra.Data.Core.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.ITAU.TRANSFER.Infra.Data.Core
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
