using System.Threading.Tasks;
using GestionITM.Domain.Entities;

namespace GestionITM.Domain.Interfaces
{
    public interface IMatriculaRepository
    {
        Task AgregarAsync(Matricula matricula);
    }
}
