using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;

namespace HappyMoney.ViewModels
{
	public class EditBudgetViewModel
	{
		public EditBudgetViewModel(Budget budget)
		{
			if (budget == null)
			{
				throw new ArgumentNullException("budget");
			}

			this.Name = budget.Name;
			this.Capacity = budget.Envelopes.Sum(env => env.Capacity);
			this.Guid = budget.Guid;
		}

		public string Name { get; private set; }
		public double Capacity { get; private set; }
		public Guid Guid { get; private set; }
	}
}