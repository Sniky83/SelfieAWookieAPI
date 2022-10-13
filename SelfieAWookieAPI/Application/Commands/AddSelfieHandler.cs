using MediatR;
using SelfieAWookie.Core.Selfies.Domain;
using SelfieAWookieAPI.Application.DTOs;

namespace SelfieAWookieAPI.Application.Commands
{
    public class AddSelfieHandler : IRequestHandler<AddSelfieCommand, SelfieDto>
    {
        #region Fields
        private readonly ISelfieRepository _repository = null;
        #endregion

        #region Constructors
        public AddSelfieHandler(ISelfieRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Public Methods
        public Task<SelfieDto> Handle(AddSelfieCommand request, CancellationToken cancellationToken)
        {
            SelfieDto result = null;

            Selfie addSelfie = _repository.AddOne(new Selfie()
            {
                ImagePath = request.Item.ImagePath,
                Title = request.Item.Title
            });
            _repository.UnitOfWork.SaveChanges();

            if (addSelfie != null)
            {
                request.Item.Id = addSelfie.Id;
                result = request.Item;
            }

            return Task.FromResult(result);
        }
        #endregion
    }
}
