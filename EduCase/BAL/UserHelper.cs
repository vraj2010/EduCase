using EduCase.BAL;
using EduCase.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace EduCase.BAL
{
    public class UserHelper : Helper
    {
        public void Register(tblUser user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO t_user(t_username, t_email, t_password) VALUES(@t_username, @t_email, @t_password);", conn);

            cmd.Parameters.AddWithValue("@t_username", user.t_username);
            cmd.Parameters.AddWithValue("@t_email", user.t_email);
            cmd.Parameters.AddWithValue("@t_password", user.t_password);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool Login(tblLogin user)
        {
            bool isUserAuthenticated = false;
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_user WHERE t_email = @t_email AND t_password = @t_password;", conn);

            cmd.Parameters.AddWithValue("@t_email", user.Email);
            cmd.Parameters.AddWithValue("@t_password", user.Password);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                HttpContext.Current.Session["username"] = dr["t_username"].ToString();
                HttpContext.Current.Session["userid"] = dr["t_userid"].ToString();
                isUserAuthenticated = true;
            }
            else
            {
                isUserAuthenticated = false;
            }
            dr.Close();
            conn.Close();
            return isUserAuthenticated;
        }

        public bool EmailExists(string email)
        {
            bool isExists = false;
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_user WHERE t_email = @t_email;", conn);

            cmd.Parameters.AddWithValue("@t_email", email);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                isExists = true;
            }
            else
            {
                isExists = false;
            }
            dr.Close();
            conn.Close();
            return isExists;
        }

        public bool ValidatePassword(string password)
        {
            var passwordRegex = new Regex(@"^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[@$!%?&])[A-Za-z\d@$!%?&]{3,}$");
            return passwordRegex.IsMatch(password);
        }
    }
}