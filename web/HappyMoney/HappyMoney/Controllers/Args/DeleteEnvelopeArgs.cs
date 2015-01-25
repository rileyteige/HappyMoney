using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyMoney.Controllers.Args
{
	public class DeleteEnvelopeArgs
	{
		public DeleteEnvelopeArgs()
		{
		}

		public Guid EnvelopeGuid { get; set; }
	}
}
