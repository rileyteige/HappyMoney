using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyMoney.Models.Repositories
{
	public interface IAccountRepository
	{
		Account GetAccount(int id);
		bool UpdateAccount(Account account);
	}
}
