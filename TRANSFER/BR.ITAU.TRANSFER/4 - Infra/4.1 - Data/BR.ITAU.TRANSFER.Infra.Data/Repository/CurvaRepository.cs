using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva;
using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Repository;
using BR.ITAU.TRANSFER.Infra.Data.Context;
using BR.ITAU.TRANSFER.Infra.Data.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BR.ITAU.TRANSFER.Infra.Data.Repository
{
    public class CurvaRepository : Repository<Curva>, ICurvaRepository
    {
        public CurvaRepository(DatabaseContext context) : base(context)
        {

        }
		
    }
}