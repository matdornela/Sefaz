using System;
using System.Runtime.Serialization;

namespace Sefaz.Dominio.Exceptions
{
    [Serializable]
    public class SefazException : Exception
    {
        public SefazException()
            : this("Erro ao executar procedimento referente ao negócio") { }

        public SefazException(string message)
            : base(message) { }

        protected SefazException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}