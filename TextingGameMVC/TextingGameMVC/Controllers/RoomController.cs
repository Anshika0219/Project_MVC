using Domain;
using Domain.RoomModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TextingGameMVC.Models;
using TextingGameMVC.Models.RoomModel;

namespace TextingGameMVC.Controllers
{
    public class RoomController : Controller
    {
        private readonly HttpClient client;
        public RoomController()
        {
          
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7269/api/Room");
        }
      
        public ActionResult Index()
        {
           try
                {
                    IEnumerable<Roomdetails> getModels = new List<Roomdetails>();
                IEnumerable<RoomResponse> roomResponses = new List<RoomResponse>();
                HttpResponseMessage getdata = client.GetAsync("").Result;
                    if (getdata.IsSuccessStatusCode)
                    {
                        string result = getdata.Content.ReadAsStringAsync().Result;
                        roomResponses = JsonConvert.DeserializeObject<List<RoomResponse>>(result)!;
                    }
                    return View(roomResponses);
                }
                catch (Exception ex)
                {
                    return View(ex.Message);
                }
            }
        public ActionResult RoomCreate()
        {
            return View();
        }

        [HttpPost]
        [ActionName("RoomCreate")]
        [ValidateAntiForgeryToken]
        public ActionResult RoomCreate(CreateRoom createRoom)
        {
            try
            {
                BaseResponseModel baseResponseModel = new BaseResponseModel();
                HttpResponseMessage response = client.PostAsJsonAsync("", createRoom).Result;
                String result = response.Content.ReadAsStringAsync().Result;
                createRoom = JsonConvert.DeserializeObject<CreateRoom>(result)!;
                if (response.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index", "Room");
                }
                ModelState.AddModelError(string.Empty, "server Error");
                return View(createRoom);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
    }
