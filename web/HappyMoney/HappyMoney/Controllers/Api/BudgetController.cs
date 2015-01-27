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
		public BudgetSummaryViewModel Get(Guid id)
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

			return new BudgetSummaryViewModel(budget);
		}
    }
}
