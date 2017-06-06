using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class personLiteController : Controller
    {
        Community_AssistEntities db = new Community_AssistEntities();
        // GET: personLite
        public ActionResult Index()
        {
            var peeps = from p in db.People
                        from a in p.PersonAddresses
                        from c in p.Contacts
                        where c.ContactTypeKey == 1
                        select new
                        {
                            p.PersonLastName,
                            p.PersonFirstName,
                            p.PersonEmail,
                            a.PersonAddressApt,
                            a.PersonAddressStreet,
                            a.PersonAddressCity,
                            a.PersonAddressState,
                            a.PersonAddressZip,
                            c.ContactNumber
                        };
            List<personLite> personList = new List<personLite>();

            foreach(var pers in peeps)
            {
                personLite pl = new Models.personLite();
                pl.LastName = pers.PersonLastName;
                pl.FirstName = pers.PersonFirstName;
                pl.Email = pers.PersonEmail;
                pl.Apartment = pers.PersonAddressApt;
                pl.Street = pers.PersonAddressStreet;
                pl.City = pers.PersonAddressCity;
                pl.State = pers.PersonAddressState;
                pl.ZipCode = pers.PersonAddressZip;
                pl.HomePhone = pers.ContactNumber;
                personList.Add(pl);
            }
            return View(personList);
        }
    }
}