using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HappyMoney.Models;
using HappyMoney.Models.Repositories;
using HappyMoney.ViewModels;

namespace HappyMoney.Controllers.Api
{
    public class BudgetController : ApiController
    {
		[HttpGet]
		public IEnumerable<TransactionSummaryViewModel> Transactions(Guid id)
		{
			if (id == null || id == Guid.Empty)
			{
				throw new ArgumentNullException("id");
			}

			IBudgetRepository repository = new BudgetRepository();
			Budget budget = repository.GetBudget(id);
			if (budget == null)
			{
				return null;
			}

			return budget.Accounts
					.SelectMany(acc => acc.Transactions)
					.OrderByDescending(trans => trans.EventDate)
					.ThenByDescending(trans => trans.Id)
					.Select(trans => new TransactionSummaryViewModel(trans));
		}
    }
}
