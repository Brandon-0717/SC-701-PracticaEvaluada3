
using P3.Abstracciones.Modelos;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.Abstracciones.LogicaNegocio.Vehiculo
{
    public interface IVehiculoLN
    {
        Task<CustomResponse<List<VehiculoDTO>>> ListarVehiculos();

        Task<CustomResponse<VehiculoDTO>> AgregarVehiculo(VehiculoDTO vehiculo);

        // 🔍 Detalle por placa
        Task<CustomResponse<VehiculoDTO>> ObtenerVehiculoPorPlaca(string placa);

        // ✏️ Editar vehículo
        Task<CustomResponse<VehiculoDTO>> EditarVehiculo(VehiculoDTO vehiculo);

        // 🗑️ Eliminar por placa
        Task<CustomResponse<bool>> EliminarVehiculo(string placa);
    }
}
