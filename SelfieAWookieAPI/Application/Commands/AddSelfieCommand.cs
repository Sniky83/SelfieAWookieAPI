using MediatR;
using SelfieAWookieAPI.Application.DTOs;

namespace SelfieAWookieAPI.Application.Commands
{
    /// <summary>
    /// Commande pour ajouter un selfie a la base de données
    /// </summary>
    public class AddSelfieCommand : IRequest<SelfieDto>
    {
        #region Properties
        public SelfieDto Item { get; set; }
        #endregion
    }
}
