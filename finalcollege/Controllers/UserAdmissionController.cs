using finalcollege.Models;
using finalcollege.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace finalcollege.Controllers
{
    public class UserAdmissionController : Controller
    {

        /// <summary>
        /// show the overview of course
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Course()
        {
            return View();
        }

        /// <summary>
        /// if user can apply one course  means get the user id fetch the details from register table and put the corresponding textbox
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ApplyUser(int ID)
        {
            try
            {
                AdmissionRepository repo = new AdmissionRepository();
                return View(model: repo.ApplyUser(ID).Find(e => e.ID == ID)); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        /// <summary>
        /// apply means get the courseid,name,program this parameter will be get and insert the that table 
        /// </summary>
        /// <param name="admission"></param>
        /// <param name="Program"></param>
        /// <param name="Courseid"></param>
        /// <param name="Coursename"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult ApplyUser(UserAdmissionmodel admission, string Program, string Courseid, string Coursename)
        {
            try
            {
                AdmissionRepository repo = new AdmissionRepository();

            
                if (repo.UpdateUserAdmission(admission, Program, Courseid, Coursename))
                {
                    ViewBag.Message = "Apply successfully"; 
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Seats sold out please choose another course "; 
                    return View();
                }
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }


        /// <summary>
        /// user can view our profile 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult ShowProfile(int ID)
        {
            try
            {

                AdmissionRepository admission = new AdmissionRepository();
                List<UserAdmissionmodel> profile = admission.UserProfile(ID);
                return View(profile);
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }

        }


        /// <summary>
        /// list out the ugprograms 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult UgProgram()
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                List<Coursemodel> Courselist = obj.Ugprogram(); 
                return View(Courselist); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        /// <summary>
        /// list out the pg program
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult PgProgram()
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                List<Coursemodel> Courselist = obj.Pgprogram(); 
                return View(Courselist); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        /// <summary>
        /// list out the professionalcourse
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult PcProgram()
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                List<Coursemodel> Courselist = obj.Pcprogram(); 
                return View(Courselist); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }

        /// <summary>
        /// edit profile page get the id from user and fetch the details our apply form details 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditProfile(int ID )
        {
            try
            {
                AdmissionRepository repo = new AdmissionRepository();
                return View(model: repo.EditUserProfile(ID).Find(e => e.ID == ID)); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        /// <summary>
        /// update the our profile
        /// </summary>
        /// <param name="admission"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult EditProfile(UserAdmissionmodel admission)
        {
            try
            {
                AdmissionRepository repo = new AdmissionRepository();
                repo.Update(admission); 

                ViewBag.Message = "profile updated successfully"; 
                return RedirectToAction("EditProfile");
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        /// <summary>
        /// show our status confirm or waiting or cancel and other details
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult Status(int ID)
        {
            try
            {
                AdmissionRepository userlist = new AdmissionRepository();
                List<UserAdmissionmodel> user = userlist.Status(ID);

                return View(user);
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
    }
}
