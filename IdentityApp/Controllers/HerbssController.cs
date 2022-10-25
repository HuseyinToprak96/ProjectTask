using Identity.Web.Security;
using Identity.Web.Service;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Controllers
{
    public class HerbssController : Controller
    {
        DataProtection dataProtection;
        private readonly IDataProtector _dataProtector;
        private readonly HerbAPI _herbAPI;
        public HerbssController(IDataProtectionProvider dataProtectionProvider, HerbAPI herbAPI)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("HerbsCode");
            dataProtection = new DataProtection(dataProtectionProvider, "HerbsCode");
            _herbAPI = herbAPI;
        }
        public async Task<PartialViewResult> List()
        {
            var herbs = await _herbAPI.List();
            herbs.ForEach(x =>
            {
                x.EncrypedId = dataProtection.Encrypt(x.Id);
            });
            return PartialView(herbs);
        }
        public async Task<IActionResult> Detail(string code)
        {
            var id = dataProtection.Decrypt(code);
            var herb = await _herbAPI.HerbDetail(id);
            return View(herb);
        }
    }
}
