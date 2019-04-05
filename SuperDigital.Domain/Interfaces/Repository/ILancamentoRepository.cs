using SuperDigital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperDigital.Domain.Interfaces.Repository
{
    public interface ILancamentoRepository
    {
        Task RegistraLancamento(Operacao operacao);
    }
}
