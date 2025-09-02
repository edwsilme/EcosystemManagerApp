using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosystemManager.Application.Exceptions
{
    /// <summary>
    /// Excepción que se lanza cuando no se encuentra una entidad o recurso específico.
    /// </summary>
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
