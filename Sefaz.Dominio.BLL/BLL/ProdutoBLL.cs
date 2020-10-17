using Sefaz.Dominio.Modelo.Interfaces;
using Sefaz.Dominio.Modelo.Models;
using System.Collections.Generic;
using Sefaz.Dominio.Exceptions;

namespace Sefaz.Dominio.BLL.BLL
{
    public interface IProdutoBLL
    {
        List<ProdutoModel> ObterProdutos(long codigoGtin);
    }

    public class ProdutoBLL : IProdutoBLL
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoBLL(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public List<ProdutoModel> ObterProdutos(long codigoGtin) => _produtoRepositorio.ObterProdutos(codigoGtin);
    }
}