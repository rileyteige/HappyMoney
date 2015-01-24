using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HappyMoney.Models;
using HappyMoney.ViewModels;

namespace HappyMoney.Controllers
{
	public class HomeController : BaseController
	{
		private readonly HappyMoneyEntities _context = new HappyMoneyEntities();

		public ActionResult Index()
		{
			Budget budget = _context.Budgets.FirstOrDefault();
			if (budget == null)
			{
				return HttpNotFound();
			}

			var viewModel = new ActiveEnvelopeBalanceSummaryViewModel(budget);

			return View(viewModel);
		}

		public ActionResult About()
		{
			return View();
		}

		public ActionResult Contact()
		{
			return View();
		}

		public ActionResult Load()
		{
			return Json(new[] { 1, 2, 3 });
		}
	}
}
