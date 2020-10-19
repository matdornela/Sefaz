using Sefaz.Dominio.Modelo.Interfaces;
using Sefaz.Dominio.Modelo.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sefaz.Dominio.BLL.BLL
{
    public interface IProdutoBLL
    {
        List<ProdutoModel> ObterListaUltimoProdutoVendidoPorEstabelecimento(long codigoGtin);
    }

    public class ProdutoBLL : IProdutoBLL
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoBLL(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public List<ProdutoModel> ObterListaUltimoProdutoVendidoPorEstabelecimento(long codigoGtin)
        {
            var produtos = _produtoRepositorio.ObterProdutos(codigoGtin);

            var produtosValidos = produtos.Where(p => p.NumeroLatitude != "" && p.NumeroLongitude != "").ToList();

            var listaUltimoProdutoVendidoPorEstabelecimento = produtosValidos
                .GroupBy(x => x.EstabelecimentoId)
                .SelectMany(g => g.Where(x => x.DataEmissao == g.Max(y => y.DataEmissao)))
                .OrderBy(x => x.ValorUnitario).ToList();

            return listaUltimoProdutoVendidoPorEstabelecimento;
        }
    }
}