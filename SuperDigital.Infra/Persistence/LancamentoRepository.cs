using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Repository;
using System.Threading.Tasks;

namespace SuperDigital.Infra
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public async Task RegistraLancamento(Operacao operacao)
        {
            //persiste dados do lancamento no banco de dados;
        }
    }
}
