
using P3.Abstracciones.Modelos.ModelosAD;

namespace P3.Abstracciones.AccesoDatos.Vehiculo
{
    public interface IVehiculoAD
    {
        Task<List<VehiculoAD>> ListarVehiculos();
    }
}
