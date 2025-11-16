
using Microsoft.EntityFrameworkCore;
using P3.Abstracciones.AccesoDatos.Vehiculo;
using P3.Abstracciones.Modelos.ModelosAD;

namespace P3.AccesoDatos.Vehiculo
{
    public class VehiculoRepositorioAD : IVehiculoAD
    {
        private readonly Context _context;

        public VehiculoRepositorioAD(Context context)
        {
            _context = context;
        }

        public async Task<List<VehiculoAD>> ListarVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }
    }
}
