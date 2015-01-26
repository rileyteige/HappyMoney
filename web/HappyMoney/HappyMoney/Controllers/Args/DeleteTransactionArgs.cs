using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyMoney.Controllers.Args
{
	public class DeleteTransactionArgs
	{
		public DeleteTransactionArgs()
		{
		}

		public Guid TransactionGuid { get; set; }
	}
}