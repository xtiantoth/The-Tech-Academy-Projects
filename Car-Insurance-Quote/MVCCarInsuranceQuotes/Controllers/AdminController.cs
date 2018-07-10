using MVCCarInsuranceQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCarInsuranceQuotes.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            CarInsuranceRepositoryEntities2 db = new CarInsuranceRepositoryEntities2();
            var quotes = db.CalculatedQuotes.ToList();
            var QuotesForAdmin = new List<QuoteRequestMV>();
            foreach (var quote in quotes)
            {
                var QuoteForAdmin = new QuoteRequestMV();
                QuoteForAdmin.FirstName = quote.FirstName;
                QuoteForAdmin.LastName = quote.LastName;
                QuoteForAdmin.EmailAddress = quote.EmailAddress;
                QuoteForAdmin.Quote = quote.Quote;
                QuotesForAdmin.Add(QuoteForAdmin);
            }
            ViewBag.AllQuotes = QuotesForAdmin;

            return View(QuotesForAdmin);
        }
    }
}