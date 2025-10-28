using COSIF.Domain.Entities;
using COSIF.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace COSIF.Infrastructure.Repositories;

public class MovimentoRepository : IMovimentoRepository
{
    private readonly string _connectionString;
    public MovimentoRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<MovimentoManual>> GetMovimentosAsync()
    {
        using var cn = new SqlConnection(_connectionString);
        await cn.OpenAsync();
        var sql = @"SELECT m.DAT_MES DatMes, m.DAT_ANO DatAno, m.NUM_LANCAMENTO NumLancamento,
                           m.COD_PRODUTO CodProduto, p.DES_PRODUTO DesProduto, m.DES_DESCRICAO DesDescricao,
                           m.VAL_VALOR ValValor, m.DAT_MOVIMENTO DatMovimento, m.COD_USUARIO CodUsuario, m.COD_COSIF CodCosif
                    FROM dbo.MOVIMENTO_MANUAL m
                    LEFT JOIN dbo.PRODUTO p ON p.COD_PRODUTO = m.COD_PRODUTO
                    ORDER BY m.DAT_ANO, m.DAT_MES, m.NUM_LANCAMENTO;";
        var list = await cn.QueryAsync<MovimentoManual>(sql);
        return list;
    }

    public async Task<long> GetNextLancamentoAsync(byte mes, short ano)
    {
        using var cn = new SqlConnection(_connectionString);
        await cn.OpenAsync();
        return await GetNextLancamentoAsync(cn, mes, ano, null);
    }

    public async Task InsertMovimentoAsync(MovimentoManual movimento)
    {
        using var cn = new SqlConnection(_connectionString);
        await cn.OpenAsync();
        using var transaction = cn.BeginTransaction();

        try
        {
            movimento.NumLancamento = await GetNextLancamentoAsync(cn, movimento.DatMes, movimento.DatAno, transaction);
            movimento.DatMovimento = DateTime.Now;

            await InsertMovimentoInternalAsync(cn, movimento, transaction);

            transaction.Commit();
        }
        catch (Exception ex)
        {
            try { transaction.Rollback(); } catch { }
            throw new Exception($"Erro ao inserir movimento: {ex.Message}", ex);
        }
    }

    private async Task<long> GetNextLancamentoAsync(SqlConnection cn, byte mes, short ano, SqlTransaction? transaction)
    {
        const string sql = @"SELECT ISNULL(MAX(NUM_LANCAMENTO), 0) + 1 FROM dbo.MOVIMENTO_MANUAL WHERE DAT_MES = @Mes AND DAT_ANO = @Ano";
        var next = await cn.ExecuteScalarAsync<long>(sql, new { Mes = mes, Ano = ano }, transaction);
        return next;
    }

    private async Task InsertMovimentoInternalAsync(SqlConnection cn, MovimentoManual movimento, SqlTransaction transaction)
    {
        const string sql = @"
            INSERT INTO dbo.MOVIMENTO_MANUAL
                (DAT_MES, DAT_ANO, NUM_LANCAMENTO, COD_PRODUTO, COD_COSIF, VAL_VALOR, DES_DESCRICAO, DAT_MOVIMENTO, COD_USUARIO)
            VALUES
                (@DatMes, @DatAno, @NumLancamento, @CodProduto, @CodCosif, @ValValor, @DesDescricao, @DatMovimento, @CodUsuario)
        ";
        await cn.ExecuteAsync(sql, movimento, transaction);
    }
}