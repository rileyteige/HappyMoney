using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public interface ITransactionRepository
	{
		Transaction GetTransaction(Guid transactionGuid);
		Guid LogTransaction(int accountId, string payee, double total);
		bool DeleteTransaction(Transaction transaction);
	}
}
