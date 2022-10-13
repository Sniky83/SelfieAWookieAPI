using MediatR;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookieAPI.Application.DTOs;

namespace SelfieAWookieAPI.Application.Queries
{
    public class SelectAllSelfiesHandler : IRequestHandler<SelectAllSelfiesQuery, List<SelfieResumeDto>>
    {
        #region Fields
        private readonly ISelfieRepository _repository = null;
        #endregion

        #region Constructors
        public SelectAllSelfiesHandler(ISelfieRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods
        public Task<List<SelfieResumeDto>> Handle(SelectAllSelfiesQuery request, CancellationToken cancellationToken)
        {
            var selfieList = _repository.GetAll(request.WookieId);
            var result = selfieList.Select(item => new SelfieResumeDto { Title = item.Title, WookieId = item.WookieId, NbSelfiesFromWookie = (item.Wookie?.Selfies?.Count).GetValueOrDefault(0) }).ToList();

            return Task.FromResult(result);
        }
        #endregion
    }
}
