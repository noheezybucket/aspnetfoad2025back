// Ajoute en haut du fichier
using AspNetMvcFoad2025.Models;
using System.Data.Entity;
using System;
using System.Data.Entity.Infrastructure;
using System.Web.Mvc;
using System.Linq;

public class AnimalsController : Controller
{
    private BdTrackingContext db = new BdTrackingContext();

    // GET: Animals
    public ActionResult Index()
    {
        return View(db.Animals.ToList());
    }

    // GET: Animals/Create
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,Nom,Type,Sexe,Poids,Taille,DateNaissance")] Animal animal)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                TempData["success"] = "Animal ajouté avec succès.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erreur lors de l'ajout : " + ex.Message;
            }
        }
        return View(animal);
    }

    // GET: Animals/Edit/5
    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            TempData["error"] = "Identifiant invalide.";
            return RedirectToAction("Index");
        }

        Animal animal = db.Animals.Find(id);
        if (animal == null)
        {
            TempData["error"] = "Animal non trouvé.";
            return RedirectToAction("Index");
        }

        return View(animal);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,Nom,Type,Sexe,Poids,Taille,DateNaissance")] Animal animal)
    {
        if (ModelState.IsValid)
        {
            try
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                TempData["success"] = "Animal modifié avec succès.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Erreur lors de la modification : " + ex.Message;
            }
        }
        return View(animal);
    }

    // GET: Animals/Delete/5
    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            TempData["error"] = "Identifiant invalide.";
            return RedirectToAction("Index");
        }

        Animal animal = db.Animals.Find(id);
        if (animal == null)
        {
            TempData["error"] = "Animal non trouvé.";
            return RedirectToAction("Index");
        }

        return View(animal);
    }

    // POST: Animals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
            db.SaveChanges();
            TempData["success"] = "Animal supprimé avec succès.";
        }
        catch (Exception ex)
        {
            TempData["error"] = "Erreur lors de la suppression : " + ex.Message;
        }
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
}
