using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using CorePassword.Data;
using CorePassword.Models;
using CorePassword.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace CorePassword.Controllers
{
    public class WebsitePasswordController : Controller
    {
        private readonly ProjectContext _db;
        private readonly IPasswordGenerator _passwordGenerator;

        public WebsitePasswordController(ProjectContext db,IPasswordGenerator passwordGenerator)
        {
            _db = db;
            _passwordGenerator = passwordGenerator;
        }
        public IActionResult List(string orderBy="desc")
        {
            List<WebsitePassword> list = new List<WebsitePassword>();

            switch (orderBy)
            {
                case "desc":
                    list = _db.WebsitePassword.Include(x => x.PasswordHistories).OrderByDescending(x => x.CopyCount).ToList();
                    break;
                case "asc":
                    list = _db.WebsitePassword.Include(x => x.PasswordHistories).OrderBy(x => x.CopyCount).ToList();
                    break;
            }
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(WebsitePassword sitePassword)
        {
            _db.WebsitePassword.Add(sitePassword);
            _db.SaveChanges();
            return View(sitePassword);
        }
        [HttpPost]
        public JsonResult GeneratePassword(GeneratePasswordViewModel model)
        {
            string password = _passwordGenerator.GeneratePassword(model.PasswordLength, model.MinUpperCaseCharLength,
                model.MinLowerCaseCharLength, model.MinSpecialCharLength, model.MinNumericCharLength);
            return Json(password);
        }

        public JsonResult SaveNewPassword([FromBody] string id)
        {
            string password = this._passwordGenerator.GeneratePassword(12, 3, 3, 3, 3);

            var data = _db.WebsitePassword.Find(id);
            _db.WebsitePasswordHistory.Add(new WebsitePasswordHistory
            {
                WebsitePasswordId = data.Id,
                ExpiredDate = DateTime.Now,
                Password = data.Password
            });

            data.Password = password;

            _db.SaveChanges();

            return Json(password);
        }

        [HttpPost]
        public JsonResult ChangeUserName([FromBody] ChangeUsernameInputModel data)
        {
            try
            {
                var dbData = _db.WebsitePassword.Find(data.Id);
                dbData.ChangeUsername(data.Username);
                _db.SaveChanges();

                return Json("Username guncellendi.");
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [HttpPost]
        public JsonResult IncreaseCopyCount([FromBody] string id)
        {
            var data = _db.WebsitePassword.Find(id);
            data.IncreaseCopyCount();
            _db.SaveChanges();

            return Json("OK");
        }
        [HttpPost]
        public JsonResult Remove([FromBody]string id)
        {
            var data = _db.WebsitePassword.Find(id);
            _db.WebsitePassword.Remove(data);
            _db.SaveChanges();

            return Json("Ok");
        }
    }
}
