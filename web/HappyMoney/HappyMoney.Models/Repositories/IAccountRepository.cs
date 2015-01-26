using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public interface IAccountRepository
	{
		Account GetAccount(Guid accountGuid);
		bool UpdateAccount(Account account);
	}
}
