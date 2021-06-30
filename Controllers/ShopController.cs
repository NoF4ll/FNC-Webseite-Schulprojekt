using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebProjekt_Beispiel.Models;
using WebProjekt_Beispiel.Models.db;
using System.Data.Common;

namespace WebProjekt_Beispiel.Controllers
{    
    public class ShopController : Controller
    {
       IRepositoryArticle rep = new RepositoryArticle();
        public IActionResult Index()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllArticles());
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbankfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }

        public IActionResult ArticleView()
        {
            return View();
        }
        public IActionResult ArticleComments()
        {
            return View();
        }

        public JsonResult GetAllComments()
        {
            try
            {
                rep.Open();
                return Json(rep.GetAllComments());
            }
            catch (Exception e)
            {
                return Json("Error");
            }
            finally
            {
                rep.Close();
            }
        }

        [HttpGet]
        public IActionResult CreateComments()
        {
            return View(new Comment());
        }

        [HttpPost]
        public IActionResult CreateComments(Comment comment)
        {
            if (comment == null)
            {
                return RedirectToAction("CreateComments()");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    rep.Open();
                    if (rep.InsertComment(comment))
                    {
                        return View("Message", new Message("Datenbank-Erfolgt", "Der Kommentar wurde erfolgreich abgespeichert!"));
                    }
                }
                catch (DbException)
                {
                    return View("Message", new Message("Datenbank-Fehler", "Der Kommentar konnte nicht abgespeichert werden!", "Probieren Sie es bitte später erneut!"));
                }
                finally
                {
                    rep.Close();
                }
                return RedirectToAction("shop", "ArticleComments");
            }
            return View(comment);
        }

        public IActionResult ReturnedArticles()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllReturnedArticles());
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbankfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }

        [HttpPost]
        public IActionResult Update(int id)
        {
            try
            {
                rep.Open();
                return View("UpdateArticles",rep.getArticleById(id));
            }
            catch (Exception ex)
            {
                return View("Message", new Message("Datenbankfehler", ex.Message));
            }
            finally
            {
                rep.Close();
            }
        }
        [HttpGet]
        public IActionResult Update(Article a)
        {
            return View();
        }


        [HttpGet]
        public IActionResult ReturnArticles()
        {
            return View(new Article());
        }

        [HttpPost]
        public IActionResult ReturnArticles(Article newArticle)
        {
            if (newArticle == null)
            {
                return RedirectToAction("ReturnArticles");
            }

            ValidateArticleData(newArticle);

            if (ModelState.IsValid)
            {

                try
                {

                    rep.Open();


                    if (rep.Insert(newArticle))
                    {
                   
                        return View("Message", new Message("Datenbank-Erfolgt",
                            "Der Artikel wurde erfolgreich abgespeichert!"));
                    }

                }
                catch (DbException)
                {
        
                    return View("Message", new Message("Datenbank-Fehler",
                        "Der Artikel konnte nicht abgespeichert werden!",
                        "Probieren Sie es bitte später erneut!"));
                }
                finally
                {

                    rep.Close();
                }


        
                return RedirectToAction("index", "home");
            }

        
            return View(newArticle);
        }
 
        public IActionResult Delete(int id)
        {
            try
            {
                rep.Open();
                if (rep.Delete(id))
                {
                    return View("Message", new Message("Datenbank", "Der Artikel wurde erfolgreich gelöscht"));
                }
                else
                {
                    return View("Message", new Message("Datenbankfehler", "Der Artikel konnte nicht gelöscht werden"));
                }
            }
            catch (Exception e)
            {
                return View("Message", new Message("Datenbankfehler", e.Message));
            }
            finally
            {
                rep.Close();
            }
        }


        

        private void ValidateArticleData(Article a)
        {
            if (a == null)
            {
                return;
            }

          
            a.Articlename = a.Articlename ?? "";

           
            if (a.Articlename == null || a.Articlename.Length < 3)
            {
                
                ModelState.AddModelError(nameof(Article.Articlename), "Artikelname muss mind. 3 Zeichen lang sein!");
            }

            a.Firstname = a.Firstname ?? "";

            
            if (a.Firstname == null || a.Firstname.Length < 3)
            {
                
                ModelState.AddModelError(nameof(Article.Firstname), "Der Vorname muss länger als 3 zeichen lang sein");
            }

            if (a.Lastname == null || a.Lastname.Length < 3)
            {
                
                ModelState.AddModelError(nameof(Article.Lastname), "Der Nachname muss länger als 3 zeichen lang sein");
            }


        }
    }
}
