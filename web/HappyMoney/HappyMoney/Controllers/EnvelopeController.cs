using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HappyMoney.Controllers.Args;
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

		[HttpPut]
		public bool Put(UpdateEnvelopesArgs args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}

			IEnvelopeRepository envelopeRepository = new EnvelopeRepository();

			var pairs = args.Envelopes
							.Select(env => new { Update = env, Record = envelopeRepository.GetEnvelope(env.Guid) })
							.Where(pair => pair.Record != null);

			foreach (var pair in pairs)
			{
				pair.Record.Capacity = pair.Update.Capacity;
				pair.Record.Name = pair.Update.Name;
			}

			return envelopeRepository.UpdateEnvelopes(pairs.Select(p => p.Record));
		}
    }
}
