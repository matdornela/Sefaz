using AutoMapper;
using Sefaz.Apresentacao.DTOs;
using Sefaz.Apresentacao.Exceptions;
using Sefaz.Dominio.BLL.BLL;
using Sefaz.Dominio.Exceptions;
using Sefaz.Dominio.Modelo.Models;
using System;
using System.Collections.Generic;
using System.Device.Location;

namespace Sefaz.Apresentacao.WorkServices
{
    public interface IProdutoWorkService
    {
        List<ProdutoDTO> ObterListaUltimoProdutoVendidoPorEstabelecimento(long codigoGtin, string inputLatitude, string inputLongitude);
    }

    public class ProdutoWorkService : IProdutoWorkService
    {
        private readonly IProdutoBLL _produtoBLL;

        public ProdutoWorkService(IProdutoBLL produtoBll)
        {
            _produtoBLL = produtoBll;
        }

        public List<ProdutoDTO> ObterListaUltimoProdutoVendidoPorEstabelecimento(long codigoGtin, string inputLatitude, string inputLongitude)
        {
            var listaUltimoProdutoVendidoPorEstabelecimento = codigoGtin != 0 ?
                Mapper.Map<List<ProdutoModel>, List<ProdutoDTO>>(_produtoBLL.ObterListaUltimoProdutoVendidoPorEstabelecimento(codigoGtin)) :
                throw new UIException();
            try
            {
                var coordenadaA = new GeoCoordinate(Convert.ToDouble(inputLatitude), Convert.ToDouble(inputLongitude));
                foreach (var p in listaUltimoProdutoVendidoPorEstabelecimento)
                {
                    if (inputLatitude != null && inputLongitude != null)
                    {
                        var coordenadaB = new GeoCoordinate(Convert.ToDouble(p.NumeroLatitude),
                            Convert.ToDouble(p.NumeroLongitude));
                        p.DistanciaKm = Convert.ToString(coordenadaA.GetDistanceTo(coordenadaB) / 1000);
                    }

                    p.UrlGoogleMaps = $@"http://maps.google.com/maps?q={p.NumeroLongitude},{p.NumeroLatitude}";
                }
            }
            catch (Exception e)
            {
                if (e is SefazException)
                {
                    throw new SefazException(e.Message);
                }
                else
                {

                    throw new UIException(e.Message);
                }
            }

            return listaUltimoProdutoVendidoPorEstabelecimento;
        }
    }
}