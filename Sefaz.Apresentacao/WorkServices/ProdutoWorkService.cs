using AutoMapper;
using Sefaz.Apresentacao.DTOs;
using Sefaz.Dominio.BLL.BLL;
using Sefaz.Dominio.Modelo.Models;
using System.Collections.Generic;

namespace Sefaz.Apresentacao.WorkServices
{
    public interface IProdutoWorkService
    {
        List<ProdutoDTO> ObterProdutos(long codigoGtin);
    }

    public class ProdutoWorkService : IProdutoWorkService
    {
        private readonly IProdutoBLL _produtoBLL;

        public ProdutoWorkService(IProdutoBLL produtoBll)
        {
            _produtoBLL = produtoBll;
        }

        public List<ProdutoDTO> ObterProdutos(long codigoGtin)
        {
            var produtos = Mapper.Map<List<ProdutoModel>, List<ProdutoDTO>>(_produtoBLL.ObterProdutos(codigoGtin));

            foreach (var p in produtos)
            {
                p.UrlGoogleMaps = $@"http://maps.google.com/maps?q={p.NumeroLongitude},{p.NumeroLatitude}";
            }
            return produtos;
        }
    }
}