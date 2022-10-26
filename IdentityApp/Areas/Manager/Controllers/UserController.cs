using CoreLayer.Entities.UserEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]

    public class UserController : Controller
    {
        private UserManager<UserApp> _UserManager { get; }
        public UserController(UserManager<UserApp> UserManager)
        {
            _UserManager = UserManager;
        }
        public IActionResult List()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
