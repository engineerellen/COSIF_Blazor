using COSIF.Domain.Entities;

namespace COSIF.Application.Services
{
    public interface ICosifService
    {
        Task<IEnumerable<ProdutoCosif>> GetCosifByProdutoAsync(string codProduto);
        Task<IEnumerable<ProdutoCosif>> GetCosifsAsync();
    }
}