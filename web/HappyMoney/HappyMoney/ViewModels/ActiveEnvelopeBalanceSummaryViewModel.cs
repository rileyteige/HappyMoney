using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;

namespace HappyMoney.ViewModels
{
	public class ActiveEnvelopeBalanceSummaryViewModel
	{
		public ActiveEnvelopeBalanceSummaryViewModel(Budget budget)
		{
			if (budget == null)
			{
				throw new ArgumentNullException("budget");
			}

			this.Name = budget.Name;
		}

		public string Name { get; private set; }
	}
}