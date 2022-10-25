using Identity.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Controllers
{
    public class ToolsController : Controller
    {
        private readonly ComplaintAPI _complaintAPI;

        public ToolsController(ComplaintAPI complaintAPI)
        {
            _complaintAPI = complaintAPI;
        }

        public IActionResult HerbsSearch()
        {
            return View();
        }
        public async Task<PartialViewResult> MenuDropDown()
        {
            return PartialView(await _complaintAPI.List());
        }
    }
}
