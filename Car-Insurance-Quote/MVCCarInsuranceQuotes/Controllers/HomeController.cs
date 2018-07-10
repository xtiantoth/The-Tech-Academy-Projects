using MVCCarInsuranceQuotes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Web.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace MVCCarInsuranceQuotes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveClientData(string firstName,
                                           string lastName,
                                           string emailAddress,
                                           string dateOfBirth,
                                           string carYear,
                                           string carModel,
                                           string carMake,
                                           bool DUI,
                                           int tickets,
                                           bool coverage)
        {
            if (tickets < 0)
            {
                ViewBag.Quote = "Error: The number of speeding tickets cannot be below 0.";
                return View();
            }
            else
            {
                CalculatedQuote quote = new CalculatedQuote();
                CarInsuranceRepositoryEntities2 db = new CarInsuranceRepositoryEntities2();
                quote.FirstName = firstName;
                quote.LastName = lastName;
                quote.EmailAddress = emailAddress;
                quote.DateOfBirth = dateOfBirth;
                quote.CarYear = carYear;
                quote.CarModel = carModel;
                quote.CarMake = carMake;
                quote.DUI = DUI;
                quote.SpeedingTickets = tickets;
                quote.FullCoverage = coverage;

                try
            {
                var quotes = db.CalculatedQuotes;
                
                quote.Quote = Convert.ToDecimal(CalculateCost(quote));
                quotes.Add(quote);
                db.SaveChanges();
                ViewBag.Quote = String.Format("Your calculated monthly fee for car insurance is {0:C}", quote.Quote);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                ViewBag.Quote = "There was an error processing your request, please review your data and try again.";
            }
                return View();
            }
        }

        private double CalculateCost(CalculatedQuote quote)
        {
            double Cost = 50 + ageModifier(quote) + carYearModifier(quote) + carMakeAndModelModifier(quote) + Convert.ToInt32(quote.SpeedingTickets)*10;

            if (quote.DUI == true)
                Cost *= 1.25;

            if (quote.FullCoverage == true)
                Cost *= 1.5;

            return Cost;
        }

        private int carMakeAndModelModifier(CalculatedQuote quote)
        {
            if (quote.CarMake == "Porsche" && quote.CarModel == "911 Carrera")
            {
                return 50;
            }
            else if (quote.CarMake == "Porsche")
            {
                return 25;
            }

            else return 0;
        }

        private int carYearModifier(CalculatedQuote quote)
        {
            if (Convert.ToInt32(DateTime.Parse(quote.CarYear).Year) < 2000)
            {
                return 25;
            }
            else if (Convert.ToInt32(DateTime.Parse(quote.CarYear).Year) > 2015)
            {
                return 25;
            }
            else return 0;
        }

        private int ageModifier(CalculatedQuote quote)
        {
            if ((DateTime.Today.Date.Subtract(DateTime.Parse(quote.DateOfBirth)).TotalDays < 18 * 365))
            {
                return 100;
            }
            
            else if (DateTime.Today.Date.Subtract(DateTime.Parse(quote.DateOfBirth)).TotalDays < 25 * 365)
            {
                return 25;
            }

            else if ((DateTime.Today.Date.Subtract(DateTime.Parse(quote.DateOfBirth)).TotalDays > 100 * 365))
            {
                return 25;
            }
            else return 0;
        }

        public ActionResult Quote()
        {
            return View();
        }
    }
}