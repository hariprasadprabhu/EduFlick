using Course.Business;
using Course.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        [HttpPost]
        [Route("Subscribe")]
        public IActionResult Subscribe(Subscription subscription)
        {
            SubscriptionBO sb = new SubscriptionBO();
            Success sc = new Success();
            if(!sb.Subscribe(subscription))
            {
                sc.id = 1;
                sc.message = "Something Went wrong";
            }
            else
            {
                sc.id = 0;
                sc.message = "Success";
            }
            return new JsonResult(sc);
        }
    }
}
