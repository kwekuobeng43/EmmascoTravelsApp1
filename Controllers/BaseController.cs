using EmmascoTravelsApp1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace EmmascoTravelsApp1.Controllers
{

    public class BaseController : Controller
    {
        protected readonly AppDbContext _context;

        public BaseController(AppDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                context.Result = new RedirectToActionResult("Login", "Login", null);
            }
            else
            {
                var username = HttpContext.Session.GetString("username");
                var user = _context.Users.FirstOrDefault(u => u.Username == username);

                if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    if ((controllerActionDescriptor.ControllerTypeInfo.Name == "AdminController" || controllerActionDescriptor.ControllerTypeInfo.Name == "UserManagementController") && (user == null || user.Role != "Admin"))
                    {
                        context.Result = new RedirectToActionResult("Index", "Home", null);
                    }
                }
            }
            base.OnActionExecuting(context);
        }
    }
}