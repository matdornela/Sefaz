using System;
using AutoMapper;
using Sefaz.Apresentacao.DTOs;
using Sefaz.Dominio.BLL.BLL;
using Sefaz.Dominio.Modelo.Models;
using System.Collections.Generic;
using System.Device.Location;

namespace Sefaz.Apresentacao.WorkServices
{
    public interface IProdutoWorkService
    {
        List<ProdutoDTO> ObterProdutos(long codigoGtin, string inputLatitude = null, string inputLongitude = null);
    }

    public class ProdutoWorkService : IProdutoWorkService
    {
        private readonly IProdutoBLL _produtoBLL;

        public ProdutoWorkService(IProdutoBLL produtoBll)
        {
            _produtoBLL = produtoBll;
        }

        public List<ProdutoDTO> ObterProdutos(long codigoGtin, string inputLatitude, string inputLongitude)
        {
            var produtos = Mapper.Map<List<ProdutoModel>, List<ProdutoDTO>>(_produtoBLL.ObterProdutos(codigoGtin));
            var coordenadaA = new GeoCoordinate(Convert.ToDouble(inputLatitude), Convert.ToDouble(inputLongitude));
            foreach (var p in produtos)
            {
                var coordenadaB = new GeoCoordinate(Convert.ToDouble(p.NumeroLatitude), Convert.ToDouble(p.NumeroLongitude));
                p.UrlGoogleMaps = $@"http://maps.google.com/maps?q={p.NumeroLongitude},{p.NumeroLatitude}";
                p.DistanciaKm = coordenadaA.GetDistanceTo(coordenadaB) / 1000;
            }
            return produtos;
        }
    }
}