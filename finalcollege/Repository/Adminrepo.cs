using finalcollege.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace finalcollege.Repository
{
    public class Adminrepo
    {
        private SqlConnection connect;
        public void connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["StudentCon"].ToString();
            connect = new SqlConnection(connection);
        } 

        /// <summary>
        /// CREATE ADMIN
        /// </summary>
        /// <param name="ad"></param>
        /// <returns></returns>
        public bool AddAdmin(Registermodel admin)
        {
            try
            {
                connection();
                SqlCommand cmd1 = new SqlCommand("SP_CheckEmail", connect);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Email", admin.Email);
                connect.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read() == true)
                {
                    return false;
                }
                else
                {
                    connection();

                    SqlCommand cmd = new SqlCommand("SP_AddAdmin", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Role", 2);
                    cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                    cmd.Parameters.AddWithValue("@Gender", admin.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", admin.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", admin.Address);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@Password", Encrypt(admin.Password));

                    connect.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            finally
            {
                connect.Close();
            }

        }

        /// <summary>
        /// get the user details if user can apply the course means that details will show the admin then 
        /// </summary>
        /// <returns></returns>

        public List<UserAdmissionmodel> UserDetails()
        {
            try
            {
                connection();
                connect.Open();

                List<UserAdmissionmodel> Userlist = new List<UserAdmissionmodel>();

                SqlCommand cmd = new SqlCommand("SP_FullUserDetails", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);


                foreach (DataRow list in dt.Rows)
                {
                    Userlist.Add(
                        new UserAdmissionmodel
                        {
                            Program = Convert.ToString(list["Program"]),
                            Courseid = Convert.ToString(list["Courseid"]),
                            Coursename = Convert.ToString(list["Coursename"]),
                            ID = Convert.ToInt32(list["ID"]),
                            FirstName = Convert.ToString(list["FirstName"]),
                            LastName = Convert.ToString(list["LastName"]),
                            Gender = Convert.ToString(list["Gender"]),
                            Email = Convert.ToString(list["Email"]),
                            HighSchoolName = Convert.ToString(list["HighSchoolName"]),
                            HighSchoolGroup = Convert.ToString(list["HighSchoolGroup"]),
                            HighSchoolMark = Convert.ToInt32(list["HighSchoolMark"]),
                            SecondarySchoolName = Convert.ToString(list["SecondarySchoolName"]),
                            SecondarySchoolMark = Convert.ToInt32(list["SecondarySchoolMark"]),
                            CommunityCertificate = (byte[])(list["CommunityCertificate"]),
                            Photo = (byte[])(list["Photo"]),
                            Status = Convert.ToInt32(list["Status"])

                        });
                }
                return Userlist;
            }
            finally
            {
                connect.Close();
            }
        }
        /// <summary>
        /// above code fetch the details and then admin can approval or waiting or cancel these are the function will perform
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public bool StatusChange(int ID,int Status)
        {
            try
            {
                connection();

                SqlCommand cmd = new SqlCommand("SP_UpdateStatus", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.Parameters.AddWithValue("Status", Status);
                connect.Open();
                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                connect.Close();
            }

        }

        /// <summary>
        ///  ADMIN LIST  show thw number of admin list then our details
        /// </summary>
        /// <returns></returns>
        public List<Registermodel> Adminlist()
        {
            try
            {
                connection();
                connect.Open();

                List<Registermodel> Adminlist = new List<Registermodel>();

                SqlCommand cmd = new SqlCommand("SP_AdminList", connect);
                cmd.Parameters.AddWithValue("Role", 2);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                foreach (DataRow list in dt.Rows)
                {
                    Adminlist.Add(
                        new Registermodel
                        {
                            Id = Convert.ToInt32(list["Id"]),
                            FirstName = Convert.ToString(list["FirstName"]),
                            LastName = Convert.ToString(list["LastName"]),
                            Gender = Convert.ToString(list["Gender"]),
                            PhoneNumber = Convert.ToString(list["PhoneNumber"]),
                            Address = Convert.ToString(list["Address"]),
                            Email = Convert.ToString(list["Email"]),
                            Password = Convert.ToString(list["Password"]),

                        });
                }
                return Adminlist;
            }
            finally
            {
                connect.Close();
            }
        }


        /// <summary>
        /// DELTETE ADMIN admin can delete the other admin its perform based on id
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool DeleteAdmins(int id)
        {
            try
            {
                connection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("SP_DeleteAdmin", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", id);


                int i = cmd.ExecuteNonQuery();

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                connect.Close();
            }

        }

        /// <summary>
        /// ADDCOURSE added the pgcourse admin
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        
        public bool AddPgCourse(Coursemodel cus)
        {
            try
            {
                connection();
                SqlCommand cmd1 = new SqlCommand("SP_CheckCourseidname", connect);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Courseid", cus.Courseid);
                cmd1.Parameters.AddWithValue("@Coursename", cus.Coursename);
                connect.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read() == true)
                {
                    return false;
                }
                else
                {
                    connection();
                    SqlCommand cmd = new SqlCommand("SPI_Course", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Program", cus.Program);
                    cmd.Parameters.AddWithValue("@Courseid", cus.Courseid);
                    cmd.Parameters.AddWithValue("@Coursename", cus.Coursename);
                    cmd.Parameters.AddWithValue("@Description", cus.Description);
                    cmd.Parameters.AddWithValue("@Duration", cus.Duration);
                    cmd.Parameters.AddWithValue("@Availablesheet",4);

                    connect.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            finally
            {
                connect.Close();
            }

        }
        /// <summary>
        /// added the ugcourse only admin
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public bool AddUgCourse(Coursemodel cus)
        {
            try
            {
                connection();
                SqlCommand cmd1 = new SqlCommand("SP_CheckCourseidname", connect);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Courseid", cus.Courseid);
                cmd1.Parameters.AddWithValue("@Coursename", cus.Coursename);
                connect.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read() == true)
                {
                    return false;
                }
                else
                {
                    connect.Close();
                    connection();
                    SqlCommand cmd = new SqlCommand("SPI_Course", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Program", cus.Program);
                    cmd.Parameters.AddWithValue("@Courseid", cus.Courseid);
                    cmd.Parameters.AddWithValue("@Coursename", cus.Coursename);
                    cmd.Parameters.AddWithValue("@Description", cus.Description);
                    cmd.Parameters.AddWithValue("@Duration", cus.Duration);
                    cmd.Parameters.AddWithValue("@Availablesheet", 4);

                    connect.Open();

                    int i = cmd.ExecuteNonQuery();


                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            finally
            {
                connect.Close();
            }

        }
        /// <summary>
        /// added the professional course 
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public bool AddProfessinoalCourse(Coursemodel cus)
        {
            try
            {
                connection();
                SqlCommand cmd1 = new SqlCommand("SP_CheckCourseidname", connect);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Courseid", cus.Courseid);
                cmd1.Parameters.AddWithValue("@Coursename", cus.Coursename);
                connect.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read() == true)
                {
                    return false;
                }
                else
                {
                    connection();
                    SqlCommand cmd = new SqlCommand("SPI_Course", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Program", cus.Program);
                    cmd.Parameters.AddWithValue("@Courseid", cus.Courseid);
                    cmd.Parameters.AddWithValue("@Coursename", cus.Coursename);
                    cmd.Parameters.AddWithValue("@Description", cus.Description);
                    cmd.Parameters.AddWithValue("@Duration", cus.Duration);
                    cmd.Parameters.AddWithValue("@Availablesheet",4);

                    connect.Open();

                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            finally
            {
                connect.Close();
            }

        }

        /// <summary>
        /// COURSELIST  show the ugproram listView
        /// </summary>
        /// <returns></returns>

        public List<Coursemodel> Ugprogram()
        {
            try
            {
                connection();
                connect.Open();

                List<Coursemodel> Courselist = new List<Coursemodel>();

                SqlCommand cmd = new SqlCommand("SPS_Courseprogram", connect);
                cmd.Parameters.AddWithValue("@Program", "UG");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                foreach (DataRow list in dt.Rows)
                {
                    Courselist.Add(
                        new Coursemodel
                        {
                            ID = Convert.ToInt32(list["ID"]),
                            Program = Convert.ToString(list["Program"]),
                            Courseid = Convert.ToString(list["Courseid"]),
                            Coursename = Convert.ToString(list["Coursename"]),
                            Description = Convert.ToString(list["Description"]),
                            Duration = Convert.ToString(list["Duration"]),
                            Availablesheet = Convert.ToInt32(list["Availablesheet"])
                        });
                }
                return Courselist;
            }
            finally
            {
                connect.Close();
            }
        }
                        /// <summary>
                        /// show the pgcourse for list format
                        /// </summary>
                        /// <returns></returns>

        public List<Coursemodel> Pgprogram()
        {
            try
            {
                connection();
                connect.Open();

                List<Coursemodel> Courselist = new List<Coursemodel>();

                SqlCommand cmd = new SqlCommand("SPS_Courseprogram", connect);
                cmd.Parameters.AddWithValue("@Program", "PG");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);


                foreach (DataRow list in dt.Rows)
                {
                    Courselist.Add(
                        new Coursemodel
                        {
                            ID = Convert.ToInt32(list["ID"]),
                            Program = Convert.ToString(list["Program"]),
                            Courseid = Convert.ToString(list["Courseid"]),
                            Coursename = Convert.ToString(list["Coursename"]),
                            Description = Convert.ToString(list["Description"]), // Change this to Convert.ToString
                            Duration = Convert.ToString(list["Duration"]),
                            Availablesheet = Convert.ToInt32(list["Availablesheet"])
                        });
                }
                return Courselist;
            }
            finally
            {
                connect.Close();
            }
        }
        /// <summary>
        /// show the professional course in listview
        /// </summary>
        /// <returns></returns>
        public List<Coursemodel> Pcprogram()
        {
            try
            {
                connection();
                connect.Open();

                List<Coursemodel> Courselist = new List<Coursemodel>();

                SqlCommand cmd = new SqlCommand("SPS_Courseprogram", connect);
                cmd.Parameters.AddWithValue("@Program", "PC");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);
      

                foreach (DataRow list in dt.Rows)
                {
                    Courselist.Add(
                        new Coursemodel
                        {
                            ID = Convert.ToInt32(list["ID"]),
                            Program = Convert.ToString(list["Program"]),
                            Courseid = Convert.ToString(list["Courseid"]),
                            Coursename = Convert.ToString(list["Coursename"]),
                            Description = Convert.ToString(list["Description"]), // Change this to Convert.ToString
                            Duration = Convert.ToString(list["Duration"]),
                            Availablesheet = Convert.ToInt32(list["Availablesheet"])
                        });
                }
                return Courselist;
            }
            finally
            {
                connect.Close();
            }
        }




                        /// <summary>
                        /// DELETECOURSE delete the course based on the courseid
                        /// </summary>
                        /// <param name="Courseid"></param>
                        /// <returns></returns>
        public bool Deletedata(string Courseid)
        {
            try
            {
                connection();
                connect.Open();
                SqlCommand cmd = new SqlCommand("SPD_Course", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Courseid", Courseid);


                int i = cmd.ExecuteNonQuery();


                if (i >= 1)
                { 
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                connect.Close();
            }

        }

        /// <summary>
        /// UPDATECOURSE FETCH fetch the values based on the id 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<Coursemodel> Courseupdate(int ID)
        {
            try
            {
                connection();
                connect.Open();

                List<Coursemodel> Courselist = new List<Coursemodel>();
                SqlCommand cmd = new SqlCommand("SPS_CourseDetails", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                foreach (DataRow list in dt.Rows)
                {
                    Courselist.Add(

                      new Coursemodel
                      {
                          ID = Convert.ToInt32(list["ID"]),
                          Program = Convert.ToString(list["Program"]),
                          Courseid = Convert.ToString(list["Courseid"]),
                          Coursename = Convert.ToString(list["Coursename"]),
                          Description = Convert.ToString(list["Description"]),
                          Duration = Convert.ToString(list["Duration"])
                      }
                    ); ;
                }

                return Courselist;
            }
            finally
            {
                connect.Close();
            }
        }
             
            
        /// <summary>
        /// COURSE UPADTE that coressponding values will show the textbox next admin can updated 
        /// </summary>
        /// <param name="cus"></param>
        /// <returns></returns>
        public bool Update(Coursemodel cus)
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("SPU_Course", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", cus.ID);
                cmd.Parameters.AddWithValue("@Program", cus.Program);
                cmd.Parameters.AddWithValue("@Courseid", cus.Courseid);
                cmd.Parameters.AddWithValue("@Coursename", cus.Coursename);
                cmd.Parameters.AddWithValue("@Description", cus.Description);
                cmd.Parameters.AddWithValue("@Duration", cus.Duration);
                cmd.Parameters.AddWithValue("@Availablesheet",4);


                connect.Open();
                int i = cmd.ExecuteNonQuery();
       

                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                connect.Close();
            }
        }
        public List<Contact> Contactform()
        {
            try
            {
                connection();
                connect.Open();
                List<Contact> contctlist = new List<Contact>();
                SqlCommand cmd = new SqlCommand("SP_Contactdetails", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
      

                foreach (DataRow row in dt.Rows)
                {
                    contctlist.Add(new Contact
                    {
                        id = Convert.ToInt32(row["ID"]),
                        Fullname = Convert.ToString(row["Fullname"]),
                        Email = Convert.ToString(row["Email"]),
                        Phonenumber = Convert.ToString(row["Phonenumber"]),
                        Message = Convert.ToString(row["Message"])
                    });
                }
                return contctlist;
            }
            finally
            {
                connect.Close();
            }


        }
        private string Encrypt(string clearText)
        {
            string encryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


    }
}