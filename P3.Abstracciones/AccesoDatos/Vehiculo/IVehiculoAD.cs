
using P3.Abstracciones.Modelos.ModelosAD;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.Abstracciones.AccesoDatos.Vehiculo
{
    public interface IVehiculoAD
    {
        Task<List<VehiculoAD>> ListarVehiculos();

        Task<bool> AgregarVehiculo(VehiculoAD vehiculo);

    }
}
