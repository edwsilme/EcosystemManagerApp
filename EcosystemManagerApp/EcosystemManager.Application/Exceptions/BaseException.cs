using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosystemManager.Application.Exceptions
{
    /// <summary>
    /// Clase base para todas las excepciones personalizadas de la aplicación.
    /// </summary>
    public abstract class BaseException : Exception
    {
        public string ErrorCode { get; set; }

        protected BaseException() : base() { }

        protected BaseException(string message) : base(message) { }

        protected BaseException(string message, System.Exception innerException)
            : base(message, innerException) { }
    }
}
