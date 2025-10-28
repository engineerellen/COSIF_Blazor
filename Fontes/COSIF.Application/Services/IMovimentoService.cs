using COSIF.Domain.Entities;

namespace COSIF.Application.Services
{
    public interface IMovimentoService
    {
        Task<IEnumerable<MovimentoManual>> GetMovimentosAsync();
        Task InsertMovimentoAsync(MovimentoManual movimento);
    }
}