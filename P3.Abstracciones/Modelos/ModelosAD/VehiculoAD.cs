
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P3.Abstracciones.Modelos.ModelosAD
{
    [Table("VEHICULO")]
    public class VehiculoAD
    {
        [Key]
        [Column("Id_Vehiculo")]
        public Guid Id_Vehiculo { get; set; }   

        [Column("Placa")]
        public string Placa { get; set; }

        [Column("Kilometraje")]
        public int Kilometraje { get; set; }

        [Column("Color")]
        public string Color { get; set; }

        [Column("Anio")]
        public int Anio { get; set; }

        [Column("Marca")]
        public string Marca { get; set; }

        [Column("Modelo")]
        public string Modelo { get; set; }

        [Column("Cilindrada")]
        public int Cilindrada { get; set; }

        [Column("CapacidadPasajeros")]
        public int CapacidadPasajeros { get; set; }

    }
}
