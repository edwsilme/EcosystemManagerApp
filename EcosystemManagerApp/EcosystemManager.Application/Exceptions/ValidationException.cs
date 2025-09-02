using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosystemManager.Application.Exceptions
{
    /// <summary>
    /// Excepción que se lanza cuando ocurren uno o más errores de validación de negocio.
    /// </summary>
    public class ValidationException : BaseException
    {
        /// <summary>
        /// Contiene los errores de validación, agrupados por nombre de propiedad.
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException() : base("Han ocurrido uno o más errores de validación.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        // Constructor para un único error de validación.
        public ValidationException(string propertyName, string errorMessage) : this()
        {
            Errors.Add(propertyName, new string[] { errorMessage });
        }

        // Constructor para recibir una lista de errores ya existente.
        public ValidationException(IDictionary<string, string[]> errors) : this()
        {
            Errors = errors;
        }
    }
}
