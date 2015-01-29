using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HappyMoney.Models;

namespace HappyMoney.ViewModels
{
	public class TransactionSummaryViewModel
	{
		public TransactionSummaryViewModel(Transaction transaction)
		{
			if (transaction == null)
			{
				throw new ArgumentNullException("transaction");
			}

			this.Id = transaction.Id;
			this.EventDate = transaction.EventDate;
			this.Payee = transaction.Payee;
			this.Total = transaction.Total;
			this.Guid = transaction.Guid;
			this.AccountId = transaction.AccountId;
		}

		public int Id { get; set; }
		public int AccountId { get; set; }
		public DateTime EventDate { get; set; }
		public string Payee { get; set; }
		public double Total { get; set; }
		public Guid Guid { get; set; }
	}
}