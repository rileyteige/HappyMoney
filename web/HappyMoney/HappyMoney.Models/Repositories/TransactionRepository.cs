using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly HappyMoneyEntities _context = new HappyMoneyEntities();

		public Guid LogTransaction(int accountId, string payee, double total)
		{
			if (accountId <= 0)
			{
				throw new ArgumentOutOfRangeException("accountId", "Must be > 0.");
			}
			if (string.IsNullOrEmpty(payee))
			{
				throw new ArgumentNullException("payee");
			}
			if (total == 0.0)
			{
				throw new ArgumentException("total", "Must be non-zero.");
			}

			var transaction = new Transaction { AccountId = accountId, Payee = payee, Total = total, Guid = Guid.NewGuid() };
			_context.Transactions.Add(transaction);

			return transaction.Guid;
		}

		public void Dispose()
		{
			_context.SaveChanges();
		}
	}
}
