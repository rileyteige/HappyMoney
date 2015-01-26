using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;
using HappyMoney.Models.Repositories;

namespace HappyMoney.Services
{
	public class TransactionService
	{
		private readonly ITransactionRepository _transactions;
		private readonly IAccountRepository _accounts;

		public TransactionService(ITransactionRepository transactions, IAccountRepository accounts)
		{
			if (transactions == null)
			{
				throw new ArgumentNullException("transactions");
			}
			if (accounts == null)
			{
				throw new ArgumentNullException("accounts");
			}

			_transactions = transactions;
			_accounts = accounts;
		}

		public bool UndoTransaction(Guid transactionGuid)
		{
			if (transactionGuid == null || transactionGuid == Guid.Empty)
			{
				throw new ArgumentNullException("transactionGuid");
			}

			Transaction transaction = _transactions.GetTransaction(transactionGuid);
			if (transaction == null)
			{
				return false;
			}

			var account = transaction.Account;
			account.Balance -= transaction.Total;

			bool accountUpdatedSuccessfully = _accounts.UpdateAccount(account);
			if (!accountUpdatedSuccessfully)
			{
				return false;
			}

			return _transactions.DeleteTransaction(transaction);
		}
	}
}