using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookie.Core.Selfies.Infrastructures.Data;
using SelfieAWookieAPI.Application.DTOs;
using SelfieAWookieAPI.Application.Queries;
using SelfieAWookieAPI.ExtensionMethods;

namespace SelfieAWookieAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //Si token alors on accepte (lié au JWT)
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //On spécifie une POLICY rien qui pour ce controller
    //Va override la config du Program.cs pour prendre celle la car c'est spécific a ce controller
    [EnableCors(SecurityMethods.DEFAULT_POLICY_2)]
    public class SelfiesController : ControllerBase
    {
        #region Fields
        //private readonly SelfiesContext _context;

        //Injection de dépendance
        private readonly ISelfieRepository _repository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        private readonly IMediator _mediator = null;
        #endregion

        #region Constructors
        public SelfiesController(IMediator mediator, ISelfieRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
            _mediator = mediator;
        }
        #endregion

        #region Public Methods
        //[HttpGet]
        //public IEnumerable<Selfie> Get()
        //{
        //    return Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });
        //}

        [HttpGet]
        //Fait sauter la règle du controller ou du Program.cs pour cette requête specifique
        [DisableCors()]
        //Override le CORS du controller car spécific a cette méthode
        //[EnableCors(SecurityMethods.DEFAULT_POLICY_3)]
        public IActionResult GetAll([FromQuery] int wookieId = 0)
        {
            //var model = Enumerable.Range(1, 10).Select(item => new Selfie() { Id = item });

            //No content quand on trouve pas de resultat ex: dans une recherche
            //StatusCode(StatusCodes.Status204NoContent);

            //var model = _context.Selfies.Include(item => item.Wookie).Select(item => new { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromWookie = item.Wookie.Selfies.Count } ).ToList();

            //var query = from Selfie in _context.Selfies
            //            join wookie in _context.Wookies
            //            on Selfie.WookieId equals wookie.Id
            //            select Selfie;

            //var param = Request.Query["wookieId"];

            //var selfieList = _repository.GetAll(wookieId);
            //var model = selfieList.Select(item => new SelfieResumeDto { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();

            var model = _mediator.Send(new SelectAllSelfiesQuery() { WookieId = wookieId });

            return Ok(model);
        }

        //[Route("photos")]
        //[HttpPost]
        //public async Task<IActionResult> AddPicture()
        //{
        //    using var stream = new StreamReader(Request.Body);

        //    var content = await stream.ReadToEndAsync();

        //    return Ok();
        //}

        [Route("photos")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, @"images\selfies");

            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, picture.FileName);

            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            await picture.CopyToAsync(stream);

            var itemFile = _repository.AddOnePicture(filePath);
            _repository.UnitOfWork.SaveChanges();

            return Ok(itemFile);
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
