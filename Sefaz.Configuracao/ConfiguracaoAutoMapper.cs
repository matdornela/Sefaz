using AutoMapper;
using Sefaz.Apresentacao.DTOs;
using Sefaz.Dominio.Modelo.Models;
using Sefaz.Infraestrutura.DAL.EF.Configuracao;

namespace Sefaz.Configuracao
{
    public class ConfiguracaoAutoMapper
    {
        public static void AutoMapperMapear()
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProdutoDTO, ProdutoModel>().ReverseMap();

                //Configura automapper da DAL
                InfraestruturaAutoMapper.AutoMapperMapear(cfg);
            });
        }
    }
}