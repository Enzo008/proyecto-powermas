using System.ComponentModel.DataAnnotations;

namespace proyecto_powermas.Models
{
    public class Producto
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Por favor, introduce un nombre")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor, introduce una descripción")]
        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor, introduce un precio")]
        [Range(0, double.MaxValue, ErrorMessage = "Por favor, introduce un precio válido")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "Por favor, introduce una cantidad en stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Por favor, introduce una cantidad en stock válida")]
        public int CantidadEnStock { get; set; }

        public DateTime FechaDeCreacion { get; set; }
    }

}
