using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyMoney.Controllers.Args
{
	public class CreateEnvelopeArgs
	{
		public CreateEnvelopeArgs()
		{
		}

		public string Name { get; set; }
		public Guid BudgetGuid { get; set; }
	}
}