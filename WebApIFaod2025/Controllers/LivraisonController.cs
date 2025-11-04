//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApIFaod2025.Helpers;
//using WebApIFaod2025.Models.Livraison;
//using WebApIFaod2025.Services;

//namespace WebApIFaod2025.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LivraisonController : ControllerBase
//    {

//        private readonly ILivraisonService _service;

//        public LivraisonController(ILivraisonService service)
//        {
//            _service = service;
//        }


//        [HttpPost]
//        public IActionResult Create([FromBody] CreateLivraisonRequest model)
//        {
//            var livraison = _service.CreateLivraison(model);
//            return Ok(new
//            {
//                message = "Livraison créée",
//                idLivraison = livraison.IdLivraison,
//                codeColis = livraison.Colis?.CodeColis
//            });
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            return Ok(_service.GetAll());
//        }



//        [HttpPatch("{id}/terminer")]
//        public IActionResult Terminer(int id)
//        {
//            try
//            {
//                var livraison = _service.TerminerLivraison(id);
//                return Ok(new
//                {
//                    message = "Livraison terminée avec succès",
//                    idLivraison = livraison.IdLivraison,
//                    codeColis = livraison.Colis?.CodeColis,
//                    statutLivraison = livraison.Statut,
//                    dateFin = livraison.DateFin,
//                    statutColis = livraison.Colis?.StatutLivraison
//                });
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(new { error = ex.Message });
//            }
//            catch (AppException ex)
//            {
//                return BadRequest(new { error = ex.Message });
//            }
//        }
//        [HttpPatch("{id}/annuler")]
//        public IActionResult Annuler(int id)
//        {
//            try
//            {
//                var livraison = _service.AnnulerLivraison(id);
//                return Ok(new
//                {
//                    message = "Livraison annulée avec succès",
//                    idLivraison = livraison.IdLivraison,
//                    codeColis = livraison.Colis?.CodeColis,
//                    statutLivraison = livraison.Statut,
//                    statutColis = livraison.Colis?.StatutLivraison
//                });
//            }
//            catch (KeyNotFoundException ex)
//            {
//                return NotFound(new { error = ex.Message });
//            }
//            catch (AppException ex)
//            {
//                return BadRequest(new { error = ex.Message });
//            }
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // AJOUTE ÇA
using WebApIFaod2025.Helpers;
using WebApIFaod2025.Models.Livraison;
using WebApIFaod2025.Services;

namespace WebApIFaod2025.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivraisonController : ControllerBase
    {
        private readonly ILivraisonService _service;
        private readonly bdTracking01Context _context; // INJECTÉ

        public LivraisonController(ILivraisonService service, bdTracking01Context context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateLivraisonRequest model)
        {
            var livraison = _service.CreateLivraison(model);
            return Ok(new
            {
                message = "Livraison créée",
                idLivraison = livraison.IdLivraison,
                codeColis = livraison.Colis?.CodeColis
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var livraison = _context.Livraisons
                .Include(l => l.Colis)
                .Include(l => l.Client)
                .Include(l => l.Livreur)
                .Where(l => l.IdLivraison == id)
                .Select(l => new
                {
                    // LIVRAISON
                    idLivraison = l.IdLivraison,
                    statutLivraison = l.Statut,
                    dateDebut = l.DateDebut,
                    dateFin = l.DateFin,

                    // COLIS
                    colis = new
                    {
                        idColis = l.Colis.IdColis,
                        codeColis = l.Colis.CodeColis,
                        description = l.Colis.Description,
                        poids = l.Colis.Poids,
                        adresseDepart = l.Colis.AdresseDepart,
                        adresseArrivee = l.Colis.AdresseArrivee,
                        statutColis = l.Colis.StatutLivraison,
                        dateCreation = l.Colis.DateCreation
                    },

                    // CLIENT
                    client = new
                    {
                        id = l.Client.IdUsersColis,
                        nom = l.Client.Nom,
                        prenom = l.Client.Prenom,
                        telephone = l.Client.Telephone,
                        email = l.Client.Email,
                        adresse = l.Client.Adresse,
                        cni = l.Client.CNI
                    },

                    // LIVREUR
                    livreur = new
                    {
                        id = l.Livreur.IdUsersColis,
                        nom = l.Livreur.Nom,
                        prenom = l.Livreur.Prenom,
                        telephone = l.Livreur.Telephone,
                        email = l.Livreur.Email,
                        adresse = l.Livreur.Adresse,
                        cni = l.Livreur.CNI
                    }
                })
                .FirstOrDefault();

            if (livraison == null)
                return NotFound(new { error = "Livraison non trouvée" });

            return Ok(livraison);
        }
        [HttpPatch("{id}/terminer")]
        public IActionResult Terminer(int id)
        {
            try
            {
                var livraison = _service.TerminerLivraison(id);
                return Ok(new
                {
                    message = "Livraison terminée avec succès",
                    idLivraison = livraison.IdLivraison,
                    codeColis = livraison.Colis?.CodeColis,
                    statutLivraison = livraison.Statut,
                    dateFin = livraison.DateFin,
                    statutColis = livraison.Colis?.StatutLivraison
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPatch("{id}/annuler")]
        public IActionResult Annuler(int id)
        {
            try
            {
                var livraison = _service.AnnulerLivraison(id);
                return Ok(new
                {
                    message = "Livraison annulée avec succès",
                    idLivraison = livraison.IdLivraison,
                    codeColis = livraison.Colis?.CodeColis,
                    statutLivraison = livraison.Statut,
                    statutColis = livraison.Colis?.StatutLivraison
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPatch("{id}/reprendre")]
        public IActionResult Reprendre(int id)
        {
            try
            {
                var livraison = _service.ReprendreLivraison(id);
                return Ok(new
                {
                    message = "Livraison reprise avec succès",
                    idLivraison = livraison.IdLivraison,
                    codeColis = livraison.Colis?.CodeColis,
                    statutLivraison = livraison.Statut,
                    statutColis = livraison.Colis?.StatutLivraison
                });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (AppException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}