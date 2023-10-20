using finalcollege.Models;
using finalcollege.Repository;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalcollege.Controllers
{
    public class HomeController : Controller
    {
        // Home page for all User
        /// <summary>
        /// Home page for all User
        /// </summary>
        /// <returns></returns>
        public ActionResult Home()
        {
            return View();
        }

        // Contact page for all user
        /// <summary>
        /// Contact page for all user
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Contact(Contact contact)
        {
            try
            {
                UserRepo user = new UserRepo();
                if (user.Contact(contact))
                {
                    ViewBag.Contact = contact;
                }
                return RedirectToAction("Home");
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);

                return View();
            }


        }

        // Academics page
        /// <summary>
        /// Academics
        /// </summary>
        /// <returns></returns>
        public ActionResult Academics()
        {
            return View();
        }


        // Signup page (GET request)
        /// <summary>
        /// Signup page (GET the View)
        /// </summary>
        /// <returns></returns>
        public ActionResult Signup()
        {
            return View();
        }

        // Signup page (POST request)
        /// <summary>
        ///This action displays the signup page for users to enter their registration details.
        /// </summary>
        /// <param name="reg"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Signup(Registermodel reg)
        {
            try
            {
                UserRepo obj = new UserRepo();


                if (obj.Createdata(reg))
                {
                    ViewBag.create = "Signup successfully";
                }
                else
                {
                    ViewBag.email = "Email Already Taken Please Use Another Email ";
                }
                return View();
            }
            catch(Exception exception)
            {
                errorlog.LogError(exception);

                return View();
            }
        }

        // Signin page (GET request)
        /// <summary>
        /// This action get the  users to enter their registration details.
        /// </summary>
        /// <returns></returns>
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(Registermodel registermodel)
        {
            try
            {
                int id;
                int result;
                string name;

                UserRepo obj = new UserRepo();

                // Verify the user's login credentials and get the user's ID and role.
                bool flag = obj.VerifySignIn(registermodel, out id, out result, out name);

                // Check if login was successful.
                if (flag)
                {
                    if (result == 1)
                    {
                        return RedirectToAction("Course", "UserAdmission", new { id = Session["Id"], name = Session["FirstName"] });
                    }
                    else if (result == 2)
                    {
                        return RedirectToAction("Home", "Admin", new { id = Session["Id"], name = Session["FirstName"] });
                    }
                }
                else
                {
                    ViewBag.invalid = "Invalid Username And Password";
                }
                return View();
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }

        public ActionResult Forgetpassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Forgetpassword(Registermodel registermodel)
        {
            UserRepo user = new UserRepo();
            bool i = user.Forgetpassword(registermodel);
            if (i)
            {
                return RedirectToAction("Signin", "Home");
            }
            else
            {
                ViewBag.Message = "Invaild Email and Phonenumber";
            }

            return View();
        }
    }
}
