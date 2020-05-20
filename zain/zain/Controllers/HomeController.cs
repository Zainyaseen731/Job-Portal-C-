using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zain.Models;

namespace zain.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext dc = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Addjob()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult available()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        public ActionResult Jobs(string submit)
        {
            string textboxValue = Request.Form["submit"];
            ViewBag.name = textboxValue;
            if (textboxValue == "Demandware")
            {
                var one = dc.jobs.Where(c => c.jobtype == "demandware");
                if (one.ToString() != null)
                {
                    ViewBag.data = one;
                }
            }
            else if (textboxValue == "Java")
            {
                var one = dc.jobs.Where(c => c.jobtype == "java");
                if (one.ToString() != null)
                {
                    ViewBag.data = one;
                }
            }
            else if (textboxValue == "Django")
            {
                var one = dc.jobs.Where(c => c.jobtype == "django");
                if (one.ToString() != null)
                {
                    ViewBag.data = one;
                }
            }
            else if (textboxValue == "React")
            {
          

                var one = dc.jobs.Where(c => c.jobtype == "react");
                if (one.ToString() != null)
                {
                    ViewBag.data = one;
                }
            }

            else if (textboxValue == "Others")
            {


                var one = dc.jobs.Where(c => c.jobtype != "react" && c.jobtype != "demandware" && c.jobtype != "java" && c.jobtype != "django");
                if (one.ToString() != null)
                {
                    ViewBag.data = one;
                }
            }
            return View();
        }

        public ActionResult add()
        {
            string type = Request["type"];
            string title = Request["title"];
            string company = Request["company"];
            string location = Request["location"];
            job p = new job();
            p.jobtype = type;
            p.jobtitle = title;
            p.company = company;
            p.location = location;
            dc.jobs.InsertOnSubmit(p);
            dc.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var c = dc.jobs.First(a => a.Id == id);
            return View(c);
        }

        public ActionResult Done(int id)
        {
            string type = Request["type"];
            string title = Request["title"];
            string company = Request["company"];
            string location = Request["location"];
            var c = dc.jobs.First(a => a.Id == id);
            c.jobtype = type;
            c.jobtitle = title;
            c.company = company;
            c.location = location;
            dc.SubmitChanges();
            return RedirectToAction("Index");

        }
    }
}