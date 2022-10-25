using Identity.Web.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ComplaintController : Controller
    {
        private readonly ComplaintAPI _complaintAPI;

        public ComplaintController(ComplaintAPI complaintAPI)
        {
            _complaintAPI = complaintAPI;
        }

        public async Task<PartialViewResult> List()
        {
            var complaints =await _complaintAPI.List();
            return PartialView(complaints);
        }
    }
}
