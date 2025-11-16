
using AutoMapper;
using P3.Abstracciones.Modelos.ModelosAD;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.LogicaNegocio.Mapper
{
    public class MapeoClases : Profile
    {
        public MapeoClases()
        {
            CreateMap<VehiculoDTO,VehiculoAD>();
            CreateMap<VehiculoAD, VehiculoDTO>();
        }
    }
}
