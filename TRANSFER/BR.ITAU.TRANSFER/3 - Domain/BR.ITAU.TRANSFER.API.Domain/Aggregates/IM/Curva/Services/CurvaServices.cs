using BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Repository;
using BR.ITAU.TRANSFER.API.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva.Services
{
    public class CurvaService : Service, ICurvaService
    {

        private readonly ICurvaRepository _curvaRepository;

        public CurvaService(IMediator mediator,
                              ICurvaRepository curvaRepository
                              ) : base(mediator)
        {
            _curvaRepository = curvaRepository;
        }
        
		public void InserirCurva(Curva curva)
		{
			_curvaRepository.Add(curva);
			_curvaRepository.SaveChanges();
		}

		public void AtualizarCurva(Curva curva)
		{
			_curvaRepository.Update(curva);
			_curvaRepository.SaveChanges();
		}

		public void DeletarCurva(int codigoCurva)
		{
			_curvaRepository.Remove(codigoCurva);
			_curvaRepository.SaveChanges();
		}

		public Curva ObterCurva(int codigoCurva)
		{
			 return _curvaRepository.Find(x => x.CodigoCurva == codigoCurva).FirstOrDefault();
		}

		public List<Curva> ListarCurva()
		{
			 return _curvaRepository.GetAll().ToList();
		}

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _curvaRepository.Dispose();
        }

    }
}