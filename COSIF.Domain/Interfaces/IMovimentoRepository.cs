using COSIF.Domain.Entities;

namespace COSIF.Domain.Interfaces
{
    public interface IMovimentoRepository
    {
        Task<IEnumerable<MovimentoManual>> GetMovimentosAsync();
        Task<long> GetNextLancamentoAsync(byte mes, short ano);
        Task InsertMovimentoAsync(MovimentoManual movimento);
    }
}