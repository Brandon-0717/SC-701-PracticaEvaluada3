
using System.ComponentModel.DataAnnotations;

namespace P3.Abstracciones.Modelos.ModelosDTO
{
    public class VehiculoDTO
    {
        [Required(ErrorMessage ="La placa del vehiculo es obligatoria")]
        [MaxLength(8, ErrorMessage = "La placa del vehiculo no puede tener más de 8 caracteres")]
        [MinLength(6, ErrorMessage = "La placa del vehiculo debe tener al menos 6 caracteres")]
        [RegularExpression("^[A-Z]{3}[-]?[0-9]{3}$", ErrorMessage = "La placa debe tener 3 letras seguidas de 3 números. Ejemplos válidos: ABC123, ABC-123.\r\n")]
        
        public string Placa { get; set; }

        [Required(ErrorMessage = "El kilometraje del vehiculo es obligatorio")]
        public int Kilometraje { get; set; }

        [Required(ErrorMessage = "El color del vehiculo es obligatorio")]
        public string Color { get; set; }

        [Required(ErrorMessage = "El año del vehiculo es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "El año del vehiculo debe estar entre 1900 y 2100")]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Required(ErrorMessage = "La marca del vehiculo es obligatoria")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El modelo del vehiculo es obligatorio")]
        public string Modelo { get; set; }

        public int Cilindrada { get; set; }

        [Range(1, 30, ErrorMessage = "El año del vehiculo debe tener entre 1 y 30 pasajeros")]
        public int CapacidadPasajeros { get; set; }
    }
}
