using COSIF.Domain.Entities;
using COSIF.Domain.Interfaces;

namespace COSIF.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repo;
        public ProdutoService(IProdutoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            try
            {
                var produtos = await _repo.GetProdutosAsync();
                return produtos ?? new List<Produto>();
            }
            catch (Exception ex)
            {
                return new List<Produto>();
            }
        }

        public async Task<Produto?> GetProdutoByCodigoAsync(string codProduto)
        {
            try
            {
                var produto = await _repo.GetProdutoByCodigoAsync(codProduto);
                return produto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}