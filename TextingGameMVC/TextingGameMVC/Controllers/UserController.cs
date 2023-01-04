using com.sun.codemodel.@internal.fmt;
using com.sun.tools.doclets.formats.html.markup;
using com.sun.xml.@internal.bind.v2.runtime.output;
using com.sun.xml.@internal.rngom.parse;
using Domain;
using Domain.UserModel;
using javax.security.auth.spi;
using jdk.nashorn.@internal.objects.annotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Web;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TextingGameMVC.Models;
using static com.sun.tools.@internal.xjc.reader.xmlschema.bindinfo.BIConversion;
using StringContent = System.Net.Http.StringContent;

namespace TextingGameMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient client;
        private LoginUserResponseModel token;
        private BaseResponseModel _token;
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7269/api/User/");
        }

        public ActionResult Index1()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                IEnumerable<GetModel> getModels = new List<GetModel>();
                HttpResponseMessage getdata = client.GetAsync("").Result;
                if (getdata.IsSuccessStatusCode)
                {
                    string result = getdata.Content.ReadAsStringAsync().Result;
                    getModels = JsonConvert.DeserializeObject<List<GetModel>>(result)!;
                }
                return View(getModels);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Registration")]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(CreateModel createModel)
        {
            try
            {
                BaseResponseModel baseResponseModel = new BaseResponseModel();
              HttpResponseMessage response = client.PostAsJsonAsync("UserRegister", createModel).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                createModel = JsonConvert.DeserializeObject<CreateModel>(result)!;
                if (response.IsSuccessStatusCode)
                {
    
                    return RedirectToAction("Index", "User");
                }
                ModelState.AddModelError(string.Empty, "server Error");
                return View(createModel);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LogIn")]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel loginModel)
        {
            try
            {
                LoginModel log = new LoginModel();
                LoginUserResponseModel loginRespone = new LoginUserResponseModel();
                HttpResponseMessage response = client.PostAsJsonAsync("LogIn", loginModel).Result;
                string resultMessage = response.Content.ReadAsStringAsync().Result;
                token = JsonConvert.DeserializeObject<LoginUserResponseModel>(resultMessage)!;
                if (response.IsSuccessStatusCode)
                {
                    if (token.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError(string.Empty, token.ErrorMessage!);
                        return View(loginModel);
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }
                ModelState.AddModelError(string.Empty, "server Error");
                return View(loginModel);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        [ActionName("ForgetPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(UserForgotPasswordRequestModel userForgotPassword)
        {
            try
            {
                UserForgotPasswordRequestModel userForgot = new UserForgotPasswordRequestModel();
                UserForgotPasswordRequestModel log = new UserForgotPasswordRequestModel();
                BaseResponseModel responseModel = new BaseResponseModel();
                HttpResponseMessage response = client.PutAsJsonAsync("ForgetPassword", userForgotPassword).Result;
                string resultMessage = response.Content.ReadAsStringAsync().Result;
                _token = JsonConvert.DeserializeObject<BaseResponseModel>(resultMessage)!;
                if (response.IsSuccessStatusCode)
                {
                    if (_token.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    {
                        ModelState.AddModelError(string.Empty, _token.ErrorMessage!);
                        return View(userForgotPassword);
                    }
                    else
                    {
                        return RedirectToAction("Index", "User");
                    }
                }

                ModelState.AddModelError(string.Empty, "server Error");
                return View(userForgotPassword);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
  }




