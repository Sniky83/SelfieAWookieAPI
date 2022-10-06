using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfieAWookieAPI.Application.DTOs;

namespace SelfieAWookieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        //private readonly SelfiesContext _context;

        //Injection de dépendance
        private readonly ISelfieRepository _repository = null;
        #endregion

        #region Constructors
        public SelfiesController(ISelfieRepository repository)
        {
            _repository = repository;
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

            //var model = _context.Selfies.Include(item => item.Wookie).Select(item => new { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromWookie = item.Wookie.Selfies.Count } ).ToList();

            //var query = from Selfie in _context.Selfies
            //            join wookie in _context.Wookies
            //            on Selfie.WookieId equals wookie.Id
            //            select Selfie;

            var selfieList = _repository.GetAll();

            var model = selfieList.Select(item => new SelfieResumeDto { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IActionResult AddOne(SelfieDto dto)
        {
            IActionResult result = BadRequest();

            Selfie addSelfie = _repository.AddOne(new Selfie()
            {
                ImagePath = dto.ImagePath,
                Title = dto.Title
            });
            _repository.UnitOfWork.SaveChanges();

            if(addSelfie != null)
            {
                dto.Id = addSelfie.Id;
                result = Ok(dto);
            }

            return Ok(result);
        }
        #endregion
    }
}
