using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Models;

namespace ECommerceMVC.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult PlaceOrder()
        {
            // Example Order (will throw error to test error filter)
            throw new Exception("Order processing failed!");
        }
    }
}
