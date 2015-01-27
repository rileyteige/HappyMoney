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
		Guid PostTransaction(int accountId, DateTime eventDate, string payee, double total);
		bool DeleteTransaction(Transaction transaction);
	}
}
