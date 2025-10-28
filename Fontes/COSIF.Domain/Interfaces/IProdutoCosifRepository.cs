using COSIF.Domain.Entities;

namespace COSIF.Domain.Interfaces
{
    public interface IProdutoCosifRepository
    {
        Task<IEnumerable<ProdutoCosif>> GetCosifByProdutoAsync(string codProduto);

        Task<IEnumerable<ProdutoCosif>> GetCosifsAsync();
    }
}