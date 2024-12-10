using EduCase.BAL;
using EduCase.Models;
using Npgsql;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace EduCase.Controllers
{
    public class StudentController : Controller
    {
    
        StudentHelper sh = new StudentHelper();
        StandardHelper ch = new StandardHelper();

        NpgsqlConnection conn = new NpgsqlConnection("Server=localhost; Port=5432; Database=EduCase; User Id=postgres; Password=Vraj2010; ");

        // GET: Student
        public ActionResult Index(int? page)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            ViewBag.Message = TempData["message"] as string;

            int pageSize = 3;
            int pageNumber = page ?? 1;

            List<tblStudent> displaystudent = new List<tblStudent>();
            conn.Open();
            NpgsqlCommand comm = new NpgsqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select s_id, s_name, s_dob, s_gender, s_mob, s_email, s_cricket, s_volleyball, s_gaming, s_address, s_standardid from t_student";

            NpgsqlDataReader dr = comm.ExecuteReader();
            {
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
                    displaystudent.Add(stu);
                }
            }

            conn.Close();

            // Assuming displaystudent is your IEnumerable<tblStudent>
            IPagedList<tblStudent> pagedStudentList = displaystudent.ToPagedList(pageNumber, pageSize);
            return View(pagedStudentList);


        }


        public ActionResult Details(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            tblStudent stu = null;
            stu = sh.GetOneStudent(id);
            return View(stu);
        }

        public ActionResult Create()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.Standard = ch.GetAllStandard();
            return View();
        }

        [HttpPost]
        public ActionResult Create(tblStudent stu)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            sh.AddStudent(stu);
            return RedirectToAction("Index", "Student");
        }
        public ActionResult Edit(int id)
        {
            tblStudent stu = null;
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            ViewBag.Standard = ch.GetAllStandard();
            stu = sh.GetOneStudent(id);
            return View(stu);
        }

        [HttpPost]
        public ActionResult Edit(tblStudent stu)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            sh.EditStudent(stu);
            return RedirectToAction("Index", "Student");
        }

        public ActionResult Delete(int id)
        {
            tblStudent stu = null;
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            stu = sh.GetOneStudent(id);
            return View(stu);
        }

        [HttpPost]
        public ActionResult Delete(tblStudent stu)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            sh.DeleteStudent(stu);
            return RedirectToAction("Index", "Student");
        }
        [HttpPost]
        public ActionResult DeleteMultiple(int[] selectedIds, string submitType)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (submitType == "deleteSelected")
            {
                if (selectedIds != null && selectedIds.Length > 0)
                {
                    try
                    {
                        conn.Open();
                        NpgsqlCommand comm = new NpgsqlCommand();
                        comm.Connection = conn;
                        comm.CommandType = CommandType.Text;

                        // Use parameterized query to prevent SQL injection
                        string query = "DELETE FROM t_student WHERE s_id = ANY(@ids)";
                        comm.CommandText = query;

                        // Use NpgsqlParameter to add the parameter for the selectedIds array
                        comm.Parameters.AddWithValue("@ids", selectedIds);

                        int n = comm.ExecuteNonQuery();

                        TempData["message"] = "Selected Rows/Data Deleted Successfully";
                    }
                    catch (Exception ex)
                    {
                        // Handle any exception that may occur during the deletion process
                        TempData["error"] = "An error occurred while deleting data: " + ex.Message;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                else
                {
                    TempData["message"] = "Please select rows/data to delete.";
                }
            }
            else if (submitType == "deleteAll")
            {
                try
                {
                    conn.Open();
                    NpgsqlCommand comm = new NpgsqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "DELETE FROM t_student";
                    int n = comm.ExecuteNonQuery();

                    TempData["message"] = "All Rows/Data Deleted Successfully";
                }
                catch (Exception ex)
                {
                    TempData["error"] = "An error occurred while deleting data: " + ex.Message;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                TempData["error"] = "Invalid operation.";
            }

            return RedirectToAction("Index");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "User");
        }
    }
 
}
