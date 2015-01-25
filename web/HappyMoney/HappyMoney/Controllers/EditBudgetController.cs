using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyMoney.Models;
using HappyMoney.Models.Repositories;
using HappyMoney.ViewModels;

namespace HappyMoney.Controllers
{
    public class EditBudgetController : Controller
    {
        //
        // GET: /Budget/{name}

		[HttpGet]
        public ActionResult Index(string name)
        {
			IBudgetRepository repository = new BudgetRepository();

			Budget budget = repository.GetBudget(name.Replace('-', ' '));
			if (budget == null)
			{
				return new HttpNotFoundResult();
			}

			return View("Index", new EditBudgetViewModel(budget));
        }

    }
}
