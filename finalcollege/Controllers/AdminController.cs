using finalcollege.Models;
using finalcollege.Repository;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace finalcollege.Controllers
{
    public class AdminController : Controller
    {
        // HOMEPAGE
        /// <summary>
        /// Home page for the admin.
        /// </summary>
        [Authorize]
        public ActionResult Home()
        {
            return View(); 
        }



        // GET: Admin/AddAdmin
        /// <summary>
        /// adding the new admin  view page 
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddnewAdmin()
        {
            return View();  
        }




        /// <summary>
        /// add new admin if create a new admin
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        // POST: Admin/AddAdmin
        [Authorize]
        [HttpPost]
        public ActionResult AddnewAdmin(Registermodel admin)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                if (repo.AddAdmin(admin))
                {
                    ViewBag.create = "create successfully"; 
                }
                else
                {
                    ViewBag.email = "Email Already Taken Please Use Another Email ";
                }

                return View();  
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
              
        }




        /// <summary>
        /// show the users details if user apply the course means that userdetails will show there
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult UserDetails()
        {
            try
            {
                Adminrepo user = new Adminrepo();
                List<UserAdmissionmodel> Userlist = user.UserDetails();
                return View(Userlist);
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        /// <summary>
        /// the admin was perform the this action  pending and rejected and confirm  when click userstatus will change
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult status(int itemId, int Status)
        {
            try
            {
                Adminrepo admin = new Adminrepo();
                bool k = admin.StatusChange(itemId, Status);
                return View();
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }




        /// <summary>
        /// show the admin details
        /// </summary>
        /// <returns></returns>
        // ADMIN DETAILS
        [Authorize]
        public ActionResult Admindetails()
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                List<Registermodel> Adminlist = obj.Adminlist();  
                return View(Adminlist);  
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);

                return View();
            }

        }




        /// <summary>
        /// admin only delete the admin details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE ADMIN
        [Authorize]
        public ActionResult AdminDelete(int id)
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                obj.DeleteAdmins(id);  
                return RedirectToAction("Admindetails");  
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }




        /// <summary>
        /// when admin login show this home page course details ug,pg,pc
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult Course()
        {
            return View();  
        }




        /// <summary>
        /// admin can get postgraduate course page
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult CreateCoursePg()
        {
            return View();  
        }
        /// <summary>
        /// admin can create Postgraduate course 
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult CreateCoursePg(Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                if(repo.AddPgCourse(cus))
                {
                    ViewBag.create = "CourseCreated successfully";
                }
                else
                {
                    ViewBag.msg = "Courseid or Coursename  Already Taken Please Use Another Courseid or Coursename ";
                }
                return View();  
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }




        /// <summary>
        /// admin can get professionalcourse get page
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult CreateCourseProfessional()
        {
            return View(); 
        }

        /// <summary>
        /// admin  added the professionalcourse this page
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult CreateCourseProfessional(Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                if(repo.AddProfessinoalCourse(cus))
                {
                    ViewBag.create = "CourseCreated successfully";
                }
                else
                {
                    ViewBag.msg = "Courseid or Coursename  Already Taken Please Use Another Courseid or Coursename ";
                }
                return View();  
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }





        /// <summary>
        /// admin can see the create page of undergraduate
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult CreateCourseUg()
        {
            return View();  
        }

        /// <summary>
        /// admin can add the Undergraduate course
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult CreateCourseUg(Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                if(repo.AddUgCourse(cus))
                {
                    ViewBag.create = "CourseCreated successfully";
                }
                else
                {
                    ViewBag.msg = "Courseid or Coursename  Already Taken Please Use Another Courseid or Coursename ";
                }
                return View(); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }





        /// <summary>
        /// show the list of ug program
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
        /// show the pg program
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
        /// show the list of professionalcourse
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
        /// get the courseid and delete pg course
        /// </summary>
        /// <param name="Courseid"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult DeleteUg(string Courseid)
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                obj.Deletedata(Courseid); 
                return RedirectToAction("UgProgram"); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }





        /// <summary>
        /// get the courseid and delete pg course
        /// </summary>
        /// <param name="Courseid"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult DeletePg(string Courseid)
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                obj.Deletedata(Courseid); 
                return RedirectToAction("PgProgram"); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }






        /// <summary>
        /// get the courseid and delete pc course
        /// </summary>
        /// <param name="Courseid"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult DeletePc(string Courseid)
        {
            try
            {
                Adminrepo obj = new Adminrepo();
                obj.Deletedata(Courseid); 
                return RedirectToAction("PcProgram"); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }





        /// <summary>
        /// edit page getting the all details in that based on the id fetch the data then show the page 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="cus"></param>
        /// <returns></returns>

        // GET: Admin/Editcourse (UG)
        [Authorize]
        public ActionResult EditCourseUg(int ID, Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                return View(model: repo.Courseupdate(ID).Find(e => e.ID == ID)); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }

        /// <summary>
        ///this part only update the value and save 
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        // POST: Admin/Editcourse (UG)
        [Authorize]
        [HttpPost]
        public ActionResult EditCourseUg(Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                repo.Update(cus); // Updates a UG course
                ViewBag.Message = "Course updated successfully"; 
                return View();
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }








        /// <summary>
        /// edit page getting the all details in  based on the id fetch the data then show the page 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="cus"></param>
        /// <returns></returns>

        // GET: Admin/Editcourse (PG)
        [Authorize]
        public ActionResult EditCoursePg(int ID, Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                return View(model: repo.Courseupdate(ID).Find(e => e.ID == ID)); 
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }

        /// <summary>
        /// this page only update the value that action only admin can do
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        // POST: Admin/Editcourse (PG)
        [Authorize]
        [HttpPost]
        public ActionResult EditCoursePg(Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                repo.Update(cus); 


                ViewBag.Message = "Course updated successfully"; 
                return View();
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }






        /// <summary>
        /// get the all value an set to responsive textbox from database based on the id
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="cus"></param>
        /// <returns></returns>
        [Authorize]
        public ActionResult EditCoursePc(int ID, Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                return View(model: repo.Courseupdate(ID).Find(e => e.ID == ID));
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }

        // POST: Admin/Editcourse (PG)
        /// <summary>
        /// if admin can update the pc program and  
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        public ActionResult EditCoursePc(Coursemodel cus)
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                repo.Update(cus); 

               
                ViewBag.Message = "Course updated successfully"; 
                return View();
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }
        }
        [Authorize]
        public ActionResult ContactDetails()
        {
            try
            {
                Adminrepo repo = new Adminrepo();
                List<Contact> contactlist = repo.Contactform();
                return View(contactlist);
            }
            catch (Exception exception)
            {
                errorlog.LogError(exception);
                return View();
            }

        }
    }
}
