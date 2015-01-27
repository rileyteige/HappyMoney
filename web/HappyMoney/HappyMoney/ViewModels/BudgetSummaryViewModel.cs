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

			this.Guid = budget.Guid;
			this.Name = budget.Name;
			this.Envelopes = budget.Envelopes.Select(env => new EnvelopeBalanceSummaryViewModel(env));
			this.Accounts = budget.Accounts.Select(acc => new AccountSummaryViewModel(acc));
		}

		public Guid Guid { get; private set; }
		public string Name { get; private set; }
		public IEnumerable<EnvelopeBalanceSummaryViewModel> Envelopes { get; private set; }
		public IEnumerable<AccountSummaryViewModel> Accounts { get; private set; }
	}
}