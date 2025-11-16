using Microsoft.AspNetCore.Mvc;
using P3.Abstracciones.LogicaNegocio.Vehiculo;

namespace P3.API.Controllers
{
    [ApiController]
    public class VehiculoController : Controller
    {
        private readonly IVehiculoLN _vehiculoLN;
        public VehiculoController(IVehiculoLN vehiculoLN)
        {
            _vehiculoLN = vehiculoLN;
        }

        [HttpGet("api/vehiculos")]

        public async Task<IActionResult> ListarVehiculos()
        {
            var resultado = await _vehiculoLN.ListarVehiculos();
            if (resultado.EsError)
            {
                return BadRequest(resultado.Mensaje);
            }
            return Ok(resultado.Data);
        }
    }
}
