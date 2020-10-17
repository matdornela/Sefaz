using System;
using System.Runtime.Serialization;

namespace Sefaz.Dominio.Exceptions
{
    [Serializable]
    public class BLLException : Exception
    {
        public BLLException()
            : this("Erro ao executar procedimento referente ao negócio") { }

        public BLLException(string message)
            : base(message) { }

        protected BLLException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

}