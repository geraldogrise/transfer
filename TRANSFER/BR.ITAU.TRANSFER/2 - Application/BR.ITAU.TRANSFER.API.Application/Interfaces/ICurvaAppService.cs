using BR.ITAU.TRANSFER.API.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BR.ITAU.TRANSFER.API.Application.Interfaces
{
    public interface ICurvaAppService : IDisposable
    {
		
		public void InserirCurva(CurvaModel curva);

		public void AtualizarCurva(CurvaModel curva);

		public void DeletarCurva(int codigoCurva);

		public CurvaModel ObterCurva(int codigoCurva);

		public List<CurvaModel> ListarCurva();

    }
}