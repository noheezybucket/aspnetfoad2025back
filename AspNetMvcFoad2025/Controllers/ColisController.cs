//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using AspNetMvcFoad2025.Models;
//using PagedList;
//using PagedList.Mvc;

//namespace AspNetMvcFoad2025.Controllers
//{
//    public class ColisController : Controller
//    {
//        private BdTrackingContext db = new BdTrackingContext();

//        // GET: Colis
//        public ActionResult Index(string Libelle, int? page)
//        {
//            ViewBag.Libelle = string.IsNullOrEmpty(Libelle) ? "" : Libelle;
//            var liste = db.colis.ToList();
//            if (!string.IsNullOrEmpty(Libelle))
//            {
//                liste = liste.Where(a => a.libelleColis.ToLower().Contains(Libelle.ToLower())).ToList();
//            }
//            page = page.HasValue ? page : 1;
//            int pageSize = 2;
//            int pageNumber = (page ?? 1);
//            return View(liste.ToPagedList(pageNumber, pageSize));
//        }

//        // GET: Colis/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Colis colis = db.colis.Find(id);
//            if (colis == null)
//            {
//                return HttpNotFound();
//            }
//            return View(colis);
//        }

//        // GET: Colis/Create
//        public ActionResult Create()
//        {
//            return View();
//        }


//        public ActionResult CreateColis()
//        {
//            return View();
//        }


//        // POST: Colis/Create
//        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
//        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult CreateColis([Bind(Include = "IdColis,CodeColis,LibelleColis,DescriptionColis,PoidsColis,TypeColis")] Colis colis)
//        {
//            if (ModelState.IsValid)
//            {
//                db.colis.Add(colis);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(colis);
//        }

//        // GET: Colis/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Colis colis = db.colis.Find(id);
//            if (colis == null)
//            {
//                return HttpNotFound();
//            }
//            return View(colis);
//        }

//        // POST: Colis/Edit/5
//        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
//        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "IdColis,CodeColis,LibelleColis,DescriptionColis,PoidsColis,TypeColis")] Colis colis)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(colis).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(colis);
//        }

//        // GET: Colis/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Colis colis = db.colis.Find(id);
//            if (colis == null)
//            {
//                return HttpNotFound();
//            }
//            return View(colis);
//        }

//        // POST: Colis/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            Colis colis = db.colis.Find(id);
//            db.colis.Remove(colis);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetMvcFoad2025.Models;
using Microsoft.SqlServer.Server;
using PagedList;

namespace AspNetMvcFoad2025.Controllers
{
    [Authorize(Roles = " Livreur, Client")]
    public class ColisController : Controller
    {
        private BdTrackingContext db = new BdTrackingContext();

        // GET: Colis
        [Authorize(Roles = " Livreur")]
        public ActionResult Index(string Libelle, int? page)

        {
            ViewBag.Libelle = string.IsNullOrEmpty(Libelle) ? "" : Libelle;
            var liste = db.colis.ToList();
            if (!string.IsNullOrEmpty(Libelle))
            {
                liste = liste.Where(a => a.libelleColis.ToLower().Contains(Libelle.ToLower())).ToList();
            }
            page = page.HasValue ? page : 1;
            int pageSize = 2; int pageNumber = (page ?? 1);
            return View(liste.ToPagedList(pageNumber, pageSize));
        }
        // Pour la recherche avec deux critere 

        //public ActionResult Index(string Libelle, string Code, int? page)
        //{
        //    ViewBag.Libelle = Libelle ?? "";
        //    ViewBag.Code = Code ?? "";

        //    var liste = db.colis.AsQueryable();

        //    if (!string.IsNullOrEmpty(Libelle))
        //    {
        //        liste = liste.Where(c => c.libelleColis.ToLower().Contains(Libelle.ToLower()));
        //    }

        //    if (!string.IsNullOrEmpty(Code))
        //    {
        //        liste = liste.Where(c => c.CodeColis.ToLower().Contains(Code.ToLower()));
        //    }

        //    int pageSize = 2;
        //    int pageNumber = page ?? 1;

        //    return View(liste.OrderBy(c => c.libelleColis).ToPagedList(pageNumber, pageSize));
        //}


        // GET: Colis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colis colis = db.colis.Find(id);
            if (colis == null)
            {
                return HttpNotFound();
            }
            return View(colis);
        }

        // GET: Colis/Create
        public ActionResult Create()
        {
            return View();
        }

        // creer colis 
        public ActionResult CreateColis()
        {
            return View();
        }
        //
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateColis([Bind(Include = "IdColis,CodeColis,libelleColis,DescriptionColis,PoidsColis,TypeColis")] Colis colis)
        {
            if (ModelState.IsValid)
            {
                db.colis.Add(colis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colis);
        }

        // POST: Colis/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdColis,CodeColis,libelleColis,DescriptionColis,PoidsColis,TypeColis")] Colis colis)
        {
            if (ModelState.IsValid)
            {
                db.colis.Add(colis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(colis);
        }

        // GET: Colis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colis colis = db.colis.Find(id);
            if (colis == null)
            {
                return HttpNotFound();
            }
            return View(colis);
        }

        // POST: Colis/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdColis,CodeColis,libelleColis,DescriptionColis,PoidsColis,TypeColis")] Colis colis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(colis);
        }

        // GET: Colis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colis colis = db.colis.Find(id);
            if (colis == null)
            {
                return HttpNotFound();
            }
            return View(colis);
        }

        // POST: Colis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colis colis = db.colis.Find(id);
            db.colis.Remove(colis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



        // Repport

        public DataTable GetTableColis()
        {
            DataTable table = new DataTable();
            table.Columns.Add("CodeColis", typeof(string));
            table.Columns.Add("libelleColis", typeof(string));
            table.Columns.Add("DescriptionColis", typeof(string));
            table.Columns.Add("PoidsColis", typeof(string));
            table.Columns.Add("TypeColis", typeof(string)); // DateTime converti en string

            var liste = db.colis.ToList();
            foreach (var e in liste)
            {
                table.Rows.Add(
                    e.CodeColis,
                    e.libelleColis,
                    e.DescriptionColis,
                    e.PoidsColis,
                    e.TypeColis.ToString() // Formatté proprement
                );
            }
            return table;
        }


        public ActionResult Imprimer()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            try
            {
                rpt.Load(Server.MapPath("~/Repport/rptListeColis.rpt"));
                rpt.SetDataSource(GetTableColis());
                Stream stream = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                Response.AppendHeader("Content-Disposition", "inline");
                return File(stream, "application/pdf");
            }
            finally
            {
                rpt.Dispose();
                rpt.Close();
            }
        }


    }




}
