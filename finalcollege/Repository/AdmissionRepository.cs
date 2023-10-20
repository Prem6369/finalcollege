using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using finalcollege.Models;
using System.Configuration;

namespace finalcollege.Repository
{
    public class AdmissionRepository
    {
        private SqlConnection connect;
        public void connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["StudentCon"].ToString();
            connect = new SqlConnection(connection);

        }



        /// <summary>
        /// user can apply the course means get that user is from user can register the our details that table to 
        /// fetch the details in common value to set this textbox
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<UserAdmissionmodel> ApplyUser(int ID)
        {
            try
            {
                connection();
                connect.Open();

                List<UserAdmissionmodel> profile = new List<UserAdmissionmodel>();
                SqlCommand cmd = new SqlCommand("SP_SelectRegister", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    profile.Add(

                        new UserAdmissionmodel
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Email = Convert.ToString(dr["Email"]),

                        }); ;
                }

                return profile;
            }
            finally
            {
                connect.Close();
            }
        }
        /// <summary>
        /// then update the other field and fetch the course id,name,program this field are get from user and update form
        /// </summary>
        /// <param name="admission"></param>
        /// <param name="Program"></param>
        /// <param name="Courseid"></param>
        /// <param name="Coursename"></param>
        /// <returns></returns>
        public bool UpdateUserAdmission(UserAdmissionmodel admission, string Program, string Courseid, string Coursename)
        {
            try
            {
                // Open the connection
                connection();
                connect.Open();

                // Check the availability of sheets for the given course
                SqlCommand cmd = new SqlCommand("SP_AvailableSheet", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Courseid", Courseid);
                int count = (int)cmd.ExecuteScalar();

                // If there are more than 4 available sheets, return false
                if (count > 4)
                {
                    return false;
                }
                else
                {
                    connect.Close();
                    // Open a new connection
                    connect.Open();

                    // Create a command to insert or update user admission data
                    SqlCommand cmd1 = new SqlCommand("SPI_User", connect);
                    cmd1.CommandType = CommandType.StoredProcedure;

                    // Parameters for the SPI_User stored procedure
                    cmd1.Parameters.AddWithValue("@Program", Program);
                    cmd1.Parameters.AddWithValue("@Courseid", Courseid);
                    cmd1.Parameters.AddWithValue("@Coursename", Coursename);

                    // Parameters for the UserAdmissionmodel properties
                    cmd1.Parameters.AddWithValue("@ID", admission.ID);
                    cmd1.Parameters.AddWithValue("@FirstName", admission.FirstName);
                    cmd1.Parameters.AddWithValue("@LastName", admission.LastName);
                    cmd1.Parameters.AddWithValue("@Gender", admission.Gender);
                    cmd1.Parameters.AddWithValue("@Email", admission.Email);
                    cmd1.Parameters.AddWithValue("@HighSchoolName", admission.HighSchoolName);
                    cmd1.Parameters.AddWithValue("@HighSchoolGroup", admission.HighSchoolGroup);
                    cmd1.Parameters.AddWithValue("@HighSchoolMark", admission.HighSchoolMark);
                    cmd1.Parameters.AddWithValue("@SecondarySchoolName", admission.SecondarySchoolName);
                    cmd1.Parameters.AddWithValue("@SecondarySchoolMark", admission.SecondarySchoolMark);
                    cmd1.Parameters.AddWithValue("@CommunityCertificate", admission.CommunityCertificate);
                    cmd1.Parameters.AddWithValue("@Photo", admission.Photo);
                    cmd1.Parameters.AddWithValue("@Status", 1);

                    // Execute the query
                    int i = cmd1.ExecuteNonQuery();

                    // Close the connection
                    connect.Close();

                    // Check if the query was successful
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
        /// user can login means user id will pass the url so get that id and show that corresponding  user details
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public List<UserAdmissionmodel> UserProfile(int ID)
        {
            try
            {
                connection();
                connect.Open();

                List<UserAdmissionmodel> UserList = new List<UserAdmissionmodel>();
                SqlCommand cmd = new SqlCommand("SP_UserDetails", connect);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    UserList.Add(

                        new UserAdmissionmodel
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Email = Convert.ToString(dr["Email"]),
                            HighSchoolName = Convert.ToString(dr["HighSchoolName"]),
                            HighSchoolGroup = Convert.ToString(dr["HighSchoolGroup"]),
                            HighSchoolMark = Convert.ToInt32(dr["HighSchoolMark"]),
                            SecondarySchoolName = Convert.ToString(dr["SecondarySchoolName"]),
                            SecondarySchoolMark = Convert.ToInt32(dr["SecondarySchoolMark"]),
                            CommunityCertificate = (byte[])(dr["CommunityCertificate"]),
                            Photo = (byte[])(dr["Photo"]),
                            Status = Convert.ToInt32(dr["Status"])
                        });
                }
                return UserList;
            }
            finally
            {
                connect.Close();
            }

        }
                        /// <summary>
                        /// if user can edit our basic details so get the id where session to fetch the details from user 
                        /// </summary>
                        /// <param name="ID"></param>
                        /// <returns></returns>
        public List<UserAdmissionmodel> EditUserProfile(int ID)
        {
            try
            {
                connection();
                connect.Open();

                List<UserAdmissionmodel> profile = new List<UserAdmissionmodel>();
                SqlCommand cmd = new SqlCommand("SP_UserDetails", connect);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    profile.Add(

                        new UserAdmissionmodel
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            Email = Convert.ToString(dr["Email"]),
                            HighSchoolName = Convert.ToString(dr["HighSchoolName"]),
                            HighSchoolGroup = Convert.ToString(dr["HighSchoolGroup"]),
                            HighSchoolMark = Convert.ToInt32(dr["HighSchoolMark"]),
                            SecondarySchoolName = Convert.ToString(dr["SecondarySchoolName"]),
                            SecondarySchoolMark = Convert.ToInt32(dr["SecondarySchoolMark"])
                        }); ;
                }
                return profile;
            }
            finally
            {
                connect.Close();
            }

        }
                        /// <summary>
                        /// update our details
                        /// </summary>
                        /// <param name="admission"></param>
                        /// <returns></returns>
        public bool Update(UserAdmissionmodel admission)
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("SP_UpdateProfile", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", admission.ID);
                cmd.Parameters.AddWithValue("@FirstName", admission.FirstName);
                cmd.Parameters.AddWithValue("@LastName", admission.LastName);
                cmd.Parameters.AddWithValue("@Gender", admission.Gender);
                cmd.Parameters.AddWithValue("@Email", admission.Email);
                cmd.Parameters.AddWithValue("@HighSchoolName", admission.HighSchoolName);
                cmd.Parameters.AddWithValue("@HighSchoolGroup", admission.HighSchoolGroup);
                cmd.Parameters.AddWithValue("@HighSchoolMark", admission.HighSchoolMark);
                cmd.Parameters.AddWithValue("@SecondarySchoolName", admission.SecondarySchoolName);
                cmd.Parameters.AddWithValue("@SecondarySchoolMark", admission.SecondarySchoolMark);


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
                        /// user can also view the our status for application confirm or rejected or waiting 
                        /// </summary>
                        /// <param name="ID"></param>
                        /// <returns></returns>
        public List<UserAdmissionmodel> Status(int ID)
        {
            try
            {
                connection();
                connect.Open();
                List<UserAdmissionmodel> user = new List<UserAdmissionmodel>();
                SqlCommand cmd = new SqlCommand("SP_UserDetails", connect);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    user.Add(
                        new UserAdmissionmodel
                        {

                            ID = Convert.ToInt32(dr["ID"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            Email = Convert.ToString(dr["Email"]),
                            Courseid = Convert.ToString(dr["Courseid"]),
                            Coursename = Convert.ToString(dr["Coursename"]),
                            Status = Convert.ToInt32(dr["Status"])
                        });

                }

                return user;
            }
            finally
            {
                connect.Close();
            }

        }



    }
}