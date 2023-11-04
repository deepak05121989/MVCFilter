using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Configuration.Internal;
using MVCFilter.Models;
using MVCFilter.Auth;

namespace MVCFilter.Controllers
{
    
    public class AccountController : Controller
    {
        [AuthAttribute]
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult UserLogin()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult UserLogin(UserDetails userDetails)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoDBConnection"].ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "usp_VlidateUser";
                        cmd.Parameters.AddWithValue("@userName",userDetails.UserName);
                        cmd.Parameters.AddWithValue("@pass",userDetails.Password);
                        SqlDataReader dr= cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            Session["user"] = userDetails.UserName;
                            return RedirectToAction("Index");
                        }

                    }
                }
                // TODO: Add insert logic here


                
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
