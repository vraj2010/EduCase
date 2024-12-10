using EduCase.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EduCase.BAL
{
    public class StandardHelper : Helper
    {
        public List<tblStandard> GetAllStandard()
        {
            List<tblStandard> standardList = new List<tblStandard>();
            NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_standard;", conn);
            conn.Open();
            NpgsqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var standard = new tblStandard();
                standard.s_standardid = Convert.ToInt32(dr["s_standardid"]);
                standard.s_standardname = dr["s_standardname"].ToString();
                standardList.Add(standard);
            }
            dr.Read();
            conn.Close();
            return standardList;
        }
    }
}