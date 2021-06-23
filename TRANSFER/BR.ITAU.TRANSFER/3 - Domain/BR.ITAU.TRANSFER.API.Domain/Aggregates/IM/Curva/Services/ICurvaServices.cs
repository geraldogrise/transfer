using System;
using System.Collections.Generic;
using System.Text;

namespace BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Services
{
    public interface ICurvaService : IDisposable
    {
        
		public void InserirCurva(Curva curva);

		public void AtualizarCurva(Curva curva);

		public void DeletarCurva(int codigoCurva);

		public Curva ObterCurva(int codigoCurva);

		public List<Curva> ListarCurva();

    }
}
