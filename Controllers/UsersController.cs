using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ConstruccionDeSoftware_ProyectoFinal;

namespace ConstruccionDeSoftware_ProyectoFinal.Controllers
{
    public class UsersController : Controller
    {
    
        private AzureDBEntity db = new AzureDBEntity();

        List<List> collection = new List<List>();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,Lastname,Username,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,Lastname,Username,Password,Email")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {
                //Here we do the validation then send the user to wherever they need to go.
                
                
                    //Check if string is null or not, else it will throw errors
                    //if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password))
                    //{
                        //We find the first match with our username and password, this will give us an User object
                        AzureDBEntity dbEntity = new AzureDBEntity();
                        var user = dbEntity.Users.FirstOrDefault(e => e.Username == username && e.Password == password);

                        if (user != null)
                        {
                            //Si existe el usuario, crear un cookie y redireccionarlo a su pagina de listas.
                            FormsAuthentication.SetAuthCookie(user.Username, true);
                            //Someone needs to make a view and a controller that's unique to the user that just logged in.....
                            return RedirectToAction("Index", "Lists");
                        }
                        else
                        {
                            return RedirectToAction("Login", new {message = "No se encontraron los datos" });
                        }

                    //}
                    //else
                    //{
                    //return RedirectToAction("Login", new { message = "Favor verificar tus datos e intentar el login mas tarde" });
                    
                    //}

            }

            //If it's not valid then just return the View.
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}
