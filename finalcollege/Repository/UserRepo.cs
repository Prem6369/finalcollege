using finalcollege.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;

namespace finalcollege.Repository
{
    public class UserRepo
    {
        private SqlConnection connect;
        public void connection()
        {
            string connection = ConfigurationManager.ConnectionStrings["StudentCon"].ToString();
            connect = new SqlConnection(connection);

        }
        /// <summary>
        /// if user first register our self that data will added this content
        /// </summary>
        /// <param name="clg"></param>
        /// <returns></returns>
        public bool Createdata(Registermodel clg)
        {
            try
            {
                connection();
                SqlCommand cmd1 = new SqlCommand("SP_CheckEmail", connect);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Email", clg.Email);
                connect.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read() == true)
                {
                    return false;
                }
                else
                {
                    connect.Close();
                    SqlCommand cmd = new SqlCommand("SPI_Register", connect);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Role", 1);
                    cmd.Parameters.AddWithValue("@FirstName", clg.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", clg.LastName);
                    cmd.Parameters.AddWithValue("@DateOfBirth", clg.DateOfBirth);
                    cmd.Parameters.AddWithValue("@Age", clg.Age);
                    cmd.Parameters.AddWithValue("@Gender", clg.Gender);
                    cmd.Parameters.AddWithValue("@PhoneNumber", clg.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Address", clg.Address);
                    cmd.Parameters.AddWithValue("@State", clg.State);
                    cmd.Parameters.AddWithValue("@City", clg.City);
                    cmd.Parameters.AddWithValue("@Email", clg.Email);
                    cmd.Parameters.AddWithValue("@Password", Encrypt( clg.Password));

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
        /// out the id,role used for session
        /// </summary>
        /// <param name="id"></param>
        /// <param name="result"></param>
        /// <param name="registermodel"></param>
        /// <returns></returns>
        public bool VerifySignIn(Registermodel registermodel, out int id,out int result,out string name) 
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("SP_LoginAdminUser", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", registermodel.Email);
                cmd.Parameters.AddWithValue("@Password", Encrypt(registermodel.Password));
                connect.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = (int)reader["Role"];
                    id = (int)reader["Id"];
                    name = (string)reader["FirstName"];
                    HttpContext.Current.Session["Id"] = id;
                    HttpContext.Current.Session["FirstName"] = name;

                    FormsAuthentication.SetAuthCookie(registermodel.Email,true);

                    return true;
                }
                else
                {
                    result = 0;
                    id = 0;
                    name = "!!!!";
                    return false;
                }
            }
            finally
            {
                connect.Close();
            }

        }

        public bool Contact(Contact contact)
        {
            try
            {
                connection();
                SqlCommand cmd = new SqlCommand("SP_Contact", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fullname", contact.Fullname);
                cmd.Parameters.AddWithValue("@Email", contact.Email);
                cmd.Parameters.AddWithValue("@Phonenumber", contact.Phonenumber);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
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

        public bool Forgetpassword(Registermodel registermodel)
        {
            try
            {
                connection();
                SqlCommand command = new SqlCommand("SP_Forgetpassword", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Email", registermodel.Email);
                command.Parameters.AddWithValue("@Phonenumber", registermodel.PhoneNumber);
                command.Parameters.AddWithValue("@Password", Encrypt(registermodel.Password));
                connect.Open();
                int i = command.ExecuteNonQuery();
         

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



    }
}