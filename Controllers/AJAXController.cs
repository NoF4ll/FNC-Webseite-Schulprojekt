using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProjekt_Beispiel.Models.db;
using WebProjekt_Beispiel.Models;

namespace WebProjekt_Beispiel.Controllers
{
    public class AJAXController : Controller
      {
      

        public JsonResult getAllUsers()
        {
            IRepositoryArticle rep = new RepositoryArticle();
            try
            {
                

                rep.Open();
                List<Registration> allUsers = rep.GetAllUsers();

                if(allUsers != null)
                {
                    return Json(allUsers);
                    
                }
                else
                {
                    return Json("NoArticles");
                }

            }
            catch (Exception)
            {
                return Json("Fehler");
            }
            finally{
                rep.Close();
            }
        }

       
    }
}
