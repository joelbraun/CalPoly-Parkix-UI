using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ParkixUI2.Controllers
{
    public class LoginController : Controller
    {
		// GET: Login
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Submit(IFormCollection collection)
		{
			var email = collection["email"];
			var password = collection["password"];
			HttpContext.Session.SetString("user", email);

			return Redirect("/Dashboard");
		}

		// GET: Login/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: Login/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Login/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Login/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Login/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Login/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Login/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
    }
}
