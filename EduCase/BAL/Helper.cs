using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace EduCase.BAL
{
    public class Helper
    {
        protected NpgsqlConnection conn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["pgconn"].ToString());
    }
}