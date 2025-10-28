using COSIF.Domain.Entities;
using COSIF.Domain.Interfaces;

namespace COSIF.Application.Services
{
    public class CosifService : ICosifService
    {
        private readonly IProdutoCosifRepository _repo;
        public CosifService(IProdutoCosifRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProdutoCosif>> GetCosifByProdutoAsync(string codProduto)
        {
            if (string.IsNullOrEmpty(codProduto))
                return new List<ProdutoCosif>();

            return await _repo.GetCosifByProdutoAsync(codProduto) ?? new List<ProdutoCosif>();
        }

        public async Task<IEnumerable<ProdutoCosif>> GetCosifsAsync()
        {
            try
            {
                var lstcosif = await _repo.GetCosifsAsync();
                return lstcosif ?? new List<ProdutoCosif>();
            }
            catch (Exception ex)
            {
                return new List<ProdutoCosif>();
            }
        }
    }
}