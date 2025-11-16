
using AutoMapper;
using P3.Abstracciones.AccesoDatos.Vehiculo;
using P3.Abstracciones.LogicaNegocio.Vehiculo;
using P3.Abstracciones.Modelos;
using P3.Abstracciones.Modelos.ModelosAD;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.LogicaNegocio.Vehiculo
{
    public class VehiculoLN : IVehiculoLN
    {
        private readonly IVehiculoAD _vehiculoAD;
        private readonly IMapper _mapper;
        public VehiculoLN(IVehiculoAD vehiculoAD, IMapper mapper)
        {
            _vehiculoAD = vehiculoAD;
            _mapper = mapper;
        }

        public async Task<CustomResponse<VehiculoDTO>> AgregarVehiculo(VehiculoDTO vehiculo)
        {
            var customResponse = new CustomResponse<VehiculoDTO>();

           if(await _vehiculoAD.AgregarVehiculo(_mapper.Map<VehiculoAD>(vehiculo)))
            {
                customResponse.Mensaje = "Vehículo agregado correctamente.";
                customResponse.Data = vehiculo;
                return customResponse;
            }
           else
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "Error al agregar el vehículo.";
                return customResponse;
            }

        }




        public async Task<CustomResponse<List<VehiculoDTO>>> ListarVehiculos()
        {
            var customResponse = new CustomResponse<List<VehiculoDTO>> ();

            var listaVehiculos = await _vehiculoAD.ListarVehiculos();

            if (!listaVehiculos.Any())
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "No se encontraron vehículos.";
                return customResponse;
            }

            customResponse.Data = _mapper.Map<List<VehiculoDTO>>(listaVehiculos);
            customResponse.Mensaje = "Vehículos obtenidos correctamente.";
            return customResponse;
        }
    }
}
