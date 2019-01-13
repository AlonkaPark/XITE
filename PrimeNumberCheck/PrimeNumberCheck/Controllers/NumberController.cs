using PrimeNumberCheck.Models;
using System.Web.Mvc;

namespace PrimeNumberCheck.Controllers
{
    public class NumberController : Controller
    {
        //Default controller
        [HttpGet]
        public ActionResult Index() => View("Index");

        //Controller that will be used after pressing Check button
        [HttpPost]
        public ActionResult Index(Number number)
        {
            bool isPrime;
            int num = number.Value;

            isPrime = Primes(num);
            number.isPrime = isPrime;

            return View("Result", number);
        }

        //Method to define if provided value is prime
        private bool Primes(int number)
        {
            bool prime = true;
            int value = number;

            for (int i = 2; i <= value / 2; i++)
            {
                if (value % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            if (prime)
            {
                return true;
            }
            else
            return false;
        }
    }
}