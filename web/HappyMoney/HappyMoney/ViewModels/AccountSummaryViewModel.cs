﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;

namespace HappyMoney.ViewModels
{
	public class AccountSummaryViewModel
	{
		public AccountSummaryViewModel(Account account)
		{
			if (account == null)
			{
				throw new ArgumentNullException("account");
			}

			this.Name = account.Name;
			this.Balance = account.Balance;
			this.Guid = account.Guid;
		}

		public string Name { get; private set; }
		public double Balance { get; private set; }
		public Guid Guid { get; private set; }
	}
}