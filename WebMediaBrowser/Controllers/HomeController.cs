using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMediaBrowser.Models;
using ExceptionsManager;

namespace WebMediaBrowser.Controllers
{

    public class HomeController : Controller
    {

        static List<MoviesModel> allMovies = new List<MoviesModel>();

        [HttpPost]
        public ActionResult Index([Bind(Include = "username, password")] UserViewDTO user)
        {
            /// Moved out to the service to handle
            //try
            //{

            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            {
                ViewBag.Error = "No empty fields are allowed!";
                return View("Index");
            }

            UserValidationWSRef.UserValidationWSClient userSrv = new UserValidationWSRef.UserValidationWSClient();
            UserValidationWSRef.UserWSDTO userWSDTO = new UserValidationWSRef.UserWSDTO();
            userWSDTO.Username = user.Username;
            userWSDTO.Password = user.Password;

            userWSDTO = userSrv.ValidateUser(userWSDTO);

            if (!string.IsNullOrEmpty(userWSDTO.ErrorMessage))
            {
                ViewBag.Error = userWSDTO.ErrorMessage;
            }
            else
            {
                Session["UserLoggedIn"] = userWSDTO;
                FetchAllMovies();
            }

            /// Moved out to the service to handle
            //}
            //catch (DBConcurrencyException ex)
            //{
            //    ViewBag.Error = "Error connecting to the Database.";
            //    Console.WriteLine(ex.Message);
            //}
            //catch (DataValidationError ex)
            //{
            //    ViewBag.Error = ex.Message + "Please try again.";
            //}



            //if (ModelState.IsValid)
            //{
            //    //db.Movies.Add(user);
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(allMovies);
        }

        public ActionResult Index()
        {
            return View(allMovies);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();

            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public void FetchAllMovies()
        {
            MediaManagerWSRef.Service1Client mediaSrv = new MediaManagerWSRef.Service1Client();
            DataSet movies = mediaSrv.QueryMovies();

            allMovies = movies.Tables[0].AsEnumerable().Select(
            dataRow => new MoviesModel
            {
                Title = dataRow.Field<string>("Title"),
                Year = dataRow.Field<int>("PublishYear"),
                Director = dataRow.Field<int>("Director"),
                Genre = dataRow.Field<int>("Genre")
            }).ToList<MoviesModel>();
        }

        //[HttpGet]
        //public ActionResult Test(string user, string password)
        //{
        //    string message = string.Format("Welcome {0}, your password is {1}", user, password);
        //    return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

    }
}
