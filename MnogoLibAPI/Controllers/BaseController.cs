using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MnogoLibAPI.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        public User User => (User)HttpContext.Items["User"];
    }
}