using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sefaz.Infraestrutura.DAL.EF.Models
{
    public class Produto
    {
        public long ProdutoId { get; set; }
        public long CodigoGtin { get; set; }
        public DateTime DataEmissao { get; set; }
        public long CodigoTipoPagamento { get; set; }
        public long CodigoProduto { get; set; }
        public long CodigoNcm { get; set; }
        public string CodigoUnidade { get; set; }

        public string DescricaoProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public long EstabelecimentoId { get; set; }
        public string NomeEstabelecimento { get; set; }
        public string NomeLogradouro { get; set; }
        public long CodigoNumLogradouro { get; set; }
        public string Complemento { get; set; }
        public string NomeBairro { get; set; }
        public long CodigoMunicipioIbge { get; set; }
        public string NomeMunicipio { get; set; }
        public string NomeSiglaUf { get; set; }
        public long CodigoCep { get; set; }
        public string NumeroLatitude { get; set; }
        public string NumeroLongitude { get; set; }

        [NotMapped]
        public string UrlCoordinator { get; set; }
    }
}