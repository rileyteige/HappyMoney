using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HappyMoney.Controllers.Args;
using HappyMoney.Models;
using HappyMoney.Models.Repositories;

namespace HappyMoney.Controllers
{
    public class TransactionController : ApiController
    {
		[HttpPost]
		public Guid Post(CreateTransactionArgs args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}

			Account account = null;
			using (IAccountRepository accounts = new AccountRepository())
			{
				account = accounts.GetAccount(args.AccountGuid);
				if (account == null)
				{
					return Guid.Empty;
				}

				account.Balance += args.Total;
			}

			using (ITransactionRepository repository = new TransactionRepository())
			{
				return repository.LogTransaction(account.Id, args.Payee, args.Total);
			}
		}
    }
}
