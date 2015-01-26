using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public class AccountRepository : IAccountRepository
	{
		private readonly HappyMoneyEntities _context = new HappyMoneyEntities();

		public Account GetAccount(Guid accountGuid)
		{
			if (accountGuid == null || accountGuid == Guid.Empty)
			{
				throw new ArgumentNullException("accountGuid");
			}

			return _context.Accounts.SingleOrDefault(acc => acc.Guid == accountGuid);
		}

		public bool UpdateAccount(Account account)
		{
			if (account == null)
			{
				throw new ArgumentNullException("account");
			}

			Account oldAccount = _context.Accounts.Find(account.Id);
			if (oldAccount == null)
			{
				return false;
			}

			oldAccount.Name = account.Name;
			oldAccount.Balance = account.Balance;

			return _context.SaveChanges() > 0;
		}
	}
}
