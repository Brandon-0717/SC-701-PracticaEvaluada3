using P3.Abstracciones.Modelos.ModelosAD;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.Abstracciones.AccesoDatos.Vehiculo
{
    public interface IVehiculoAD
    {
        // Listar todos
        Task<List<VehiculoAD>> ListarVehiculos();

        Task<bool> AgregarVehiculo(VehiculoAD vehiculo);

     
        Task<VehiculoAD?> ObtenerVehiculoPorPlaca(string placa);

        Task<bool> EditarVehiculo(VehiculoAD vehiculo);

    
        Task<bool> EliminarVehiculo(string placa);
    }
}
