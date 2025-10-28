
# COSIF Dapper + SQL Server (Movimentos CRUD)

Arquivos gerados:
- ScriptsDB/Script.sql -> script para criar banco e stored procedures.
- ScriptsDB/COSIF_Seed.sql -> script para alimentar tabelas essencias.
- Fontes/COSIF.Api -> Web API (.NET 9) com endpoints GET/POST /api/movimento, /api/produto, /api/produtoCosif e api/produtoCosif/{codProduto}
- Fontes/COSIF.BlazorServer -> Blazor Server simples com página /movimentos
- Domain, Application, Infrastructure com implementações mínimas (Dapper)

## Como rodar rapidamente

1. Execute o script `ScriptsDB/COSIF_Init.sql` no seu SQL Server para criar o banco.
2. Abra solução (crie a solução manualmente se quiser) ou execute separadamente os projetos:
   - `dotnet run` dentro de `Fontes/COSIF.Api`
   - `dotnet run` dentro de `Fontes/COSIF.WEB`
3. Ajuste connection string em `appsettings.json` ou em `Program.cs`, se necessário.

Observações:
- A lógica de geração de número do lançamento e preenchimento de DAT_MOVIMENTO fica na stored procedure `SP_InsertMovimento`.
- Este é um skeleton funcional — adapte rotas, autenticação e validações conforme necessário.
