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

        // 🔍 Detalle por placa
        public async Task<VehiculoAD?> ObtenerVehiculoPorPlaca(string placa)
        {
            return await _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Placa == placa);
        }

        // ✏️ Editar vehículo
        public async Task<bool> EditarVehiculo(VehiculoAD vehiculo)
        {
            _context.Vehiculos.Update(vehiculo);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        // 🗑️ Eliminar por placa
        public async Task<bool> EliminarVehiculo(string placa)
        {
            var entidad = await _context.Vehiculos
                .FirstOrDefaultAsync(v => v.Placa == placa);

            if (entidad == null)
                return false;

            _context.Vehiculos.Remove(entidad);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}