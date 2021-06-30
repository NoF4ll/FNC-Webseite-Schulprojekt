using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProjekt_Beispiel.Models;
using WebProjekt_Beispiel.Models.db;

namespace WebProjekt_Beispiel.Controllers
{

    
    public class RegistrationController : Controller
    {
        IRepositoryArticle con = new RepositoryArticle();

        [HttpGet]
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            con.Open();
            bool loginexit = con.loginInsert(login.username, login.password);

            if (loginexit == true)
            {
                return View("Succes");
            }

            else
            {
                return View("Failed");
            }
        }

        [HttpGet]
        public IActionResult RegistrationView()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateNewUser()
        {
            return View(new Registration()); 
        }



        [HttpPost]
        public IActionResult CreateNewUser(Registration user)
        {

            if (ModelState.IsValid)
            {

                try
                {

                    con.Open();


                    if (con.InsertUser(user))
                    {

                        return View("Message", new Message("Datenbank-Erfolgt",
                            "Sie wurden erfolgreich Registriert!"));
                    }

                }
                catch (Exception)
                {

                    return View("Message", new Message("Datenbank-Fehler",
                        "Dein Profil konnte nicht abgespeichert werden!",
                        "Probieren Sie es bitte später erneut!"));
                }
                finally
                {

                    con.Close();
                }



                return RedirectToAction("index", "home");
            }


            return View(new Registration());
        }
            


        


    }
}
