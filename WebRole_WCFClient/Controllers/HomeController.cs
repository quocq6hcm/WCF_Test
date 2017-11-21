using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Mvc;

namespace WebRole_WCFClient.Controllers
{
    public class HomeController : Controller
    {
        private const string url = "http://localhost:52330/Service1.svc/";
        WebClient wc = new WebClient();
        // GET: Home
        public ActionResult Index(string txtDirector)
        {
            var model = JsonConvert.DeserializeObject<IEnumerable<Models.Laptop>>(wc.DownloadString(url + "GetMoviesList?Director=" + txtDirector));        
            return View(model);
         
        }

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Models.Laptop newLaptop)
        {
            if (ModelState.IsValid)
            {


                MemoryStream ms = new MemoryStream();
                DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Models.Laptop));
                dc.WriteObject(ms, newLaptop);
                wc.Headers["content-type"] = "application/json";
                wc.UploadData(url + "PostMovie", ms.ToArray());

                ModelState.AddModelError("", "Add completed!");
                //            return RedirectToAction("Index", "Home");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "ModelState is not valid");
                return View();
            }
        }
//        public ActionResult Delete(int Ahihiid)
//        {
//            MemoryStream ms = new MemoryStream();
//            DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Models.Laptop));
//            dc.WriteObject(ms, Ahihiid);
//            wc.Headers["content-type"] = "application/json";
//            wc.UploadData(url + "DeleteMovie?MovieId=" + id, "DELETE", ms.ToArray());
//            return Redirect(Request.UrlReferrer.PathAndQuery);
//        }

        public ActionResult Delete(string Ahihiid)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer dc = new DataContractJsonSerializer(typeof(Models.Laptop));
            dc.WriteObject(ms, Ahihiid);
            wc.Headers["content-type"] = "application/json";
            wc.UploadData(url + "DeleteMovie?MovieId=" + Ahihiid, "DELETE", ms.ToArray());
            //var model = JsonConvert.DeserializeObject<IEnumerable<Models.Laptop>>(wc.DownloadString(url + "DeleteMovie/" + MovieId));
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }
    }
}