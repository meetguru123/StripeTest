using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StripeTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            
            StripeConfiguration.ApiKey = "sk_test_51JQDvpFc7wJ0LkaclD0ZynKxsKY8nPtDyoA7lCu7SBDehVUhGtZREN1rzxXo98EEpxLMIvt6ZOeI3bz4bGq0aXh700HnUm319p";

            /////////////////////////////////////////////////////// For creating customer in stripe
            //Set your secret key. Remember to switch to your live secret key in production.
            // See your keys here: https://dashboard.stripe.com/apikeys

            //var options = new CustomerCreateOptions
            //{
            //    Description = "1st test customer",
            //    Email = "test@gmail.com",
            //    Name = "testC"
            //};

            //var service = new CustomerService();
            //var customer = service.Create(options);

            ////////////////////////////////////////////////////
            var service2 = new SetupIntentService();
            var options2 = new SetupIntentCreateOptions
            {
              PaymentMethodTypes = new List<string>
              {
                "au_becs_debit",
              },
                Customer = "cus_Kgk4xMk92lGvq1",//test CUSTOMER_ID
            };
            SetupIntent intent = service2.Create(options2);

            var clientSecret = intent.ClientSecret;
            // Pass the client secret to the client

            ViewBag.clientSecret = clientSecret;

            //////////////////////////////////////////////////////


            var options3 = new SetupIntentUpdateOptions
            {
                Expand = new List<string> { "mandate" },
            };
            var service3 = new SetupIntentService();
            service3.Update(intent.Id, options3); //"{{SETUP_INTENT_ID}}"

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}