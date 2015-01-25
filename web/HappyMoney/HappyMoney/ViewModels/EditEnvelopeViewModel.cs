using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;

namespace HappyMoney.ViewModels
{
	public class EditEnvelopeViewModel
	{
		public EditEnvelopeViewModel(Envelope envelope)
		{
			if (envelope == null)
			{
				throw new ArgumentNullException("envelope");
			}

			this.Guid = envelope.Guid;
			this.Name = envelope.Name;
			this.Capacity = envelope.Capacity;
		}

		public Guid Guid { get; private set; }
		public string Name { get; private set; }
		public double Capacity { get; private set; }
	}
}