using COSIF.Domain.Entities;
using COSIF.Domain.Interfaces;

namespace COSIF.Application.Services;

public class MovimentoService : IMovimentoService
{
    private readonly IMovimentoRepository _repo;
    public MovimentoService(IMovimentoRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<MovimentoManual>> GetMovimentosAsync()
    {
        try
        {
            var movimentos = await _repo.GetMovimentosAsync();
            return movimentos ?? new List<MovimentoManual>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao obter movimentos: {ex.Message}");
            return new List<MovimentoManual>();
        }
    }


    public async Task InsertMovimentoAsync(MovimentoManual movimento)
    {
        await _repo.InsertMovimentoAsync(movimento);
    }
}