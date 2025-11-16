
using Microsoft.EntityFrameworkCore;
using P3.Abstracciones.AccesoDatos.Vehiculo;
using P3.Abstracciones.Modelos.ModelosAD;
using P3.Abstracciones.Modelos.ModelosDTO;

namespace P3.AccesoDatos.Vehiculo
{
    public class VehiculoRepositorioAD : IVehiculoAD
    {
        private readonly Context _context;

        public VehiculoRepositorioAD(Context context)
        {
            _context = context;
        }

        public async Task<bool> AgregarVehiculo(VehiculoAD vehiculo)
        {
            
            await _context.Vehiculos.AddAsync(vehiculo);
            var result = await _context.SaveChangesAsync();
            return result > 0;

        }

        public async Task<List<VehiculoAD>> ListarVehiculos()
        {
            return await _context.Vehiculos.ToListAsync();
        }
    }
}
