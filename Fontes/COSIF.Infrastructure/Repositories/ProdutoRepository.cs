using COSIF.Domain.Entities;
using Microsoft.Data.SqlClient;
using COSIF.Domain.Interfaces;
using Dapper;

namespace COSIF.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string _connectionString;
        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            const string sql = @"SELECT COD_PRODUTO AS CodProduto, DES_PRODUTO AS DesProduto, STA_STATUS AS StaStatus
                                 FROM dbo.PRODUTO
                                 WHERE STA_STATUS = 'A'";

            await using var cn = new SqlConnection(_connectionString);
            await cn.OpenAsync();
            var result = await cn.QueryAsync<Produto>(sql);
            return result;
        }

        public async Task<Produto?> GetProdutoByCodigoAsync(string codProduto)
        {
            const string sql = @"SELECT COD_PRODUTO AS CodProduto, DES_PRODUTO AS DesProduto, STA_STATUS AS StaStatus
                                 FROM dbo.PRODUTO
                                 WHERE COD_PRODUTO = @codProduto AND STA_STATUS = 'A'";
            await using var cn = new SqlConnection(_connectionString);
            await cn.OpenAsync();
            var result = await cn.QuerySingleOrDefaultAsync<Produto>(sql, new { codProduto });
            return result;
        }
    }
}