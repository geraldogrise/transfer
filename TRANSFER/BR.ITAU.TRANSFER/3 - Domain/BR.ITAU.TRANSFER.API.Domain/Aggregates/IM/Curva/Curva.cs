namespace BR.ITAU.TRANSFER.API.Domain.Aggregates.IM.Curva
{
	using System.Collections.Generic;
	using BR.ITAU.TRANSFER.API.Domain.Aggregates.Core;
	
	public class Curva : EntityCore<Curva>
	{  
	    
		public int CodigoCurva { get; set; }
		
		public string NomeCurva { get; set; }
		
		#region Validations
		public bool IsValid()
		{
			return base.IsValid(this);
		}
		#endregion
	}
}