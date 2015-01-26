using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HappyMoney.Controllers.Args;
using HappyMoney.Models;
using HappyMoney.Models.Repositories;
using HappyMoney.Services;

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

			IAccountRepository accounts = new AccountRepository();
			Account account = accounts.GetAccount(args.AccountGuid);
			if (account == null)
			{
				return Guid.Empty;
			}

			account.Balance += args.Total;
			accounts.UpdateAccount(account);

			ITransactionRepository repository = new TransactionRepository();
			return repository.LogTransaction(account.Id, args.Payee, args.Total);
		}

		[HttpDelete]
		public bool Undo(DeleteTransactionArgs args)
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}

			return new TransactionService(new TransactionRepository(), new AccountRepository()).UndoTransaction(args.TransactionGuid);
		}
    }
}
