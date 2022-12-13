using Git_Corona.Models;
using Git_Corona.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Corona.Controllers
{
    public class UserController : Controller
    {
        private readonly ICoronaService _DbService = null;

        public UserController(ICoronaService dbservice)
        {
            _DbService = dbservice;
        }
        //This is for Login
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> UserLogin(string UserID, string Password)
        {


            try
            {
                var x = await _DbService.UserGetByUserID(UserID, Password);
                if (x.UserName != null)
                {
                    if (x.UserID == UserID && x.Password == Password)
                    {
                        HttpContext.Session.SetString("ID", Convert.ToString(x.ID));
                        HttpContext.Session.SetString("UserID", x.UserID);
                        HttpContext.Session.SetString("UserName", x.UserName);
                        HttpContext.Session.SetString("PhoneNo", x.PhoneNo);
                        HttpContext.Session.SetString("Email", x.Email);
                        HttpContext.Session.SetString("Password", x.Password);

                        return Json(1);

                    }

                }
            }
            catch (Exception ex)
            {
                return Json(0);
            }
            return Json(0);
        }
        //this is for Home for user registration
        public IActionResult Home()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Welcome");
            }

        }
        public async Task<JsonResult> UserCreat(UserEntity obj)
        {
            var a = 0;
            try
            {
                //if you get data from user table then a value is zero(0)
                var _chkUserID = await _DbService.UserGetByUserID(obj.UserID);

            }
            catch (Exception ex)
            {
                //if not getting it give exception error then we set a =1 value
                a = 1;
            }
            //a==1 means its not getting any userID at data base t
            if (a == 1)
            {

                var x = await _DbService.UserCreate(obj);
                return Json(x);


            }
            else
            {
                //a==0 means userID preset at table
                return Json(0);
            }

        }
        //This is for forgotPassword
        public IActionResult ForgotPwd()
        {

            return View();

        }
        public async Task<JsonResult> UserForgotPwd(string UserID)
        {
            try
            {

                var x = await _DbService.UserGetByUserID(UserID);
                if (x != null)
                {
                    return Json(1);
                }

            }
            catch (Exception ex)
            {
                return Json(0);

            }
            return Json(0);


        }
        //got to task view
        public async Task<IActionResult> task()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.drpStatus = await _DbService.StateGetAll();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }
        //state details
        public async Task<JsonResult> Getstate()
        {
            var v = await _DbService.StateGetAll();
            var _state = JsonConvert.SerializeObject(v);
            return Json(_state);
        }
        //block
        public async Task<JsonResult> Getblock(int ID)
        {
            var v = await _DbService.BlockGetAll(ID);
            var _block = JsonConvert.SerializeObject(v);
            return Json(_block);
        }
        public async Task<JsonResult> GetPanchyat(int ID)
        {
            var v = await _DbService.PanchyatGetAll(ID);
            var _panchyat = JsonConvert.SerializeObject(v);
            return Json(_panchyat);
        }
        //Corona affted and recovery 
        public async Task<JsonResult> SaveUpdateData(CoronaStatus obj)
        {
            if (ModelState.IsValid)
            {
                var x = await _DbService.CoronaUpdateCreateData(obj);
                return Json(x);
            }
            return Json(0);
        }
        //Count the affected and death
        public async Task<JsonResult> GetCoronaStatus()
        {
            var x = await _DbService.CoronaGetAll();
            var _corona = JsonConvert.SerializeObject(x);
            return Json(_corona);
        }
        //welcome page for user
        public IActionResult Welcome()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.userName = HttpContext.Session.GetString("UserName");
                ViewBag.Phone = HttpContext.Session.GetString("PhoneNo");
                ViewBag.email = HttpContext.Session.GetString("Email");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }

        }
        //Password change
        public IActionResult PasswordChange()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.pwd = HttpContext.Session.GetString("Password");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }

        }

        public async Task<JsonResult> ChangePwd(UserEntity obj)
        {
            // string id = Convert.ToInt32(HttpContext.Session.GetInt32("ID"));
            obj.ID = Convert.ToInt32(HttpContext.Session.GetString("ID"));

            var x = await _DbService.UserUpdateCreateData(obj);
            return Json(x);
        }

        //Edit Profile
        public IActionResult EditProfile()
        {
            if (HttpContext.Session.GetString("UserName") != null)
            {
                ViewBag.userName = HttpContext.Session.GetString("UserName");
                ViewBag.Phone = HttpContext.Session.GetString("PhoneNo");
                ViewBag.email = HttpContext.Session.GetString("Email");
                return View();
            }
            else
            {
                return RedirectToAction("Index", "User");
            }

        }
        public async Task<JsonResult> UserUpdat(UserEntity obj)
        {
            obj.ID = Convert.ToInt32(HttpContext.Session.GetString("ID"));
            var x = await _DbService.UserUpdateCreateData(obj);
            if (x == 1)
            {
                HttpContext.Session.SetString("UserName", obj.UserName);
                HttpContext.Session.SetString("PhoneNo", obj.PhoneNo);
                HttpContext.Session.SetString("Email", obj.Email);
            }
            return Json(x);
        }

        //logout method
        public IActionResult logout()
        {
            //Delete the Session object.
            HttpContext.Session.Remove("UserName");
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}