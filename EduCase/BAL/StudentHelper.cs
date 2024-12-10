using EduCase.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCase.BAL
{
    public class StudentHelper : Helper
    {
        public List<tblStudent> GetAllStudent()
        {
            List<tblStudent> stuList = new List<tblStudent>();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_student student, t_standard standard WHERE student.s_standardid = standard.s_standardid;", conn);

            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var stu = new tblStudent();
                stu.s_id = Convert.ToInt32(dr["s_id"]);
                stu.s_name = dr["s_name"].ToString();
                stu.s_dob = Convert.ToDateTime(dr["s_dob"]);
                stu.s_gender = dr["s_gender"].ToString();
                stu.s_mob = dr["s_mob"].ToString();
                stu.s_email = dr["s_email"].ToString();
                stu.s_cricket = Convert.ToBoolean(dr["s_cricket"]);
                stu.s_volleyball = Convert.ToBoolean(dr["s_volleyball"]);
                stu.s_gaming = Convert.ToBoolean(dr["s_gaming"]);
                stu.s_address = dr["s_address"].ToString();
                stu.s_standardid = Convert.ToInt32(dr["s_standardid"]);
                stuList.Add(stu);
            }
            dr.Close();
            conn.Close();
            return stuList;
        }

        public tblStudent GetOneStudent(int id)
        {
            var stu = new tblStudent();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_student student, t_standard standard WHERE student.s_id = @s_id AND student.s_standardid = standard.s_standardid;", conn);
            cmd.Parameters.AddWithValue("@s_id", id);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                stu.s_id = Convert.ToInt32(dr["s_id"]);
                stu.s_name = dr["s_name"].ToString();
                stu.s_dob = Convert.ToDateTime(dr["s_dob"]);
                stu.s_gender = dr["s_gender"].ToString();
                stu.s_mob = dr["s_mob"].ToString();
                stu.s_email = dr["s_email"].ToString();
                stu.s_cricket = Convert.ToBoolean(dr["s_cricket"]);
                stu.s_volleyball = Convert.ToBoolean(dr["s_volleyball"]);
                stu.s_gaming = Convert.ToBoolean(dr["s_gaming"]);
                stu.s_address = dr["s_address"].ToString();
                stu.s_standardid = Convert.ToInt32(dr["s_standardid"]);
            }
            dr.Read();
            conn.Close();
            return stu;
        }

        public void AddStudent(tblStudent stu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO t_student(s_name, s_dob, s_gender, s_mob, s_email, s_cricket, s_volleyball, s_gaming, s_address, s_standardid) VALUES(@s_name, @s_dob, @s_gender, @s_mob, @s_email, @s_cricket, @s_volleyball, @s_gaming, @s_address, @s_standardid);", conn);

            cmd.Parameters.AddWithValue("@s_name", stu.s_name);
            cmd.Parameters.AddWithValue("@s_dob", stu.s_dob);
            cmd.Parameters.AddWithValue("@s_gender", stu.s_gender);
            cmd.Parameters.AddWithValue("@s_mob", stu.s_mob);
            cmd.Parameters.AddWithValue("@s_email", stu.s_email);
            cmd.Parameters.AddWithValue("@s_cricket", stu.s_cricket);
            cmd.Parameters.AddWithValue("@s_volleyball", stu.s_volleyball);
            cmd.Parameters.AddWithValue("@s_gaming", stu.s_gaming);
            cmd.Parameters.AddWithValue("@s_address", stu.s_address);
            cmd.Parameters.AddWithValue("@s_standardid", stu.s_standardid);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditStudent(tblStudent stu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("UPDATE t_student SET s_name = @s_name, s_dob = @s_dob, s_gender = @s_gender, s_mob = @s_mob, s_email = @s_email, s_cricket = @s_cricket, s_volleyball = @s_volleyball, s_gaming = @s_gaming, s_address = @s_address, s_standardid = @s_standardid  WHERE s_id = @s_id;", conn);

            cmd.Parameters.AddWithValue("@s_id", stu.s_id);
            cmd.Parameters.AddWithValue("@s_name", stu.s_name);
            cmd.Parameters.AddWithValue("@s_dob", stu.s_dob);
            cmd.Parameters.AddWithValue("@s_gender", stu.s_gender);
            cmd.Parameters.AddWithValue("@s_mob", stu.s_mob);
            cmd.Parameters.AddWithValue("@s_email", stu.s_email);
            cmd.Parameters.AddWithValue("@s_cricket", stu.s_cricket);
            cmd.Parameters.AddWithValue("@s_volleyball", stu.s_volleyball);
            cmd.Parameters.AddWithValue("@s_gaming", stu.s_gaming);
            cmd.Parameters.AddWithValue("@s_address", stu.s_address);
            cmd.Parameters.AddWithValue("@s_standardid", stu.s_standardid);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void DeleteStudent(tblStudent stu)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM t_student WHERE s_id = @s_id;", conn);

            cmd.Parameters.AddWithValue("@s_id", stu.s_id);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
