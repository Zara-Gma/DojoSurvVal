using System.Collections.Generic;
using DbConnection;
using DojoSurvVal.Models;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvVal.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet("users/all")]
        public IActionResult All()
        {
            List<Dictionary<string, object>> allUsers
                = DbConnector.Query("SELECT * FROM users");
            return View(allUsers);
        }

        [HttpGet("users/new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("users/create")]
        public IActionResult Create(User newUser)
        {

            if (ModelState.IsValid)
            {
                string insertSql = $@"
                    INSERT INTO users (FullName, Email, DojoLocation, Language, Comments)
                    VALUES (
                        '{newUser.FullName}', 
                        '{newUser.Email}', 
                        '{newUser.DojoLocation}', 
                        '{newUser.Language}', 
                        '{newUser.Comments}')
                ";

                DbConnector.Execute(insertSql);
                return RedirectToAction("All");
            }
            else
            {
                return View("New");
            }
        }
    }
}