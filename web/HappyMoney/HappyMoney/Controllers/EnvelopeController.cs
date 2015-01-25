using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HappyMoney.Models;
using HappyMoney.Models.Repositories;
using HappyMoney.ViewModels;

namespace HappyMoney.Controllers
{
    public class EnvelopeController : ApiController
    {
		[HttpGet]
		public IEnumerable<EditEnvelopeViewModel> Get(Guid budgetGuid)
		{
			if (budgetGuid == null || budgetGuid == Guid.Empty)
			{
				throw new ArgumentNullException("budgetGuid");
			}

			IBudgetRepository budgetRepository = new BudgetRepository();

			Budget budget = budgetRepository.GetBudget(budgetGuid);
			if (budget == null)
			{
				return null;
			}

			return budget.Envelopes.Select(env => new EditEnvelopeViewModel(env));
		}
    }
}
