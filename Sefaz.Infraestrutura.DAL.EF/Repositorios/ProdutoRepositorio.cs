using AutoMapper;
using Sefaz.Dominio.Exceptions;
using Sefaz.Dominio.Modelo.Interfaces;
using Sefaz.Dominio.Modelo.Models;
using Sefaz.Infraestrutura.DAL.EF.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sefaz.Infraestrutura.DAL.EF.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly SefazContext _context;

        public ProdutoRepositorio(SefazContext context)
        {
            _context = context;
        }

        public List<ProdutoModel> ObterProdutos(long codigoGtin)
        {

            var produtos = _context.Produto.Where(p => p.CodigoGtin == codigoGtin).ToList();

            if (produtos.Count == 0) throw new SefazException("Não foram encontrados registros");

            return Mapper.Map<List<Produto>, List<ProdutoModel>>(produtos);
        }
    }
}