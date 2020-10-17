using System;
using System.Collections.Generic;
using System.Text;
using Sefaz.Dominio.Modelo.Models;

namespace Sefaz.Dominio.Modelo.Interfaces
{
    public interface IProdutoRepositorio
    {
        List<ProdutoModel> ObterProdutos(long codigoGtin);

    }
}
