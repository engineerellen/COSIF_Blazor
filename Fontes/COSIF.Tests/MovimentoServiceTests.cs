using COSIF.Application.Services;
using COSIF.Domain.Entities;
using COSIF.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace COSIF.Tests
{
    public class MovimentoServiceTests
    {
        [Fact]
        public async Task InsertMovimento_Should_Call_Repository()
        {
            var mockRepo = new Mock<IMovimentoRepository>();

            var service = new MovimentoService(mockRepo.Object);

            var movimento = new MovimentoManual
            {
                DatMes = 1,
                DatAno = 2025,
                CodProduto = "P001",
                CodCosif = "C001",
                ValValor = 100,
                DesDescricao = "Teste",
                CodUsuario = "testuser"
            };

            // Act
            await service.InsertMovimentoAsync(movimento);

            // Assert
            mockRepo.Verify(r => r.InsertMovimentoAsync(It.IsAny<MovimentoManual>()), Times.Once);
        }


        [Fact]
        public async Task GetMovimentosAsync_Should_Return_List_Of_Movimentos()
        {

            var mockRepo = new Mock<IMovimentoRepository>();

            var movimentos = new List<MovimentoManual>
            {
                new MovimentoManual
                {
                    DatMes = 1,
                    DatAno = 2025,
                    CodProduto = "P001",
                    CodCosif = "C001",
                    ValValor = 100,
                    DesDescricao = "Teste 1",
                    CodUsuario = "user1"
                },
                new MovimentoManual
                {
                    DatMes = 2,
                    DatAno = 2025,
                    CodProduto = "P002",
                    CodCosif = "C002",
                    ValValor = 200,
                    DesDescricao = "Teste 2",
                    CodUsuario = "user2"
                }
            };

            mockRepo.Setup(r => r.GetMovimentosAsync())
                    .ReturnsAsync(movimentos);

            var service = new MovimentoService(mockRepo.Object);

            var result = await service.GetMovimentosAsync();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, ((List<MovimentoManual>)result).Count);
            Assert.Contains(result, m => m.CodProduto == "P001");
            mockRepo.Verify(r => r.GetMovimentosAsync(), Times.Once);
        }
    }
}