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

		public int AccountId { get; set; }
		public DateTime EventDate { get; set; }
		public string Payee { get; set; }
		public double Total { get; set; }
	}
}