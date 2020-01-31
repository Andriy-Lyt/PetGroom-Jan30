using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }

        //TODO: Each line should be a separate method in this class
        // List
        public ActionResult List()
        {
            //what data do we need?
            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();

            return View(myspecies);
        }
        
        public ActionResult Delete(int id)
        {
            string query = "delete from species where SpeciesID = @SpeciesID";
            SqlParameter[] sqlparams = new SqlParameter[1];
            sqlparams[0] = new SqlParameter("@SpeciesID", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            
            return RedirectToAction("List");
        }


        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string SpeciesName)
        {
            string query = "insert into species ([Name]) values (@SpeciesName)";
            SqlParameter[] sqlparams = new SqlParameter[1]; 
            sqlparams[0] = new SqlParameter("@SpeciesName", SpeciesName);            
            db.Database.ExecuteSqlCommand(query, sqlparams);   
            
            return RedirectToAction("List");
        }

        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Pet pet = db.Pets.Find(id); //EF 6 technique
            Species species = db.Species.SqlQuery(
                "select * from species where speciesid=@SpeciesId", 
                    new SqlParameter("@SpeciesId", id)).
                 FirstOrDefault();

            if (species == null)
            {
                return HttpNotFound();
            }

            return View(species);
        }


        public ActionResult Update(int id)
        {
            //need information about a particular pet
            Species species = db.Species.SqlQuery("select * from species where speciesid = @id", new SqlParameter("@id", id)).FirstOrDefault();
            return View(species);
        }


        [HttpPost]
        public ActionResult Update(int Id, string Name)
        {
            string query = "update species set [Name]=@Name WHERE SpeciesID=@Id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@Name", Name);
            sqlparams[1] = new SqlParameter("@Id", Id);

            db.Database.ExecuteSqlCommand(query, sqlparams);


            return RedirectToAction("List");
        }


        // Show
        // Add
        // [HttpPost] Add
        // Update
        // [HttpPost] Update
        // (optional) delete
        // [HttpPost] Delete
    }
}