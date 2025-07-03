namespace AgendaApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reunion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo de reunión es obligatorio.")]
        [StringLength(50, ErrorMessage = "El tipo no puede tener más de 50 caracteres.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "La fecha de la reunión es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El lugar es obligatorio.")]
        [StringLength(100, ErrorMessage = "El lugar no puede tener más de 100 caracteres.")]
        public string Lugar { get; set; }

        [StringLength(300, ErrorMessage = "Las notas no pueden superar los 300 caracteres.")]
        public string Notas { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [StringLength(20, ErrorMessage = "El estado no puede tener más de 20 caracteres.")]
        public string Status { get; set; }
    }

}
