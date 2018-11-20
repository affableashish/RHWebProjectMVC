using RHWebProjectMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RHWebProjectMVC.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People/List
        public ActionResult List()
        {
            PersonViewModel PersonViewModelObject = new PersonViewModel();
            List<Person> allList = new List<Person>();
            using (var abc = new PeopleEntities1())
            {
                allList = (from c in abc.People
                 select c).ToList(); 
            }
            return View(allList);
        }

        [HttpPost]
        public ActionResult List(PersonViewModel PersonViewModelObject)
        {
            if(ModelState.IsValid)
            {
                // insert
                using (var db = new PeopleEntities1())
                {
                    var people = db.Set<Person>();
                    people.Add(new Person { FirstName = PersonViewModelObject.FirstName,
                        LastName = PersonViewModelObject.LastName,
                        DateOfBirth = PersonViewModelObject.DateOfBirth,
                        EmailAddress = PersonViewModelObject.EmailAddress
                    });
                    db.SaveChanges();                            
                }

                List<Person> allList = new List<Person>();
                using (var abc = new PeopleEntities1())
                {
                    allList = (from c in abc.People
                               select c
                               ).ToList();
                }

                return View(allList);
            }
            return View("~/Views/Home/Index.cshtml");
        }
    }
}