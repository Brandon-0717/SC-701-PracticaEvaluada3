
using P3.Abstracciones.Modelos;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.Abstracciones.LogicaNegocio.Vehiculo
{
    public interface IVehiculoLN
    {
        Task<CustomResponse<List<VehiculoDTO>>> ListarVehiculos();
    }
}
