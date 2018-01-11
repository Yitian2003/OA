using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Model;
using OA.BLL;
using OA.IBLL;

namespace OA.WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        IUserInfoService UserInfoService = new UserInfoService();

        public ActionResult Index()
        {
            
            return View();
        }
    }
}