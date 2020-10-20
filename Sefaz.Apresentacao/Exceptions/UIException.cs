using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Sefaz.Apresentacao.Exceptions
{
    [Serializable]
    public class UIException : Exception
    {
        public UIException()
            : this("Erro ao executar procedimento referente a Interface do Usuário") { }

        public UIException(string message)
            : base(message) { }

        protected UIException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
