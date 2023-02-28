using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("login")]
        public string Login()
        {
            var jobId = BackgroundJob.Enqueue(() => Console.WriteLine("Welcome to fire and forget job in Hangdire"));
            return jobId;
        }
        [HttpGet]
        [Route("productcheckout")]
        public string CheckOutProduct()
        {
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("You checkout new product into your checklist"), TimeSpan.FromSeconds(20));
            return $"Job Id {jobId}. You have added product to cart";
        }
        [HttpGet]
        [Route("productpayment")]
        public string ProductPayment()
        {
            var parentJobId = BackgroundJob.Enqueue(() => Console.WriteLine("You have done your payment suceessfully!"));
            BackgroundJob.ContinueJobWith(parentJobId, () => Console.WriteLine("Product receipt sent!"));
            return "You have done payment and receipt sent on your mail id!";
        }
        [HttpGet]
        [Route("dailyoffers")]
        public string DailyOffer()
        {
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Sent similar product offer and suuggestions"), Cron.Daily);
            return "offer sent!";
        }
    }
}



