using COSIF.Domain.Entities;

namespace COSIF.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
    }
}