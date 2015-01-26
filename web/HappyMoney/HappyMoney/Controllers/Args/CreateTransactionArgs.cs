using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyMoney.Controllers.Args
{
	public class CreateTransactionArgs
	{
		public CreateTransactionArgs()
		{
		}

		public Guid AccountGuid { get; set; }
		public string Payee { get; set; }
		public double Total { get; set; }
	}
}