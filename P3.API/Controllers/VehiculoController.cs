using Microsoft.AspNetCore.Mvc;
using P3.Abstracciones.LogicaNegocio.Vehiculo;
using P3.Abstracciones.Modelos.ModelosDTO;

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

        // GET api/vehiculos  (lista)
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

        // POST api/vehiculos  (crear)
        [HttpPost("api/vehiculos")]
        public async Task<IActionResult> AgregarVehiculo([FromBody] VehiculoDTO vehiculo)
        {
            var respuesta = await _vehiculoLN.AgregarVehiculo(vehiculo);

            if (respuesta.EsError)
            {
                return BadRequest(respuesta.Mensaje);
            }

            return Ok(respuesta);
        }

        // 🔍 GET api/vehiculos/{placa}  (detalle)
        [HttpGet("api/vehiculos/{placa}")]
        public async Task<IActionResult> ObtenerVehiculoPorPlaca(string placa)
        {
            var respuesta = await _vehiculoLN.ObtenerVehiculoPorPlaca(placa);

            if (respuesta.EsError)
            {
                return NotFound(respuesta.Mensaje);
            }

            return Ok(respuesta);
        }

        // ✏️ PUT api/vehiculos/{placa}  (editar)
        [HttpPut("api/vehiculos/{placa}")]
        public async Task<IActionResult> EditarVehiculo(string placa, [FromBody] VehiculoDTO vehiculo)
        {
            // Aseguramos que la placa usada para buscar sea la del route
            vehiculo.Placa = placa;

            var respuesta = await _vehiculoLN.EditarVehiculo(vehiculo);

            if (respuesta.EsError)
            {
                return BadRequest(respuesta.Mensaje);
            }

            return Ok(respuesta);
        }

        // 🗑️ DELETE api/vehiculos/{placa}  (eliminar)
        [HttpDelete("api/vehiculos/{placa}")]
        public async Task<IActionResult> EliminarVehiculo(string placa)
        {
            var respuesta = await _vehiculoLN.EliminarVehiculo(placa);

            if (respuesta.EsError)
            {
                return BadRequest(respuesta.Mensaje);
            }

            return Ok(respuesta);
        }
    }
}
