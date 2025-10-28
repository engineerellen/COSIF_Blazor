﻿using COSIF.Domain.Entities;

namespace COSIF.Application.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
    }
}