using CoreLayer.Dtos.Herb;
using Identity.Web.DesignPattern.CommandDesign;
using Identity.Web.Framework;
using Identity.Web.Security;
using Identity.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Areas.Manager.Controllers
{
    [Area("Manager")]
   // [Authorize]
    public class HerbsController : Controller
    {
        private readonly HerbAPI _herbAPI;
        DataProtection dataProtection;
        private readonly IDataProtector _dataProtector;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HerbsController(HerbAPI herbAPI, IDataProtectionProvider dataProtectionProvider, IWebHostEnvironment webHostEnvironment)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("HerbCode");
            dataProtection = new DataProtection(dataProtectionProvider, "HerbCode");
            _herbAPI = herbAPI;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> List()
        {
            var herbs =await _herbAPI.List();
            herbs.ForEach(x =>
            {
                x.EncrypedId = dataProtection.Encrypt(x.Id);
            });
            return View(herbs);
        }
        public async Task<IActionResult> Edit(string code)
        {
            var id = dataProtection.Decrypt(code);
            var herbDto =await _herbAPI.Find(id);
            return View(herbDto);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HerbDto herbDto, IFormFile formFile)
        {
            if (formFile != null)
            {
                string folder = "images/";
                folder += Guid.NewGuid().ToString() + formFile.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                herbDto.Image = folder;
            }
            var status = await _herbAPI.Update(herbDto);
            return RedirectToAction("List");
        }
        public async Task<IActionResult> Detail(string code)
        {
            var id = dataProtection.Decrypt(code);
            var herbDto = await _herbAPI.HerbDetail(id);
            return View(herbDto);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(HerbDto herbDto, IFormFile formFile)
        {
            if (formFile != null)
            {
                string folder = "images/";
                folder += Guid.NewGuid().ToString() + formFile.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                herbDto.Image = folder;
            }
           // herbDto.Description = XSS.ClearTag(herbDto.Description);
            var herb= await _herbAPI.Add(herbDto);
            return RedirectToAction("List");
        }
        //public async Task<JsonResult> Add(string json)
        //{
        //    var herb = JsonConvert.DeserializeObject<HerbDto>(json);
        //    var dto= await _herbAPI.Add(herb);
        //    var jsonResult = JsonConvert.SerializeObject(dto);
        //    return Json(jsonResult);
        //}
        public async Task<JsonResult> Remove(string code)
        {
            var id = dataProtection.Decrypt(code);
            var status= await _herbAPI.Delete(id);
            if (status==false)
            {
                return Json(0);
            }
            return Json(id);
        }

        public async Task<IActionResult> CreateFile(int type)
        {
            var herbs= await _herbAPI.List();
            FileCreateInvoker fileCreateInvoker = new();
            EFileType fileType = (EFileType)type;
            switch (fileType)
            {
                case EFileType.Excel:
                    ExcelFile<HerbDto> excelFile = new(herbs);
                    fileCreateInvoker.SetCommand(new CreateExcelTableActionCommand<HerbDto>(excelFile));
                    break;
                case EFileType.Pdf:
                    PdfFile<HerbDto> pdfFile = new(herbs, HttpContext);
                    fileCreateInvoker.SetCommand(new CreatePdfTableActionCommand<HerbDto>(pdfFile));
                    break;
                default:
                    break;
            }
            return fileCreateInvoker.CreateFile();
        }
        public async Task<JsonResult> Status(int id)
        {
            var herb = await _herbAPI.Find(id);
            herb.IsActive = !herb.IsActive;
            await _herbAPI.Update(herb);
            return Json(id);
        }
    }
}
