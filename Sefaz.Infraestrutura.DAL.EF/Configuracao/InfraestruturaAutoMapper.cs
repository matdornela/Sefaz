using AutoMapper;
using Sefaz.Dominio.Modelo.Models;
using Sefaz.Infraestrutura.DAL.EF.Models;

namespace Sefaz.Infraestrutura.DAL.EF.Configuracao
{
    public class InfraestruturaAutoMapper
    {
        public static void AutoMapperMapear(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Produto, ProdutoModel>().ReverseMap();
        }
    }
}