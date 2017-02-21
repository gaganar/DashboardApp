﻿using System.Linq;
using System.Web.Mvc;
using DashboardApp.Models;
using System;

namespace DashboardApp.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
        try
        {
            var db = new DashboardAppEntities();
            var dashboardReport = new DashboardReport
            {
                NewComments = db.Comments.Count(),
                NewTasks = db.Tasks.Count(),
                NewOrders = db.Orders.Count(),
                SupportTickets = db.SupportTickets.Count()
            };

            ViewBag.Title = "Home";
            return View(dashboardReport);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Trace.TraceError("If you're seeing this, something bad happened {1}", ex);
            throw ex;
        }
    }
  }
}
