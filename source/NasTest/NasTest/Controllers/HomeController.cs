using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace NasTest.Controllers
{   
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string permalink)
        {
            //var s = MimeMapping.GetMimeMapping(@"D:\Backupsayyar.rar");
            //FtpWebRequest 

            //AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            //WindowsIdentity idnt = new WindowsIdentity(username, password);

            //WindowsImpersonationContext context = idnt.Impersonate();

            //File.Copy(@"\\192.100.0.2\temp", @"D:\WorkDir\TempDir\test.txt", true);

            //context.Undo();

            return View();
        }

        //public ActionResult DisplayPhoto()
        //{
        //    //Your code to check your cache and get the image goes here 
        //    //...
        //    //return File(@"D:\the new born baby\DSC03926.JPG", "image/jpeg");
        //    return new HttpStatusCodeResult(HttpStatusCode.NotModified);
        //}

        public ActionResult DisplayPhoto()
        {
            DateTime lastModified = System.IO.File.GetLastWriteTime(@"C:\Users\Saif\Pictures\Disney-Frozen-Movie-winter-arendelle-wallpaper.jpg");
            var image = System.IO.File.ReadAllBytes(@"C:\Users\Saif\Pictures\Disney-Frozen-Movie-winter-arendelle-wallpaper.jpg");
            if (image == null)
                throw new HttpException(404, "Image not found");
            if (!String.IsNullOrEmpty(Request.Headers["If-Modified-Since"]))
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                var lastMod = DateTime.ParseExact(Request.Headers["If-Modified-Since"], "r", provider).ToLocalTime();
                //int result = DateTime.Compare(lastMod, lastModified);
                TimeSpan t = lastModified.Subtract(lastMod);
                if (t.TotalSeconds < 1)
                {
                    //Response.StatusCode = 304;
                    //Response.StatusDescription = "Not Modified";
                    //return Content(String.Empty);
                    return new HttpStatusCodeResult(HttpStatusCode.NotModified);
                    
                }
            }

            
            var stream = new MemoryStream(image);
            Response.Cache.SetCacheability(HttpCacheability.Public);
            Response.Cache.SetLastModified(lastModified);
            return File(stream, "image/jpeg");
        }
    }
}