using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public class BudgetRepository : IBudgetRepository
	{
		private readonly HappyMoneyEntities _context = new HappyMoneyEntities();

		public Budget GetBudget(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}

			return _context.Budgets.SingleOrDefault(b => b.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
		}

		public Budget GetBudget(Guid budgetGuid)
		{
			if (budgetGuid == null || budgetGuid == Guid.Empty)
			{
				throw new ArgumentNullException("budgetGuid");
			}

			return _context.Budgets.SingleOrDefault(b => b.Guid == budgetGuid);
		}
	}
}
