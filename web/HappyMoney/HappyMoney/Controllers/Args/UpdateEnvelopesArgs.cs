using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HappyMoney.Controllers.Args
{
	public class UpdateEnvelopesArgs
	{
		public UpdateEnvelopesArgs()
		{
		}

		public EnvelopeUpdate[] Envelopes { get; set; }
	}

	public class EnvelopeUpdate
	{
		public EnvelopeUpdate()
		{
		}

		public string Name { get; set; }
		public Guid Guid { get; set; }
		public double Capacity { get; set; }
	}
}