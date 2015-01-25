using System;

namespace HappyMoney.Models.Repositories
{
	public interface IBudgetRepository
	{
		Budget GetBudget(string name);
		Budget GetBudget(Guid budgetGuid);
	}
}
