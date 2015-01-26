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

		public Transaction GetTransaction(Guid transactionGuid)
		{
			if (transactionGuid == null || transactionGuid == Guid.Empty)
			{
				throw new ArgumentNullException("transactionGuid");
			}

			return _context.Transactions.SingleOrDefault(t => t.Guid == transactionGuid);
		}

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

			return _context.SaveChanges() > 0 ? transaction.Guid : Guid.Empty;
		}

		public bool DeleteTransaction(Transaction transaction)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}

			_context.Transactions.Remove(transaction);
			return _context.SaveChanges() > 0;
		}

		public void Dispose()
		{
			_context.SaveChanges();
		}
	}
}
