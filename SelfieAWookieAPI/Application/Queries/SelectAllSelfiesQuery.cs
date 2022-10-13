using MediatR;
using SelfieAWookieAPI.Application.DTOs;

namespace SelfieAWookieAPI.Application.Queries
{
    /// <summary>
    /// Requête pour selectionner tous les selfies avec les classes DTO
    /// </summary>
    public class SelectAllSelfiesQuery : IRequest<List<SelfieResumeDto>>
    {
        #region Properties
        public int WookieId { get; set; }
        #endregion
    }
}
