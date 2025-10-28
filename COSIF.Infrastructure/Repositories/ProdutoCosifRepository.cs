using Microsoft.Data.SqlClient;
using COSIF.Domain.Entities;
using COSIF.Domain.Interfaces;
using Dapper;

namespace COSIF.Infrastructure.Repositories
{
    public class ProdutoCosifRepository : IProdutoCosifRepository
    {
        private readonly string _connectionString;
        public ProdutoCosifRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<ProdutoCosif>> GetCosifByProdutoAsync(string codProduto)
        {
            const string sql = @"SELECT COD_COSIF AS CodCosif, COD_PRODUTO AS CodProduto, COD_CLASSIFICACAO AS CodClassificacao, STA_STATUS AS StaStatus
                                 FROM dbo.PRODUTO_COSIF
                                 WHERE COD_PRODUTO = @codProduto AND STA_STATUS = 'A'";

            await using var cn = new SqlConnection(_connectionString);
            await cn.OpenAsync();
            var result = await cn.QueryAsync<ProdutoCosif>(sql, new { codProduto });
            return result;
        }

        public async Task<IEnumerable<ProdutoCosif>> GetCosifsAsync()
        {
            const string sql = @"SELECT COD_COSIF AS CodCosif, COD_PRODUTO AS CodProduto, COD_CLASSIFICACAO AS CodClassificacao, STA_STATUS AS StaStatus
                                 FROM dbo.PRODUTO_COSIF
                                 WHERE STA_STATUS = 'A'";
            await using var cn = new SqlConnection(_connectionString);
            await cn.OpenAsync();
            var result = await cn.QueryAsync<ProdutoCosif>(sql);
            return result;
        }
    }
}