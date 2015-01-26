using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;

namespace HappyMoney.ViewModels
{
	public class BudgetSummaryViewModel
	{
		public BudgetSummaryViewModel(Budget budget)
		{
			if (budget == null)
			{
				throw new ArgumentNullException("budget");
			}

			this.Name = budget.Name;
			this.Envelopes = budget.Envelopes.Select(env => new EnvelopeBalanceSummaryViewModel(env));
		}

		public string Name { get; private set; }
		public IEnumerable<EnvelopeBalanceSummaryViewModel> Envelopes { get; private set; }
	}
}