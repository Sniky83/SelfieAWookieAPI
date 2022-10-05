using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;

namespace SelfieAWookieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        private readonly SelfiesContext _context;
        #endregion

        #region Constructors
        public SelfiesController(SelfiesContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        //public IEnumerable<Selfie> Get()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}

        public IActionResult Get()
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

            //No content quand on trouve pas de resultat ex: dans une recherche
            //StatusCode(StatusCodes.Status204NoContent);

            var model = _context.Selfies.Include(item => item.Wookie).Select(item => new { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromWookie = item.Wookie.Selfies.Count } ).ToList();

            //var query = from Selfie in _context.Selfies
            //            join wookie in _context.Wookies
            //            on Selfie.WookieId equals wookie.Id
            //            select Selfie;


            return Ok(model);
        }
        #endregion
    }
}
