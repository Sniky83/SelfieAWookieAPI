using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.Core.Selfies.Domain;

namespace SelfieAWookieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Public Methods
        [HttpGet]
        //public IEnumerable<Selfie> Get()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}

        public IActionResult Get()
        {
            var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

            //No content quand on trouve pas de resultat ex: dans une recherche
            //StatusCode(StatusCodes.Status204NoContent);

            return Ok(model);
        }
        #endregion
    }
}
