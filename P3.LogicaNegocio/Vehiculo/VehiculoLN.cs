
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

            if (await _vehiculoAD.AgregarVehiculo(_mapper.Map<VehiculoAD>(vehiculo)))
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
            var customResponse = new CustomResponse<List<VehiculoDTO>>();

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

        // 🔍 Detalle por placa
        public async Task<CustomResponse<VehiculoDTO>> ObtenerVehiculoPorPlaca(string placa)
        {
            var customResponse = new CustomResponse<VehiculoDTO>();

            var entidad = await _vehiculoAD.ObtenerVehiculoPorPlaca(placa);

            if (entidad == null)
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "No se encontró el vehículo.";
                return customResponse;
            }

            customResponse.Data = _mapper.Map<VehiculoDTO>(entidad);
            customResponse.Mensaje = "Vehículo obtenido correctamente.";
            return customResponse;
        }

        // ✏️ Editar vehículo
        public async Task<CustomResponse<VehiculoDTO>> EditarVehiculo(VehiculoDTO vehiculo)
        {
            var customResponse = new CustomResponse<VehiculoDTO>();

            // Buscar el existente por placa
            var entidad = await _vehiculoAD.ObtenerVehiculoPorPlaca(vehiculo.Placa);

            if (entidad == null)
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "No se encontró el vehículo a editar.";
                return customResponse;
            }

            // Actualizar campos (ajusta nombres según tu entidad AD)
            entidad.Color = vehiculo.Color;
            entidad.Kilometraje = vehiculo.Kilometraje;
            entidad.Anio = vehiculo.Anio;
            entidad.Marca = vehiculo.Marca;
            entidad.Modelo = vehiculo.Modelo;
            entidad.Cilindrada = vehiculo.Cilindrada;
            entidad.CapacidadPasajeros = vehiculo.CapacidadPasajeros;

            var exito = await _vehiculoAD.EditarVehiculo(entidad);

            if (!exito)
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "Error al editar el vehículo.";
                return customResponse;
            }

            customResponse.Data = vehiculo;
            customResponse.Mensaje = "Vehículo editado correctamente.";
            return customResponse;
        }

        // 🗑️ Eliminar vehículo
        public async Task<CustomResponse<bool>> EliminarVehiculo(string placa)
        {
            var customResponse = new CustomResponse<bool>();

            var exito = await _vehiculoAD.EliminarVehiculo(placa);

            if (!exito)
            {
                customResponse.EsError = true;
                customResponse.Mensaje = "No se pudo eliminar el vehículo (no existe o error en BD).";
                customResponse.Data = false;
                return customResponse;
            }

            customResponse.Data = true;
            customResponse.Mensaje = "Vehículo eliminado correctamente.";
            return customResponse;
        }
    }
}
